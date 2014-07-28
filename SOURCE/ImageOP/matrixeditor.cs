using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ANDREICSLIB;

namespace ImageOP
{
	public partial class matrixeditor : Form
	{
		public const char seprow = '#';
		public const char sepcol = ',';
		private int height;
		public String result = "";
		private int width;

		public matrixeditor(String existingMatrix = "")
		{
			InitializeComponent();

			if (String.IsNullOrEmpty(existingMatrix) == false)
			{
				try
				{
					var mat = deserialiseMatrix(existingMatrix);
					widthtext.Text = mat[0].Count.ToString();
					heighttext.Text = mat.Count.ToString();
					updatefunc();
					loadMatrix(mat);
				}
				catch (Exception e)
				{
					MessageBox.Show("Error loading matrix\n" + e);
					updatefunc();
				}
			}
			else
				updatefunc();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}


		private void updatebutton_Click(object sender, EventArgs e)
		{
			updatefunc();
		}

		private void updatefunc()
		{
			int w;
			int h;
			try
			{
				w = int.Parse(widthtext.Text);
				h = int.Parse(heighttext.Text);
			}
			catch (Exception e)
			{
				MessageBox.Show("Error loading height/width:\n" + e);
				w = 3;
				h = 3;
			}
			width = w;
			height = h;

			matrixgrid.clearControls();

			for (var y = 0; y < h; y++)
				for (var x = 0; x < w; x++)
				{
					var TB = new TextBox();
					TB.Name = x.ToString() + ":" + y.ToString();
					TB.Size = new Size(30, 50);
					TB.KeyPress += gridtextkeypress;

					matrixgrid.addControl(TB, x < w - 1);
				}
		}

		private void widthtext_KeyPress(object sender, KeyPressEventArgs e)
		{
		    e.Handled = TextboxExtras.HandleInput(TextboxExtras.InputType.Create(false, true, false, false), e.KeyChar,
		                                           widthtext);
		}

		private void gridtextkeypress(object sender, KeyPressEventArgs e)
		{
            e.Handled = TextboxExtras.HandleInput(TextboxExtras.InputType.Create(false, true,true, false), e.KeyChar);
		}

		private void okbutton_Click(object sender, EventArgs e)
		{
			result = serialiseMatrix();
			Close();
		}

		private String getgrid(int x, int y)
		{
			foreach (Control c in matrixgrid.Controls)
			{
				if (c.Name.Equals(x.ToString() + ":" + y.ToString()))
					return c.Text;
			}
			return "0";
		}

		private void setgrid(int x, int y, float v)
		{
			foreach (Control c in matrixgrid.Controls)
			{
				if (c.Name.Equals(x.ToString() + ":" + y.ToString()))
				{
					c.Text = v.ToString();
					return;
				}
			}
		}

		private String serialiseMatrix()
		{
			var res = "";
			for (var y = 0; y < height; y++)
			{
				for (var x = 0; x < width; x++)
				{
					if (x == 0)
						res += getgrid(x, y);
					else
						res += sepcol + getgrid(x, y);
				}
				if (y < height - 1)
					res += seprow;
			}
			return res;
		}

		public static List<List<float>> deserialiseMatrix(String s)
		{
			//separate by dots
			var seprowl = new[] {seprow};
			var sepiteml = new[] {sepcol};
			var rows = s.Split(seprowl);

			var rowints = new List<List<float>>();
			foreach (var r in rows)
			{
				//split by item
				var items = r.Split(sepiteml);
				//to int
				var numbers = items.Select(float.Parse).ToList();
				rowints.Add(numbers);
			}

			return rowints;
		}

		private void loadMatrix(List<List<float>> mat)
		{
			var x = 0;
			var y = 0;
			foreach (var row in mat)
			{
				foreach (var v in row)
				{
					setgrid(x, y, v);
					x++;
				}
				x = 0;
				y++;
			}
		}

		private void cancelbutton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}