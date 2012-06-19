namespace ImageOP
{
	partial class matrixeditor
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
			this.widthtext = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label2 = new System.Windows.Forms.Label();
			this.heighttext = new System.Windows.Forms.TextBox();
			this.updatebutton = new System.Windows.Forms.Button();
			this.matrixgrid = new ANDREICSLIB.PanelUpdates();
			this.okbutton = new System.Windows.Forms.Button();
			this.cancelbutton = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// widthtext
			// 
			this.widthtext.Location = new System.Drawing.Point(44, 39);
			this.widthtext.Name = "widthtext";
			this.widthtext.Size = new System.Drawing.Size(100, 20);
			this.widthtext.TabIndex = 0;
			this.widthtext.Text = "3";
			this.widthtext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.widthtext_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Width";
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Silver;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(657, 24);
			this.menuStrip1.TabIndex = 2;
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
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(150, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Height";
			// 
			// heighttext
			// 
			this.heighttext.Location = new System.Drawing.Point(194, 39);
			this.heighttext.Name = "heighttext";
			this.heighttext.Size = new System.Drawing.Size(100, 20);
			this.heighttext.TabIndex = 3;
			this.heighttext.Text = "3";
			this.heighttext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.widthtext_KeyPress);
			// 
			// updatebutton
			// 
			this.updatebutton.Location = new System.Drawing.Point(300, 37);
			this.updatebutton.Name = "updatebutton";
			this.updatebutton.Size = new System.Drawing.Size(75, 23);
			this.updatebutton.TabIndex = 6;
			this.updatebutton.Text = "Update";
			this.updatebutton.UseVisualStyleBackColor = true;
			this.updatebutton.Click += new System.EventHandler(this.updatebutton_Click);
			// 
			// matrixgrid
			// 
			this.matrixgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.matrixgrid.AutoScroll = true;
			this.matrixgrid.BackColor = System.Drawing.SystemColors.ControlLight;
			this.matrixgrid.Location = new System.Drawing.Point(12, 65);
			this.matrixgrid.Name = "matrixgrid";
			this.matrixgrid.Size = new System.Drawing.Size(633, 372);
			this.matrixgrid.TabIndex = 7;
			// 
			// okbutton
			// 
			this.okbutton.Location = new System.Drawing.Point(570, 36);
			this.okbutton.Name = "okbutton";
			this.okbutton.Size = new System.Drawing.Size(75, 23);
			this.okbutton.TabIndex = 8;
			this.okbutton.Text = "OK";
			this.okbutton.UseVisualStyleBackColor = true;
			this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
			// 
			// cancelbutton
			// 
			this.cancelbutton.Location = new System.Drawing.Point(489, 36);
			this.cancelbutton.Name = "cancelbutton";
			this.cancelbutton.Size = new System.Drawing.Size(75, 23);
			this.cancelbutton.TabIndex = 9;
			this.cancelbutton.Text = "Cancel";
			this.cancelbutton.UseVisualStyleBackColor = true;
			this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
			// 
			// matrixeditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(657, 449);
			this.Controls.Add(this.cancelbutton);
			this.Controls.Add(this.okbutton);
			this.Controls.Add(this.matrixgrid);
			this.Controls.Add(this.updatebutton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.heighttext);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.widthtext);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "matrixeditor";
			this.Text = "matrixeditor";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox widthtext;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox heighttext;
		private System.Windows.Forms.Button updatebutton;
		private ANDREICSLIB.PanelUpdates matrixgrid;
		private System.Windows.Forms.Button okbutton;
		private System.Windows.Forms.Button cancelbutton;
	}
}