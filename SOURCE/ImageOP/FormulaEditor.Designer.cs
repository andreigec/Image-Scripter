namespace ImageOP
{
	partial class FormulaEditor
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
            this.addrowbutton = new System.Windows.Forms.Button();
            this.formulatype = new System.Windows.Forms.ComboBox();
            this.subformulatype = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.helptextbutton = new System.Windows.Forms.Button();
            this.clearbutton = new System.Windows.Forms.Button();
            this.okbutton = new System.Windows.Forms.Button();
            this.saveformula = new System.Windows.Forms.Button();
            this.loadformula = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.loadedformulas = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.formulapanel = new ANDREICSLIB.PanelReplacement();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addrowbutton
            // 
            this.addrowbutton.Location = new System.Drawing.Point(399, 3);
            this.addrowbutton.Name = "addrowbutton";
            this.addrowbutton.Size = new System.Drawing.Size(75, 21);
            this.addrowbutton.TabIndex = 1;
            this.addrowbutton.Text = "Add Row";
            this.addrowbutton.UseVisualStyleBackColor = true;
            this.addrowbutton.Click += new System.EventHandler(this.addrowbutton_Click);
            // 
            // formulatype
            // 
            this.formulatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formulatype.FormattingEnabled = true;
            this.formulatype.Location = new System.Drawing.Point(3, 3);
            this.formulatype.Name = "formulatype";
            this.formulatype.Size = new System.Drawing.Size(121, 21);
            this.formulatype.TabIndex = 3;
            this.formulatype.SelectedIndexChanged += new System.EventHandler(this.formulatype_SelectedIndexChanged);
            // 
            // subformulatype
            // 
            this.subformulatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subformulatype.FormattingEnabled = true;
            this.subformulatype.Location = new System.Drawing.Point(130, 3);
            this.subformulatype.Name = "subformulatype";
            this.subformulatype.Size = new System.Drawing.Size(233, 21);
            this.subformulatype.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.helptextbutton);
            this.panel1.Controls.Add(this.clearbutton);
            this.panel1.Controls.Add(this.okbutton);
            this.panel1.Controls.Add(this.subformulatype);
            this.panel1.Controls.Add(this.addrowbutton);
            this.panel1.Controls.Add(this.formulatype);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 35);
            this.panel1.TabIndex = 5;
            // 
            // helptextbutton
            // 
            this.helptextbutton.Location = new System.Drawing.Point(369, 3);
            this.helptextbutton.Name = "helptextbutton";
            this.helptextbutton.Size = new System.Drawing.Size(24, 21);
            this.helptextbutton.TabIndex = 6;
            this.helptextbutton.Text = "?";
            this.helptextbutton.UseVisualStyleBackColor = true;
            this.helptextbutton.Click += new System.EventHandler(this.helptextbutton_Click);
            // 
            // clearbutton
            // 
            this.clearbutton.Location = new System.Drawing.Point(524, 3);
            this.clearbutton.Name = "clearbutton";
            this.clearbutton.Size = new System.Drawing.Size(75, 21);
            this.clearbutton.TabIndex = 5;
            this.clearbutton.Text = "Clear";
            this.clearbutton.UseVisualStyleBackColor = true;
            this.clearbutton.Click += new System.EventHandler(this.clearbutton_Click);
            // 
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(727, 3);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(168, 21);
            this.okbutton.TabIndex = 5;
            this.okbutton.Text = "OK";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // saveformula
            // 
            this.saveformula.Location = new System.Drawing.Point(6, 3);
            this.saveformula.Name = "saveformula";
            this.saveformula.Size = new System.Drawing.Size(182, 23);
            this.saveformula.TabIndex = 0;
            this.saveformula.Text = "Save Current Formula";
            this.saveformula.UseVisualStyleBackColor = true;
            this.saveformula.Click += new System.EventHandler(this.saveformula_Click);
            // 
            // loadformula
            // 
            this.loadformula.Location = new System.Drawing.Point(6, 467);
            this.loadformula.Name = "loadformula";
            this.loadformula.Size = new System.Drawing.Size(182, 23);
            this.loadformula.TabIndex = 1;
            this.loadformula.Text = "Load Selected";
            this.loadformula.UseVisualStyleBackColor = true;
            this.loadformula.Click += new System.EventHandler(this.loadformula_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Load Formula:";
            // 
            // loadedformulas
            // 
            this.loadedformulas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.loadedformulas.Location = new System.Drawing.Point(6, 57);
            this.loadedformulas.Name = "loadedformulas";
            this.loadedformulas.Size = new System.Drawing.Size(182, 404);
            this.loadedformulas.TabIndex = 3;
            this.loadedformulas.UseCompatibleStateImageBehavior = false;
            this.loadedformulas.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Formula Name";
            this.columnHeader1.Width = 169;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.loadedformulas);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.loadformula);
            this.panel2.Controls.Add(this.saveformula);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(899, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 493);
            this.panel2.TabIndex = 6;
            // 
            // formulapanel
            // 
            this.formulapanel.AutoScroll = true;
            this.formulapanel.BackColor = System.Drawing.Color.White;
            this.formulapanel.BorderColour = System.Drawing.Color.Black;
            this.formulapanel.BorderWidth = 0;
            this.formulapanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formulapanel.Location = new System.Drawing.Point(0, 59);
            this.formulapanel.Name = "formulapanel";
            this.formulapanel.Size = new System.Drawing.Size(899, 458);
            this.formulapanel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1090, 24);
            this.menuStrip1.TabIndex = 7;
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Cancel";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // FormulaEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 517);
            this.Controls.Add(this.formulapanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormulaEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormulaEditor";
            this.Load += new System.EventHandler(this.FormulaEditor_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private ANDREICSLIB.PanelReplacement formulapanel;
		private System.Windows.Forms.Button addrowbutton;
		private System.Windows.Forms.ComboBox formulatype;
		private System.Windows.Forms.ComboBox subformulatype;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button clearbutton;
		private System.Windows.Forms.Button okbutton;
		private System.Windows.Forms.Button saveformula;
		private System.Windows.Forms.Button loadformula;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView loadedformulas;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button helptextbutton;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
	}
}