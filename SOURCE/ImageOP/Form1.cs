using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ANDREICSLIB;
using ImageOP.ServiceReference1;

namespace ImageOP
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
		public List<formula> Formulas = new List<formula>();
		//private String _rootFolder = "";
		//all the currently opened images
		public Dictionary<int, ICL> ImagePanels = new Dictionary<int, ICL>();

        #region licensing
        private const string AppTitle = "Image Scripter";
        private const double AppVersion = 0.5;
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
        
		private void loadImage(ref ICL I, String path)
		{
			if (File.Exists(path) == false)
				return;
			I.I = Image.FromFile(path);
			I.output.BackgroundImage = I.I;
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
		    FormulaFolderAbsPath = BaseDirectoryAbsPath + "\\" + Formulafolder+"\\";

		    //ensure there is a formulas folder
			if (Directory.Exists(Formulafolder) == false)
				Directory.CreateDirectory(Formulafolder);

            //get the logical processor count by default
            var th = Environment.ProcessorCount;
            threadCB.Items.Add(th.ToString());
            threadCB.Text = th.ToString();

			LoadFastFormulas();
            LoadConfig();
            Licensing.CreateLicense(this, menuStrip1, new Licensing.SolutionDetails(GetDetails, HelpString, AppTitle, AppVersion, OtherText));
          
		}

        public Licensing.DownloadedSolutionDetails GetDetails()
        {
            try
            {
                var sr = new ServicesClient();
                var ti = sr.GetTitleInfo(AppTitle);
                if (ti == null)
                    return null;
                return ToDownloadedSolutionDetails(ti);

            }
            catch (Exception)
            {
            }
            return null;
        }

        public static Licensing.DownloadedSolutionDetails ToDownloadedSolutionDetails(TitleInfoServiceModel tism)
        {
            return new Licensing.DownloadedSolutionDetails()
            {
                ZipFileLocation = tism.LatestTitleDownloadPath,
                ChangeLog = tism.LatestTitleChangelog,
                Version = tism.LatestTitleVersion
            };
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
						if (int.Parse(f.operations[index]) > diam)
							diam = int.Parse(f.operations[index]);
					}
				}
			}
			catch
			{
				return -1;
			}
			return diam;
		}
		/*
		private int GetLargestNumber(String type, String subtype, String subsubtype, int subsubtypeindex, int index)
		{
			int diam = -1;
			try
			{
				foreach (formula f in Formulas)
				{
					if (f.type.Equals(type) && f.subtype.Equals(subtype))
					{
						if (f.operations[1].Equals(subsubtype))
						{
							if (int.Parse(f.operations[index]) > diam)
								diam = int.Parse(f.operations[index]);
						}
					}
				}
			}
			catch
			{
			}
			return diam;
		}
		*/

		private void TrimFormulas()
		{
			foreach (var f in Formulas)
			{
				f.skip = false;
				if (f.type == calculations.Commentop)
					f.skip = true;
			}
		}

		private void ApplyFormula()
		{
			if (calculations.Threadfincount > 0)
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
			var error = calculations.FormulaChecks(Formulas, ImagePanels);
			if (string.IsNullOrEmpty(error) == false)
			{
				MessageBox.Show(error, "Formula Error!");
				return;
			}

			var imlist = new Dictionary<int, im>();

			int maxw = 0, maxh = 0;
			var az = 0;
			var pf = PixelFormat.DontCare;
			foreach (var ic in ImagePanels)
			{
				var newim = new im(ic.Value);
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
			var pixelsto = new im
			               	{
			               		Array = outputvalues,
			               		Format = outputBitmapData.PixelFormat,
			               		Height = outputBitmap.Height,
			               		Width = outputBitmap.Width,
			               		Scan0 = outputBitmapData.Scan0,
			               		Stride = outputBitmapData.Stride
			               	};

			var i = new information { imlist = imlist, pixelsTo = pixelsto, maxw = maxw, maxh = maxh };

			calculations.Initcalculations(Formulas, ref i);

			//get the custom matricies
			if (calculations.GetCustomMatricies(Formulas) == false)
				return;

			//link the variables to their array
			calculations.SetImageLocations();

			//get max pass count
			var passcount = GetLargestNumber(calculations.Passoperation, "", 0);
			//if there is no pass, then we just want 1
			if (passcount == -1)
				passcount = 1;

			//set this form
			calculations.Baseform = this;

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
				calculations.Thispassnumber = pass;
				var dist = 0;
				for (var a = 0; a < threads; a++)
				{
					var ti = new threadinfo(dist, dist + pixeldistance, 0, maxh);

					var t = new Thread(calculations.ApplyMain);
					dist += pixeldistance;
					t.Start(ti);
				}

				var events = 0;
				while (calculations.Threadfincount < threads)
				{
					Thread.Sleep(100);
					events++;
					if (events >= 10)
					{
						events = 0;
						Application.DoEvents();
					}
				}
				calculations.Threadfincount = 0;
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

			var filename = calculations.Imageimage + ImagePanels.Count.ToString();

			//create new tabpage and panel
			var newTP = new TabPage(filename);
			var p = new Panel {BackgroundImageLayout = ImageLayout.Zoom, Name = filename,Dock = DockStyle.Fill};

			var newICL = new ICL {output = p};

			ImagePanels.Add(ImagePanels.Count, newICL);
			maintabcontrol.TabPages.Add(newTP);
			if (i != null)
			{
				newICL.I = i;
				p.BackgroundImage = newICL.I;
			}

			else
				loadImage(ref newICL, filenameIN);

			newTP.Controls.Add(p);
		}
        
		private void LoadimagebuttonClick(object sender, EventArgs e)
		{
			var ofd = new OpenFileDialog {Title = "Select image to load", InitialDirectory = BaseDirectoryAbsPath};
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

			if (tp.Text.StartsWith(calculations.Imageimage) == false)
				return;

			var index = int.Parse(tp.Text.Substring(calculations.Imageimage.Length));
			var p = tp.Controls[0] as Panel;

			//move images up
			var a = index;
			while (ImagePanels.ContainsKey(++a))
			{
				var i = ImagePanels[a];

				var newn = calculations.Imageimage + (a - 1).ToString();
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

			//get the ICL control
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
			var listf = formula.deserialise(path);
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
					if (maintabcontrol.TabPages[i].Text.StartsWith(calculations.Imageimage) == false)
						return;
					// show the context menu here
					maintabcontrol.Tag = maintabcontrol.TabPages[i];
					tabrclick.Show(maintabcontrol.TabPages[i], e.Location);
				}
			}
		}

		private void CloseAllTabsToolStripMenuItemClick(object sender, EventArgs e)
		{
			ImagePanels = new Dictionary<int, ICL>();
			while (maintabcontrol.TabPages.Count > 1)
				maintabcontrol.TabPages.RemoveAt(1);
		}

		private void ShowHistogramToolStripMenuItemClick(object sender, EventArgs e)
		{
			var name = ((TabPage)maintabcontrol.Tag).Text;
			var index = int.Parse(name.Substring(calculations.Imageimage.Length));
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
