using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ANDREICSLIB.ClassExtras;
using ANDREICSLIB.Helpers;
using ANDREICSLIB.Licensing;

namespace ImageScripter
{
    public partial class Form1 : Form
    {
        #region Delegates

        public delegate void IncreaseProgressDel();

        #endregion

        public const int Progressrollover = 200;

        public string BaseDirectoryAbsPath;
        public string FormulaFolderAbsPath;
        public const String Formulafolder = "Formulas";
        public const string ConfigFile = "ImageOP.cfg";
        public const String Formulaextension = "IOFM";
        public List<Formula> Formulas = new List<Formula>();
        //private String _rootFolder = "";
        //all the currently opened images
        public Dictionary<int, ImagePanel> ImagePanels = new Dictionary<int, ImagePanel>();

        #region licensing
        private const String HelpString = "";

        private readonly String OtherText =
            @"©" + DateTime.Now.Year +
            @" Andrei Gec (http://www.andreigec.net)

Licensed under GNU LGPL (http://www.gnu.org/)

Zip Assets © SharpZipLib (http://www.sharpdevelop.net/OpenSource/SharpZipLib/)
";

        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool LoadImage(ref ImagePanel I, String path)
        {
            try
            {
                if (File.Exists(path) == false)
                    return false;
                I.I = Image.FromFile(path);
                I.output.BackgroundImage = I.I;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image:" + ex);
                return false;
            }
            return true;
        }

        private string GetFormulaPath(String relativeFormulaName)
        {
            return FormulaFolderAbsPath + relativeFormulaName;
        }

        private void LoadConfig()
        {
            FormConfigRestore.LoadConfig(this, ConfigFile);
            if (File.Exists(GetFormulaPath(fastformulaCB.Text)) == false)
                fastformulaCB.Text = "";
        }

        private void Form1Load(object sender, EventArgs e)
        {
            BaseDirectoryAbsPath = Directory.GetCurrentDirectory();
            FormulaFolderAbsPath = BaseDirectoryAbsPath + "\\" + Formulafolder + "\\";

            //ensure there is a formulas folder
            if (Directory.Exists(Formulafolder) == false)
                Directory.CreateDirectory(Formulafolder);

            //get the logical processor count by default
            var th = Environment.ProcessorCount;
            threadCB.Items.Add(th.ToString());
            threadCB.Text = th.ToString();

            LoadFastFormulas();
            LoadConfig();

            Licensing.LicensingForm(this, menuStrip1, HelpString, OtherText);
        }

        private void LoadFastFormulas()
        {
            var op = fastformulaCB.Text;
            fastformulaCB.Items.Clear();
            foreach (var s in Directory.GetFiles(FormulaFolderAbsPath))
            {
                if (s.EndsWith(Formulaextension))
                {
                    fastformulaCB.Items.Add(s.Substring(s.LastIndexOf('\\') + 1));
                }
            }

            fastformulaCB.Text = op;
        }


        private int GetLargestNumber(String type, String subtype, int index)
        {
            var diam = -1;
            try
            {
                foreach (var f in Formulas)
                {
                    if (f.type.Equals(type) && f.subtype.Equals(subtype))
                    {
                        if (int.Parse(f.Operations[index]) > diam)
                            diam = int.Parse(f.Operations[index]);
                    }
                }
            }
            catch
            {
                return -1;
            }
            return diam;
        }

        private void TrimFormulas()
        {
            foreach (var f in Formulas)
            {
                f.skip = false;
                if (f.type == Calculations.Commentop)
                    f.skip = true;
            }
        }

        private void ApplyFormula()
        {
            if (Calculations.Threadfincount > 0)
            {
                MessageBox.Show("already performing an operation");
                return;
            }

            if (Formulas.Count == 0)
            {
                MessageBox.Show("no formulas are loaded");
                return;
            }

            //trim formulas
            TrimFormulas();

            //sanity checks
            var error = Calculations.FormulaChecks(Formulas, ImagePanels);
            if (string.IsNullOrEmpty(error) == false)
            {
                MessageBox.Show(error, "Formula Error!");
                return;
            }

            var imlist = new Dictionary<int, CustomImage>();

            int maxw = 0, maxh = 0;
            var az = 0;
            var pf = PixelFormat.DontCare;
            foreach (var ic in ImagePanels)
            {
                var newim = new CustomImage(ic.Value);
                if (newim.Width > maxw)
                    maxw = newim.Width;
                if (newim.Height > maxh)
                    maxh = newim.Height;
                pf = newim.Format;
                imlist.Add(az, newim);
                az++;
            }

            if (maxw == 0 || maxh == 0)
            {
                MessageBox.Show("The current formula requires more images to be loaded");
                return;
            }

            var outputBitmap = new Bitmap(maxw, maxh, pf);
            var outputBitmapData = outputBitmap.LockBits(new Rectangle(0, 0, maxw, maxh), ImageLockMode.ReadOnly, outputBitmap.PixelFormat);

            var bys = Math.Abs(outputBitmapData.Stride) * outputBitmap.Height;
            var outputvalues = new byte[bys];

            //var time = DateTime.Now;
            var pixelsto = new CustomImage
            {
                Array = outputvalues,
                Format = outputBitmapData.PixelFormat,
                Height = outputBitmap.Height,
                Width = outputBitmap.Width,
                Scan0 = outputBitmapData.Scan0,
                Stride = outputBitmapData.Stride
            };

            var i = new Information { imlist = imlist, pixelsTo = pixelsto, maxw = maxw, maxh = maxh };

            Calculations.Initcalculations(Formulas, ref i);

            //get the custom matricies
            if (Calculations.GetCustomMatricies(Formulas) == false)
                return;

            //link the variables to their array
            Calculations.SetImageLocations();

            //get max pass count
            var passcount = GetLargestNumber(Calculations.Passoperation, "", 0);
            //if there is no pass, then we just want 1
            if (passcount == -1)
                passcount = 1;

            //set this form
            Calculations.Baseform = this;

            //create threads
            int threads;
            int.TryParse(threadCB.Text, out threads);
            //make sure there arent more threads than width
            if (threads > maxw)
                threads = maxw;
            var pixeldistance = maxw / threads;

            //for each pass
            progressbar.Value = 0;
            progressbar.Maximum = threads * passcount;

            for (var pass = 1; pass <= passcount; pass++)
            {
                //set the pass number
                Calculations.Thispassnumber = pass;
                var dist = 0;
                for (var a = 0; a < threads; a++)
                {
                    var ti = new ThreadInfo(dist, dist + pixeldistance, 0, maxh);

                    var t = new Thread(Calculations.ApplyMain);
                    dist += pixeldistance;
                    t.Start(ti);
                }

                var events = 0;
                while (Calculations.Threadfincount < threads)
                {
                    Thread.Sleep(100);
                    events++;
                    if (events >= 10)
                    {
                        events = 0;
                        Application.DoEvents();
                    }
                }
                Calculations.Threadfincount = 0;
            }

            Marshal.Copy(outputvalues, 0, outputBitmapData.Scan0, bys);
            outputBitmap.UnlockBits(outputBitmapData);

            Image ni = outputBitmap;

            LoadImageIntoTabPage("", ni);

            progressbar.Value = 0;

            //DateTime time2 = DateTime.Now;
            //var ts = time2 - time;
            //MessageBox.Show("seconds:" + TS.TotalSeconds);
            if (showPopupWhenAlgorithmsCompleteToolStripMenuItem.Checked)
            {
                ShowBalloon();
            }
        }

        public void IncreaseProgress()
        {
            progressbar.Value++;
        }

        private void LoadImageIntoTabPage(String filenameIN, Image i = null)
        {
            if (string.IsNullOrEmpty(filenameIN) == false && File.Exists(filenameIN) == false)
                return;

            var filename = Calculations.Imageimage + ImagePanels.Count.ToString();

            //create new tabpage and panel
            var newTP = new TabPage(filename);
            var p = new Panel { BackgroundImageLayout = ImageLayout.Zoom, Name = filename, Dock = DockStyle.Fill };

            var newICL = new ImagePanel { output = p };

            if (i != null)
            {
                newICL.I = i;
                p.BackgroundImage = newICL.I;
            }

            else
            {
                if (LoadImage(ref newICL, filenameIN) == false)
                    return;
            }

            ImagePanels.Add(ImagePanels.Count, newICL);
            maintabcontrol.TabPages.Add(newTP);

            newTP.Controls.Add(p);
        }

        private void LoadimagebuttonClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { Title = "Select image to load", InitialDirectory = BaseDirectoryAbsPath };
            var dr = ofd.ShowDialog();
            if (dr != DialogResult.OK)
                return;

            LoadImageIntoTabPage(ofd.FileName);
        }

        private void ShowBalloon()
        {
            notifyIcon1.BalloonTipText = "Algorithm Has Finished Execution2";
            notifyIcon1.Text = "Algorithm Has Finished Execution";
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(3000);
        }

        private void CloseTabToolStripMenuItemClick(object sender, EventArgs e)
        {
            var tp = maintabcontrol.Tag as TabPage;
            if (tp == null)
                return;

            if (tp.Text.StartsWith(Calculations.Imageimage) == false)
                return;

            RemoveTabPageAndImage(tp);
        }

        private void RemoveTabPageAndImage(TabPage tp)
        {
            var index = int.Parse(tp.Text.Substring(Calculations.Imageimage.Length));
            var p = tp.Controls[0] as Panel;

            //move images up
            var a = index;
            while (ImagePanels.ContainsKey(++a))
            {
                var i = ImagePanels[a];

                var newn = Calculations.Imageimage + (a - 1).ToString();
                ImagePanels[a - 1] = ImagePanels[a];
                ImagePanels.Remove(a);

                i.output.Parent.Text = newn;
            }

            RemoveICL(p);
            maintabcontrol.TabPages.Remove(tp);
            maintabcontrol.SelectedIndex = maintabcontrol.TabPages.Count - 1;
        }

        private void RemoveICL(Panel p)
        {
            var a = 0;
            var index = -1;
            foreach (var i in ImagePanels)
            {
                if (i.Value.output.Equals(p))
                {
                    index = a;
                    break;
                }
                a++;
            }

            if (index == -1)
                return;
            ImagePanels.Remove(index);
        }


        private void SaveImageToolStripMenuItemClick(object sender, EventArgs e)
        {
            //get current tab page and panel
            var tp = maintabcontrol.Tag as TabPage;
            if (tp == null)
                return;

            if (tp.Controls[0] is Panel == false)
                return;
            var p = tp.Controls[0] as Panel;

            //get the ImagePanel control
            var foundicl = (from thisicl in ImagePanels where thisicl.Value.output == p select thisicl.Value).FirstOrDefault();
            if (foundicl == null)
                return;

            var sfd = new SaveFileDialog
            {
                InitialDirectory = BaseDirectoryAbsPath,
                Filter = "PNG Image|*.png",
                AddExtension = true,
                FileName = foundicl.output.Text
            };

            var dr = sfd.ShowDialog();
            if (dr != DialogResult.OK)
                return;
            foundicl.I.Save(sfd.FileName, ImageFormat.Png);
        }

        private void FEbuttonClick1(object sender, EventArgs e)
        {
            var fe = Formulas.Count > 0 ? new FormulaEditor(BaseDirectoryAbsPath, this, Formulas) : new FormulaEditor(BaseDirectoryAbsPath, this);
            fe.ShowDialog();

            if (fe.isSet)
            {
                Formulas = fe.formulas;
            }
            //reload fast formulas
            LoadFastFormulas();
        }


        private void LoadFastFormula()
        {
            if (fastformulaCB.Items.Count == 0 || fastformulaCB.Text.Length == 0)
                return;

            Formulas.Clear();
            var path = "";
            foreach (var s in Directory.GetFiles(FormulaFolderAbsPath))
            {
                if (s.EndsWith("\\" + fastformulaCB.Text))
                {
                    path = s;
                    break;
                }
            }
            if (String.IsNullOrEmpty(path))
                return;
            var listf = Formula.Deserialise(path);
            foreach (var f in listf)
            {
                Formulas.Add(f);
            }
        }

        private void ApplyformulabuttonClick(object sender, EventArgs e)
        {
            ApplyFormula();
        }

        private void MaintabcontrolMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            // iterate through all the tab pages
            for (var i = 0; i < maintabcontrol.TabCount; i++)
            {
                // get their rectangle area and check if it contains the mouse cursor
                var r = maintabcontrol.GetTabRect(i);
                if (r.Contains(e.Location))
                {
                    if (maintabcontrol.TabPages[i].Text.StartsWith(Calculations.Imageimage) == false)
                        return;
                    // show the context menu here
                    maintabcontrol.Tag = maintabcontrol.TabPages[i];
                    tabrclick.Show(maintabcontrol.TabPages[i], e.Location);
                }
            }
        }

        private void CloseAllTabsToolStripMenuItemClick(object sender, EventArgs e)
        {
            ImagePanels = new Dictionary<int, ImagePanel>();
            while (maintabcontrol.TabPages.Count > 1)
                maintabcontrol.TabPages.RemoveAt(1);
        }

        private void ShowHistogramToolStripMenuItemClick(object sender, EventArgs e)
        {
            var name = ((TabPage)maintabcontrol.Tag).Text;
            var index = int.Parse(name.Substring(Calculations.Imageimage.Length));
            var hg = new histogram(this, index);
            hg.ShowDialog();
        }

        private void ShowPopupWhenAlgorithmsCompleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            showPopupWhenAlgorithmsCompleteToolStripMenuItem.Checked = !showPopupWhenAlgorithmsCompleteToolStripMenuItem.Checked;
        }

        private void threadCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextboxExtras.HandleInput(TextboxExtras.InputType.Create(false, true, false, false), e.KeyChar,
                                 threadCB);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var lc = new List<Control>();
            lc.Add(fastformulaCB);
            lc.Add(threadCB);

            var tsi = new List<ToolStripItem>();
            tsi.Add(showPopupWhenAlgorithmsCompleteToolStripMenuItem);

            FormConfigRestore.SaveConfig(this, ConfigFile, lc, tsi);
        }

        private void loadfastformulaB_Click(object sender, EventArgs e)
        {
            LoadFastFormula();
        }

    }
}
