namespace ImageScripter
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPopupWhenAlgorithmsCompleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.progressbar = new System.Windows.Forms.ToolStripProgressBar();
            this.mainpage = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.threadCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.applyformulaB = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.formulaEditorB = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.fastformulaCB = new System.Windows.Forms.ComboBox();
            this.loadfastformulaB = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadimageB = new System.Windows.Forms.Button();
            this.maintabcontrol = new System.Windows.Forms.TabControl();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabrclick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.mainpage.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.maintabcontrol.SuspendLayout();
            this.tabrclick.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(581, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPopupWhenAlgorithmsCompleteToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // showPopupWhenAlgorithmsCompleteToolStripMenuItem
            // 
            this.showPopupWhenAlgorithmsCompleteToolStripMenuItem.Name = "showPopupWhenAlgorithmsCompleteToolStripMenuItem";
            this.showPopupWhenAlgorithmsCompleteToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.showPopupWhenAlgorithmsCompleteToolStripMenuItem.Text = "Show popup when algorithms complete";
            this.showPopupWhenAlgorithmsCompleteToolStripMenuItem.Click += new System.EventHandler(this.ShowPopupWhenAlgorithmsCompleteToolStripMenuItemClick);
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressbar});
            this.statusbar.Location = new System.Drawing.Point(0, 481);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(581, 22);
            this.statusbar.TabIndex = 6;
            this.statusbar.Text = "statusStrip1";
            // 
            // progressbar
            // 
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(100, 16);
            // 
            // mainpage
            // 
            this.mainpage.Controls.Add(this.groupBox5);
            this.mainpage.Controls.Add(this.groupBox2);
            this.mainpage.Controls.Add(this.groupBox1);
            this.mainpage.Location = new System.Drawing.Point(4, 22);
            this.mainpage.Name = "mainpage";
            this.mainpage.Padding = new System.Windows.Forms.Padding(3);
            this.mainpage.Size = new System.Drawing.Size(573, 431);
            this.mainpage.TabIndex = 0;
            this.mainpage.Text = "Main";
            this.mainpage.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.threadCB);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.applyformulaB);
            this.groupBox5.Location = new System.Drawing.Point(22, 245);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(559, 88);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Execution Of Algorithm";
            // 
            // threadCB
            // 
            this.threadCB.FormattingEnabled = true;
            this.threadCB.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.threadCB.Location = new System.Drawing.Point(16, 42);
            this.threadCB.Name = "threadCB";
            this.threadCB.Size = new System.Drawing.Size(121, 21);
            this.threadCB.TabIndex = 11;
            this.threadCB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.threadCB_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Threads";
            // 
            // applyformulaB
            // 
            this.applyformulaB.Location = new System.Drawing.Point(163, 42);
            this.applyformulaB.Name = "applyformulaB";
            this.applyformulaB.Size = new System.Drawing.Size(89, 23);
            this.applyformulaB.TabIndex = 6;
            this.applyformulaB.Text = "Apply Formula";
            this.applyformulaB.UseVisualStyleBackColor = true;
            this.applyformulaB.Click += new System.EventHandler(this.ApplyformulabuttonClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.splitter1);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(8, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 119);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loading A Formula";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.formulaEditorB);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(208, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 100);
            this.panel2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Load or edit a loaded formula";
            // 
            // formulaEditorB
            // 
            this.formulaEditorB.Location = new System.Drawing.Point(9, 51);
            this.formulaEditorB.Name = "formulaEditorB";
            this.formulaEditorB.Size = new System.Drawing.Size(151, 23);
            this.formulaEditorB.TabIndex = 4;
            this.formulaEditorB.Text = "Open Formula Editor";
            this.formulaEditorB.UseVisualStyleBackColor = true;
            this.formulaEditorB.Click += new System.EventHandler(this.FEbuttonClick1);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Silver;
            this.splitter1.Location = new System.Drawing.Point(203, 16);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 100);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.fastformulaCB);
            this.panel1.Controls.Add(this.loadfastformulaB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Load Saved Formula:";
            // 
            // fastformulaCB
            // 
            this.fastformulaCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fastformulaCB.FormattingEnabled = true;
            this.fastformulaCB.Location = new System.Drawing.Point(9, 27);
            this.fastformulaCB.Name = "fastformulaCB";
            this.fastformulaCB.Size = new System.Drawing.Size(185, 21);
            this.fastformulaCB.TabIndex = 7;
            // 
            // loadfastformulaB
            // 
            this.loadfastformulaB.Location = new System.Drawing.Point(9, 51);
            this.loadfastformulaB.Name = "loadfastformulaB";
            this.loadfastformulaB.Size = new System.Drawing.Size(185, 23);
            this.loadfastformulaB.TabIndex = 9;
            this.loadfastformulaB.Text = "Load Formula";
            this.loadfastformulaB.UseVisualStyleBackColor = true;
            this.loadfastformulaB.Click += new System.EventHandler(this.loadfastformulaB_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.loadimageB);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 59);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loading Images";
            // 
            // loadimageB
            // 
            this.loadimageB.Location = new System.Drawing.Point(6, 19);
            this.loadimageB.Name = "loadimageB";
            this.loadimageB.Size = new System.Drawing.Size(106, 23);
            this.loadimageB.TabIndex = 5;
            this.loadimageB.Text = "Load Image";
            this.loadimageB.UseVisualStyleBackColor = true;
            this.loadimageB.Click += new System.EventHandler(this.LoadimagebuttonClick);
            // 
            // maintabcontrol
            // 
            this.maintabcontrol.Controls.Add(this.mainpage);
            this.maintabcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maintabcontrol.Location = new System.Drawing.Point(0, 24);
            this.maintabcontrol.Name = "maintabcontrol";
            this.maintabcontrol.SelectedIndex = 0;
            this.maintabcontrol.Size = new System.Drawing.Size(581, 457);
            this.maintabcontrol.TabIndex = 7;
            this.maintabcontrol.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MaintabcontrolMouseClick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // tabrclick
            // 
            this.tabrclick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageToolStripMenuItem,
            this.closeTabToolStripMenuItem,
            this.closeAllTabsToolStripMenuItem,
            this.showHistogramToolStripMenuItem});
            this.tabrclick.Name = "tabrclick";
            this.tabrclick.Size = new System.Drawing.Size(163, 92);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.SaveImageToolStripMenuItemClick);
            // 
            // closeTabToolStripMenuItem
            // 
            this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
            this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.closeTabToolStripMenuItem.Text = "Close Tab";
            this.closeTabToolStripMenuItem.Click += new System.EventHandler(this.CloseTabToolStripMenuItemClick);
            // 
            // closeAllTabsToolStripMenuItem
            // 
            this.closeAllTabsToolStripMenuItem.Name = "closeAllTabsToolStripMenuItem";
            this.closeAllTabsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.closeAllTabsToolStripMenuItem.Text = "Close All Tabs";
            this.closeAllTabsToolStripMenuItem.Click += new System.EventHandler(this.CloseAllTabsToolStripMenuItemClick);
            // 
            // showHistogramToolStripMenuItem
            // 
            this.showHistogramToolStripMenuItem.Name = "showHistogramToolStripMenuItem";
            this.showHistogramToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.showHistogramToolStripMenuItem.Text = "Show Histogram";
            this.showHistogramToolStripMenuItem.Click += new System.EventHandler(this.ShowHistogramToolStripMenuItemClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 503);
            this.Controls.Add(this.maintabcontrol);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusbar);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.mainpage.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.maintabcontrol.ResumeLayout(false);
            this.tabrclick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusbar;
		public System.Windows.Forms.ToolStripProgressBar progressbar;
		private System.Windows.Forms.TabPage mainpage;
		private System.Windows.Forms.Button loadimageB;
		private System.Windows.Forms.ComboBox threadCB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox fastformulaCB;
		private System.Windows.Forms.Button applyformulaB;
		private System.Windows.Forms.Button formulaEditorB;
		private System.Windows.Forms.TabControl maintabcontrol;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ContextMenuStrip tabrclick;
		private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem closeAllTabsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showHistogramToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showPopupWhenAlgorithmsCompleteToolStripMenuItem;
        private System.Windows.Forms.Button loadfastformulaB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
	}
}

