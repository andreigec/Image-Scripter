namespace ImageOP
{
	partial class histogram
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
			this.histimage = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.vlab = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.xlab = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.refresh = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.coloursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redCB = new System.Windows.Forms.ToolStripMenuItem();
			this.greenCB = new System.Windows.Forms.ToolStripMenuItem();
			this.blueCB = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ignorePureWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ignorePureBlackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// histimage
			// 
			this.histimage.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.histimage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.histimage.Location = new System.Drawing.Point(0, 65);
			this.histimage.Name = "histimage";
			this.histimage.Size = new System.Drawing.Size(768, 269);
			this.histimage.TabIndex = 0;
			this.histimage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.histimage_MouseMove);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.vlab);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.xlab);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.refresh);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(768, 41);
			this.panel1.TabIndex = 5;
			// 
			// vlab
			// 
			this.vlab.AutoSize = true;
			this.vlab.Location = new System.Drawing.Point(514, 13);
			this.vlab.Name = "vlab";
			this.vlab.Size = new System.Drawing.Size(14, 13);
			this.vlab.TabIndex = 10;
			this.vlab.Text = "V";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(488, 13);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(20, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "V=";
			// 
			// xlab
			// 
			this.xlab.AutoSize = true;
			this.xlab.Location = new System.Drawing.Point(360, 13);
			this.xlab.Name = "xlab";
			this.xlab.Size = new System.Drawing.Size(14, 13);
			this.xlab.TabIndex = 6;
			this.xlab.Text = "X";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(334, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "X=";
			// 
			// refresh
			// 
			this.refresh.Location = new System.Drawing.Point(3, 8);
			this.refresh.Name = "refresh";
			this.refresh.Size = new System.Drawing.Size(75, 23);
			this.refresh.TabIndex = 4;
			this.refresh.Text = "Refresh";
			this.refresh.UseVisualStyleBackColor = true;
			this.refresh.Click += new System.EventHandler(this.refresh_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Silver;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coloursToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(768, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// coloursToolStripMenuItem
			// 
			this.coloursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redCB,
            this.greenCB,
            this.blueCB});
			this.coloursToolStripMenuItem.Name = "coloursToolStripMenuItem";
			this.coloursToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.coloursToolStripMenuItem.Text = "Colours";
			// 
			// redCB
			// 
			this.redCB.Checked = true;
			this.redCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.redCB.Name = "redCB";
			this.redCB.Size = new System.Drawing.Size(152, 22);
			this.redCB.Text = "Red";
			this.redCB.Click += new System.EventHandler(this.redToolStripMenuItem_Click);
			// 
			// greenCB
			// 
			this.greenCB.Checked = true;
			this.greenCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.greenCB.Name = "greenCB";
			this.greenCB.Size = new System.Drawing.Size(152, 22);
			this.greenCB.Text = "Green";
			this.greenCB.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
			// 
			// blueCB
			// 
			this.blueCB.Checked = true;
			this.blueCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.blueCB.Name = "blueCB";
			this.blueCB.Size = new System.Drawing.Size(152, 22);
			this.blueCB.Text = "Blue";
			this.blueCB.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ignorePureWhiteToolStripMenuItem,
            this.ignorePureBlackToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// ignorePureWhiteToolStripMenuItem
			// 
			this.ignorePureWhiteToolStripMenuItem.Checked = true;
			this.ignorePureWhiteToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ignorePureWhiteToolStripMenuItem.Name = "ignorePureWhiteToolStripMenuItem";
			this.ignorePureWhiteToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.ignorePureWhiteToolStripMenuItem.Text = "Ignore pure white";
			this.ignorePureWhiteToolStripMenuItem.Click += new System.EventHandler(this.ignorePureWhiteToolStripMenuItem_Click);
			// 
			// ignorePureBlackToolStripMenuItem
			// 
			this.ignorePureBlackToolStripMenuItem.Checked = true;
			this.ignorePureBlackToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ignorePureBlackToolStripMenuItem.Name = "ignorePureBlackToolStripMenuItem";
			this.ignorePureBlackToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.ignorePureBlackToolStripMenuItem.Text = "Ignore pure black";
			this.ignorePureBlackToolStripMenuItem.Click += new System.EventHandler(this.ignorePureBlackToolStripMenuItem_Click);
			// 
			// histogram
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(768, 334);
			this.Controls.Add(this.histimage);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "histogram";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "histogram";
			this.Load += new System.EventHandler(this.histogram_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel histimage;
		private System.Windows.Forms.Button refresh;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label vlab;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label xlab;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem coloursToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redCB;
		private System.Windows.Forms.ToolStripMenuItem greenCB;
		private System.Windows.Forms.ToolStripMenuItem blueCB;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ignorePureWhiteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ignorePureBlackToolStripMenuItem;

	}
}