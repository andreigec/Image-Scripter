namespace ImageOP
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
            this.applyformulabutton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fastformulaCB = new System.Windows.Forms.ComboBox();
            this.FEbutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadimagebutton = new System.Windows.Forms.Button();
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
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
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
            this.statusbar.Location = new System.Drawing.Point(0, 463);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(760, 22);
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
            this.mainpage.Size = new System.Drawing.Size(752, 413);
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
            this.groupBox5.Controls.Add(this.applyformulabutton);
            this.groupBox5.Location = new System.Drawing.Point(8, 178);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(738, 88);
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
            // applyformulabutton
            // 
            this.applyformulabutton.Location = new System.Drawing.Point(163, 42);
            this.applyformulabutton.Name = "applyformulabutton";
            this.applyformulabutton.Size = new System.Drawing.Size(89, 23);
            this.applyformulabutton.TabIndex = 6;
            this.applyformulabutton.Text = "Apply Formula";
            this.applyformulabutton.UseVisualStyleBackColor = true;
            this.applyformulabutton.Click += new System.EventHandler(this.ApplyformulabuttonClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.fastformulaCB);
            this.groupBox2.Controls.Add(this.FEbutton);
            this.groupBox2.Location = new System.Drawing.Point(8, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(738, 76);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loading A Formula";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Load Saved Formula:";
            // 
            // fastformulaCB
            // 
            this.fastformulaCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fastformulaCB.FormattingEnabled = true;
            this.fastformulaCB.Location = new System.Drawing.Point(12, 40);
            this.fastformulaCB.Name = "fastformulaCB";
            this.fastformulaCB.Size = new System.Drawing.Size(121, 21);
            this.fastformulaCB.TabIndex = 7;
            this.fastformulaCB.SelectedIndexChanged += new System.EventHandler(this.FastformulaCbSelectedIndexChanged);
            // 
            // FEbutton
            // 
            this.FEbutton.Location = new System.Drawing.Point(161, 38);
            this.FEbutton.Name = "FEbutton";
            this.FEbutton.Size = new System.Drawing.Size(151, 23);
            this.FEbutton.TabIndex = 4;
            this.FEbutton.Text = "Open Formula Editor";
            this.FEbutton.UseVisualStyleBackColor = true;
            this.FEbutton.Click += new System.EventHandler(this.FEbuttonClick1);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.loadimagebutton);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 59);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loading Images";
            // 
            // loadimagebutton
            // 
            this.loadimagebutton.Location = new System.Drawing.Point(6, 19);
            this.loadimagebutton.Name = "loadimagebutton";
            this.loadimagebutton.Size = new System.Drawing.Size(106, 23);
            this.loadimagebutton.TabIndex = 5;
            this.loadimagebutton.Text = "Load Image";
            this.loadimagebutton.UseVisualStyleBackColor = true;
            this.loadimagebutton.Click += new System.EventHandler(this.LoadimagebuttonClick);
            // 
            // maintabcontrol
            // 
            this.maintabcontrol.Controls.Add(this.mainpage);
            this.maintabcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maintabcontrol.Location = new System.Drawing.Point(0, 24);
            this.maintabcontrol.Name = "maintabcontrol";
            this.maintabcontrol.SelectedIndex = 0;
            this.maintabcontrol.Size = new System.Drawing.Size(760, 439);
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
            this.ClientSize = new System.Drawing.Size(760, 485);
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
            this.groupBox2.PerformLayout();
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
		private System.Windows.Forms.Button loadimagebutton;
		private System.Windows.Forms.ComboBox threadCB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox fastformulaCB;
		private System.Windows.Forms.Button applyformulabutton;
		private System.Windows.Forms.Button FEbutton;
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
	}
}

