using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ANDREICSLIB.ClassExtras;
using ANDREICSLIB.ClassReplacements;
using ANDREICSLIB.Helpers;

namespace ImageScripter
{
    public partial class FormulaEditor : Form
    {
        public Form1 baseform;
        public List<Formula> formulas = new List<Formula>();
        public bool isSet;

        private string rootFolder = "";

        //drag ops
        private static PanelReplacement dragging;
        private static PanelReplacement dragparent;
        private static bool IsDragging;

        public static Image gripimage = null;
        public const string grippath = "grip.png";

        public FormulaEditor(String rootFolders, Form1 baseform1)
        {
            init(rootFolders, baseform1);
        }

        public FormulaEditor(String rootFolders, Form1 baseform1, List<Formula> f)
        {
            init(rootFolders, baseform1);
            try
            {
                Formula.Deserialise(f, ref formulapanel);
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading file");
                Clear();
            }
        }

        private void init(String rootFolders, Form1 baseform1)
        {
            InitializeComponent();

            if (gripimage == null)
                gripimage = EmbeddedResources.ReadEmbeddedImage(grippath);

            baseform = baseform1;
            rootFolder = rootFolders;
            setFormulaStrings();
            formulatype.SelectedIndex = 0;
            isSet = false;
        }

        private static void varlocation(ref PanelReplacement PU, bool addall = true)
        {
            var CB = new ComboBox();
            CB.Items.Add(Calculations.RedOP);
            CB.Items.Add(Calculations.GreenOP);
            CB.Items.Add(Calculations.BlueOP);
            if (addall)
                CB.Items.Add(Calculations.AllOP);
            CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CB.SelectedIndex = 0;
            PU.AddControl(CB, true);
        }

        private static void addclosebutton(ref PanelReplacement PU)
        {
            var B = new Button();
            ObjectExtras.AddToolTip(B, "Click here to remove this formula");
            B.Click += B_Click;
            B.Text = "X";
            B.Size = new Size(20, 20);
            B.BackColor = Color.Red;
            B.ForeColor = Color.White;
            PU.AddControl(B, true);
        }

        private static void addMatrixEditorButton(ref PanelReplacement PU, Control textField = null)
        {
            var B = new Button();
            //ObjectUpdates.addToolTip(B, "Click here to edit matrix using editor");
            B.Click += B_Click2;
            B.Text = "?";
            B.Size = new Size(20, 20);
            //B.BackColor = Color.;
            //B.ForeColor = Color.White;
            if (textField != null)
                B.Tag = textField.Name;
            PU.AddControl(B, true);
        }

        private static int getI(PanelReplacement U2, String name)
        {
            var index = -1;
            var count = 0;
            foreach (Control C in U2.Controls)
            {
                if (C.Name.Equals(name))
                {
                    index = count;
                    break;
                }
                count++;
            }
            return index;
        }

        private static bool SwitchControls(PanelReplacement control, bool up)
        {
            var U2 = ((PanelReplacement)control.Parent);
            var F = ((FormulaEditor)U2.Parent);

            if (F == null)
                return false;

            //get index of this item

            var index = getI(U2, control.Name);
            if ((index == 0 && up) || (index == U2.Controls.Count - 1 && up == false))
                return false;

            var newindex = index;
            if (up)
                newindex--;
            else
                newindex++;

            ListExtras.Swap(ref F.formulas, index, newindex);
            U2.SwitchControlLocations(index, newindex);
            return true;
        }
        /*
		private static void B_moveUP(object sender, EventArgs e)
		{
			var shift = false;// KeyboardInfo.isPressed(Keys.Shift);
			var success = true;
			var B = ((Button)sender);
			//name of the panel we want to move
			var U = ((PanelReplacement)B.Parent);
			while (success)
			{
				success = SwitchControls(U, true);
				if (shift == false)
					break;
			}
		}

		private static void B_moveDOWN(object sender, EventArgs e)
		{
			var shift = false;// KeyboardInfo.isPressed(Keys.Shift);
			var success = true;
			var B = ((Button)sender);
			//name of the panel we want to move
			var U = ((PanelReplacement)B.Parent);
			while (success)
			{
			success=SwitchControls(U, false);
			if (shift == false)
				break;
			}
	}
        */
        public static bool isUsableControl(Control C)
        {
            return !(C is Button || C is Label || C is Panel);
        }

        public static void PanelMD(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            dragging = ((PanelReplacement)((Panel)sender).Parent);
            dragparent = dragging.Parent as PanelReplacement;
            IsDragging = true;
        }

        public static void PanelMU(object sender, MouseEventArgs e)
        {
            dragging = null;
            dragparent = null;
            IsDragging = false;
        }

        private static void P_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging == false)
                return;
            var ey = e.Y + dragging.Location.Y;

            //check pos in regards to panels adjacent to dragging one
            var dragindex = getI(dragparent, dragging.Name);
            if ((dragindex == 0 && ey < dragging.Location.Y) ||
                (dragindex == dragparent.Controls.Count && ey > dragging.Location.Y))
                return;
            if (ey < dragging.Location.Y)
                SwitchControls(dragging, true);
            else if (ey > dragging.Location.Y + dragging.Height)
                SwitchControls(dragging, false);
        }

        private static void addMoveArrows(ref PanelReplacement PU)
        {
            var P = new Panel();
            P.Size = new Size(PU.Height, PU.Height);
            P.BackgroundImageLayout = ImageLayout.Center;
            P.BackgroundImage = gripimage;
            P.Cursor = Cursors.SizeAll;
            P.MouseDown += PanelMD;
            P.MouseUp += PanelMU;
            P.MouseMove += P_MouseMove;
            PU.AddControl(P, true);
        }

        private static void addvariablesCB(ref PanelReplacement PU, bool noVariables = false)
        {
            var add = Calculations.GetVarList(noVariables);

            var CB = new ComboBox();
            foreach (var s in add)
            {
                CB.Items.Add(s);
            }

            CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CB.SelectedIndex = 0;
            PU.AddControl(CB, true);
        }

        private static void addLabel(String textl, ref PanelReplacement PU)
        {
            var L = new Label();
            L.Text = textl;
            //L.Size = new System.Drawing.Size(10, 10);
            if (L.Text.Length < 10)
                L.Size = new Size(7 * L.Text.Length, 20);
            else
                L.Size = new Size(5 * L.Text.Length, 20);

            L.AutoSize = true;

            PU.AddControl(L, true);
        }

        private static void addNumbers(ref PanelReplacement PU, List<int> possibilities)
        {
            var CB = new ComboBox();
            foreach (var i in possibilities)
            {
                CB.Items.Add(i.ToString());
            }

            if (CB.Items.Count > 0)
                CB.SelectedIndex = 0;
            PU.AddControl(CB, true);
        }

        private static Control addStrings(ref PanelReplacement PU, List<String> possibilities)
        {
            var CB = new ComboBox();
            foreach (var i in possibilities)
            {
                CB.Items.Add(i);
            }

            if (CB.Items.Count > 0)
                CB.SelectedIndex = 0;
            PU.AddControl(CB, true);
            return CB;
        }

        private static void addCommentLine(ref PanelReplacement PU)
        {
            var TB = new TextBox();
            TB.Width = 600;
            PU.AddControl(TB, true);
        }

        private static void addPassLine(ref PanelReplacement PU)
        {
            addLabel("The following will only be executed on pass number:", ref PU);

            addNumbers(ref PU, new List<int> { 1, 2, 3 });
        }

        private static void addSwapLine(ref PanelReplacement PU)
        {
            addLabel("move", ref PU);

            //source
            addvariablesCB(ref PU);

            varlocation(ref PU, false);

            addLabel("to", ref PU);

            //destination
            addvariablesCB(ref PU);

            varlocation(ref PU);
        }
        private static void addMoveLine(ref PanelReplacement PU)
        {
            addLabel("move", ref PU);

            //source
            addvariablesCB(ref PU);

            addLabel("to", ref PU);

            //destination
            addvariablesCB(ref PU);
        }

        private static void AddCustomNHOperation(ref PanelReplacement PU)
        {
            addLabel("Apply Matrix:", ref PU);

            //serialised matrix, rows separated by .
            var C = addStrings(ref PU, new List<String> { "", Calculations.Custom1, Calculations.Custom2, Calculations.Custom3 });

            //matrix editor button
            addMatrixEditorButton(ref PU, C);

            addLabel("from", ref PU);
            addvariablesCB(ref PU, true);

            addLabel("from", ref PU);
            varlocation(ref PU);

            addLabel("to", ref PU);
            addvariablesCB(ref PU);
        }

        private static void AddPresetNHOperation(ref PanelReplacement PU)
        {
            addLabel("from current pixel diameter:", ref PU);

            addNumbers(ref PU, new List<int> { 1, 2, 5 });

            addLabel("take the", ref PU);

            var cb = new ComboBox();
            cb.Items.Add(Calculations.MeanAverage);
            cb.Items.Add(Calculations.MedianAverage);
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.SelectedIndex = 0;
            PU.AddControl(cb, true);

            addLabel("from", ref PU);
            addvariablesCB(ref PU, true);

            addLabel("from", ref PU);
            varlocation(ref PU);

            addLabel("to", ref PU);
            addvariablesCB(ref PU);
        }

        private static void addOperations(ref PanelReplacement PU)
        {
            //pixel operations
            var CB = new ComboBox();
            CB.Items.Add(Calculations.Subtractop);
            CB.Items.Add(Calculations.Addop);
            CB.Items.Add(Calculations.Multiplyop);
            CB.Items.Add(Calculations.Divideop);
            CB.Items.Add(Calculations.Modulusop);
            CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CB.SelectedIndex = 0;
            PU.AddControl(CB, true);
        }

        private static void AddUserPixelOperationline(ref PanelReplacement PU)
        {
            addLabel("from", ref PU);

            addvariablesCB(ref PU);

            addOperations(ref PU);

            var TB = new TextBox();
            TB.KeyPress += handlefloatinput;
            PU.AddControl(TB, true);

            addLabel("from", ref PU);

            varlocation(ref PU);

            addLabel("to", ref PU);

            addvariablesCB(ref PU);
        }

        private static void AddVarPixelOperationline(ref PanelReplacement PU)
        {
            addLabel("from", ref PU);

            addvariablesCB(ref PU);

            addOperations(ref PU);

            addvariablesCB(ref PU);

            varlocation(ref PU);

            addLabel("to", ref PU);

            addvariablesCB(ref PU);
        }

        private static void addComparisons(ref PanelReplacement PU)
        {
            var CB = new ComboBox();
            CB.Items.Add(Calculations.LTop);
            CB.Items.Add(Calculations.LEop);
            CB.Items.Add(Calculations.EQop);
            CB.Items.Add(Calculations.GEop);
            CB.Items.Add(Calculations.GTop);
            CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CB.SelectedIndex = 0;
            PU.AddControl(CB, true);
        }

        private static void addIfPosConditionLine(ref PanelReplacement PU)
        {
            addLabel(Calculations.Ifposcondition, ref PU);

            var CB = new ComboBox();
            CB.Items.Add(Calculations.XPOS);
            CB.Items.Add(Calculations.YPOS);
            CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CB.SelectedIndex = 0;
            PU.AddControl(CB, true);

            CB = new ComboBox();
            CB.Items.Add(Calculations.PosPercent);
            CB.Items.Add(Calculations.PosPixels);
            CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CB.SelectedIndex = 0;
            PU.AddControl(CB, true);

            addLabel("is", ref PU);

            addComparisons(ref PU);

            var TB = new TextBox();
            TB.KeyPress += handlenumbersinput;
            PU.AddControl(TB, true);

            addLabel("then...", ref PU);
        }

        private static void addIfConditionLine(ref PanelReplacement PU)
        {
            addLabel(Calculations.Ifcolcondition, ref PU);

            addvariablesCB(ref PU);

            addLabel("value", ref PU);

            varlocation(ref PU);

            addLabel("is", ref PU);

            addComparisons(ref PU);

            var TB = new TextBox();
            TB.KeyPress += handlenumbersinput;
            PU.AddControl(TB, true);

            addLabel("then...", ref PU);
        }

        private static void addEndIfConditionLine(ref PanelReplacement PU)
        {
            var CB = new ComboBox();
            CB.Items.Add(Calculations.Endifcondition);
            CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CB.SelectedIndex = 0;
            PU.AddControl(CB, true);
        }

        private void addrowbutton_Click(object sender, EventArgs e)
        {
            formulas.Add(addline(ref formulapanel, formulatype.Text, subformulatype.Text));
        }

        private void subformulachange()
        {
            subformulatype.Items.Clear();
            //get the list of sub ops for this operation
            var subops = Calculations.operationdic[formulatype.Text];
            if (subops == null || subops.Count == 0)
                subformulatype.Enabled = false;
            else
            {
                subformulatype.Enabled = true;
                foreach (var s in subops)
                {
                    subformulatype.Items.Add(s);
                }
            }
            if (subformulatype.Items.Count > 0)
                subformulatype.SelectedIndex = 0;
        }

        private void formulatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            subformulachange();
        }

        private void loadformulas()
        {
            loadedformulas.Items.Clear();
            var init = rootFolder + "\\" + Form1.Formulafolder;

            foreach (var s in Directory.GetFiles(init))
            {
                if (s.EndsWith(Form1.Formulaextension))
                {
                    var LVI = new ListViewItem(s.Substring(s.LastIndexOf('\\') + 1));
                    LVI.Name = s;
                    loadedformulas.Items.Add(LVI);
                }
            }
        }

        private void setFormulaStrings()
        {
            //add all the operations
            foreach (var kvp in Calculations.operationdic)
            {
                formulatype.Items.Add(kvp.Key);
            }
        }

        private void FormulaEditor_Load(object sender, EventArgs e)
        {
            formulatype.Text = formulatype.Items[0].ToString();
            subformulachange();
            loadformulas();
        }

        private void saveformula_Click(object sender, EventArgs e)
        {
            var SFD = new SaveFileDialog();
            var init = rootFolder + "\\" + Form1.Formulafolder;
            SFD.InitialDirectory = init;
            SFD.Filter = "ImageOP Formula|*." + Form1.Formulaextension;
            SFD.AddExtension = true;
            var DR = SFD.ShowDialog();
            if (DR != DialogResult.OK)
                return;

            var FS = new FileStream(SFD.FileName, FileMode.Create);
            var SW = new StreamWriter(FS);

            var count = 0;
            foreach (var f in formulas)
            {
                var PU = formulapanel.Controls[count] as PanelReplacement;
                count++;
                SW.WriteLine("FSTART");
                if (f.Operations.Count == 0)
                    f.setoperations(ref PU);
                SW.Write(f.serialise());
                SW.WriteLine("FEND");
            }

            SW.Close();
            FS.Close();
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            formulapanel.ClearControls();
            formulas.Clear();
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            var count = 0;
            foreach (var f in formulas)
            {
                var PU = formulapanel.Controls[count] as PanelReplacement;
                count++;
                f.setoperations(ref PU);
            }
            isSet = true;
            Close();
        }

        private void loadformula_Click(object sender, EventArgs e)
        {
            if (loadedformulas.SelectedItems.Count != 1)
                return;

            var s = loadedformulas.SelectedItems[0].Name;
            try
            {
                Formula.Deserialise(s, ref formulapanel);
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading file");
                Clear();
            }
        }

        private void Clear()
        {
            formulas.Clear();
            formulapanel.ClearControls();
        }

        private static void B_Click(object sender, EventArgs e)
        {
            var B = ((Button)sender);
            var U = ((PanelReplacement)B.Parent);
            var F = ((FormulaEditor)U.Parent.Parent);

            Formula fm = null;
            foreach (var f in F.formulas)
            {
                if (f.ID.Equals(U.Name))
                {
                    fm = f;
                    break;
                }
            }
            if (fm != null)
            {
                F.formulas.Remove(fm);
            }

            F.formulapanel.RemoveControl(U.Name);
        }

        private static void B_Click2(object sender, EventArgs e)
        {
            var B = ((Button)sender);
            var U = ((PanelReplacement)B.Parent);
            var C = U.GetControlByName(B.Tag as String);

            var ME = new matrixeditor(C.Text);
            ME.ShowDialog();
            if (string.IsNullOrEmpty(ME.result))
                return;

            ((ComboBox)C).Items.Add(ME.result);
            C.Text = ME.result;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static void handlefloatinput(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextboxExtras.HandleInput(TextboxExtras.InputType.Create(false, true, true, false), e.KeyChar);
        }

        private static void handlenumbersinput(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextboxExtras.HandleInput(TextboxExtras.InputType.Create(false, true, false, false), e.KeyChar);
        }

        public static Formula addline(ref PanelReplacement formulapanel, string type, string subtype)
        {
            var newPanel = new PanelReplacement();
            newPanel.BackColor = Color.FromArgb(200, 200, 200);
            newPanel.Size = new Size(formulapanel.Width, 25);

            //add move arrows
            addMoveArrows(ref newPanel);

            //operation
            if (type.Equals(Calculations.Moveoperation))
            {
                if (subtype.Equals(Calculations.Moveop))
                    addMoveLine(ref newPanel);
                else if (subtype.Equals(Calculations.Swapop))
                    addSwapLine(ref newPanel);
            }
            else if (type.Equals(Calculations.Operation))
            {
                if (subtype.Equals(Calculations.UserInputPixelOperation))
                    AddUserPixelOperationline(ref newPanel);
                else if (subtype.Equals(Calculations.VarInputPixelOperation))
                    AddVarPixelOperationline(ref newPanel);
                else if (subtype.Equals(Calculations.PresetNeighbourhoodOperations))
                    AddPresetNHOperation(ref newPanel);
                else if (subtype.Equals(Calculations.CustomNeighbourhoodOperations))
                    AddCustomNHOperation(ref newPanel);
            }
            else if (type.Equals(Calculations.Conditionoperation))
            {
                if (subtype.Equals(Calculations.Ifcolcondition))
                    addIfConditionLine(ref newPanel);
                else if (subtype.Equals(Calculations.Endifcondition))
                    addEndIfConditionLine(ref newPanel);
                else if (subtype.Equals(Calculations.Ifposcondition))
                    addIfPosConditionLine(ref newPanel);
            }
            else if (type.Equals(Calculations.Passoperation))
            {
                addPassLine(ref newPanel);
            }
            else if (type.Equals(Calculations.Commentop))
            {
                addCommentLine(ref newPanel);
            }
            //add remove button
            addclosebutton(ref newPanel);

            var C = formulapanel.AddControl(newPanel, false);
            var f = new Formula();
            f.type = type;
            f.subtype = subtype;
            f.ID = C.Name;

            //reset width here
            var last = newPanel.Controls[newPanel.Controls.Count - 1];
            newPanel.Size = new Size(last.Location.X + last.Width + 1, 25);
            return f;
        }

        private void helptextbutton_Click(object sender, EventArgs e)
        {

            var type = formulatype.Text;
            var subtype = subformulatype.Text;

            var helptitle = "Help for type:" + type + " subtype:" + subtype;
            var helptext = "";

            if (type.Equals(Calculations.Moveoperation))
            {
                if (subtype.Equals(Calculations.Moveop))
                    helptext = "Move a pixels RGB";
                else if (subtype.Equals(Calculations.Swapop))
                    helptext = "Move a pixels R,G or B separately";
            }
            else if (type.Equals(Calculations.Operation))
            {
                if (subtype.Equals(Calculations.UserInputPixelOperation))
                    helptext = "Perform an add,minus,divide,multiple or modulo operation with an inputted value";
                else if (subtype.Equals(Calculations.VarInputPixelOperation))
                    helptext = "Perform an add,minus,divide,multiple or modulo operation from another value";
                else if (subtype.Equals(Calculations.PresetNeighbourhoodOperations))
                    helptext = "Apply a preset neighbourhood operation, such as an average";
                else if (subtype.Equals(Calculations.CustomNeighbourhoodOperations))
                    helptext = "Apply a custom user neighbourhood operation";
            }
            else if (type.Equals(Calculations.Conditionoperation))
            {
                if (subtype.Equals(Calculations.Ifcolcondition))
                    helptext = "start an if block condition depending on a pixels value";
                else if (subtype.Equals(Calculations.Endifcondition))
                    helptext = "end an if block condition";
                else if (subtype.Equals(Calculations.Ifposcondition))
                    helptext = "start an if block condition depending on the location of the current pixel";
            }
            else if (type.Equals(Calculations.Passoperation))
            {
                helptext = "Wait until the next pass for the next operations to occur. Does not affect other pass operations";
            }
            else if (type.Equals(Calculations.Commentop))
            {
                helptext = "Add a comment that does not affect operation";
            }

            if (helptext.Length > 0)
                MessageBox.Show(helptext, helptitle, MessageBoxButtons.OK);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String ht =
                @"
When applying a formula, every pixel is run through in X/Y order applying the following operations.
For example, if you wanted to simply copy the input image, you would just put a move current pixel to the output pixel.

If you want to do multi pass operations, the same applies, but you would use a pass block. This ensures the following ops only work for a certain pass.
For example, if you want to add some red to each pixel, and then blur, you would use a user input pixel operation, then a pass block for pass 2, then a neighbourhood operation.";
            MessageBox.Show(ht, "Formula Editor Help", MessageBoxButtons.OK);
        }


    }

}