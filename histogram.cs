using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageScripter
{
	public partial class histogram : Form
	{

		public Form1 baseform;
		private int imageindex;
		
		int width;
		int[] bucket;

		public histogram(Form1 baseformIN, int imageindexIN)
		{
			baseform = baseformIN;
			InitializeComponent();
			imageindex = imageindexIN;
			refreshimage();
		}

		private void histogram_Load(object sender, EventArgs e)
		{

		}

		private void refreshimage()
		{
			histimage.BackgroundImage = null;
			var count = 0;
			if (redCB.Checked)
				count++;
			if (greenCB.Checked)
				count++;
			if (blueCB.Checked)
				count++;
			if (count == 0)
				return;
			
			width = 256 * count;
			var bit = new Bitmap(width, 256);
			bucket = new int[width];
			
			//image stuff here
			Calculations.SetImageLocations();
			//calculations.ImageLocations[]
			var i = baseform.ImagePanels[imageindex];
			//ICL i=
			var newim = new CustomImage(i);
			
			var max = 0;
			var maxval = 255*3;
			for (var x = 0; x < i.I.Width; x++) for (var y = 0; y < i.I.Height; y++)
				{
					var from = Calculations.GetPixel(x, y, newim);
					var col = 0;
					if (redCB.Checked)
						col += from.R;
					if (greenCB.Checked)
						col += from.G;
					if (blueCB.Checked)
						col += from.B;
					
				if ((col == maxval&&ignorePureWhiteToolStripMenuItem.Checked)||
						col==0&&ignorePureBlackToolStripMenuItem.Checked)
						continue;

					bucket[col]++;
				}

			for (var x = 0; x < width; x++)
			{
				if (bucket[x] > max)
					max = bucket[x];
			}

			if (max==0)
			{
				MessageBox.Show("Warning, image maybe entirely black and white, and the options may be removing them.");
				return;
			}

			for (var x = 0; x < width; x++)
			{
				bucket[x] = ((int)(((float)bucket[x]) / ((float)max) * 255.0));
			}

			for (var x = 0; x < width; x++)
			{
				var c = bucket[x];
				var j = (int)(((float)x / (float)width) * 255);
				
				var r = 0;
				if (redCB.Checked)
					r = j;

				var g = 0;
				if (greenCB.Checked)
					g = j;

				var b = 0;
				if (blueCB.Checked)
					b = j;

				for (var y = 0; y < c; y++)
				{
					bit.SetPixel(x, y, Color.FromArgb(r, g, b));
				}
			}

			//load to screen
			Image im = bit;
			im.RotateFlip(RotateFlipType.Rotate180FlipX);
			histimage.BackgroundImage = im;
			histimage.BackgroundImageLayout = ImageLayout.Stretch;
		}

		private void refresh_Click(object sender, EventArgs e)
		{
			refreshimage();
		}

		private void histimage_MouseMove(object sender, MouseEventArgs e)
		{
			var x = ((int)(((float)e.X)/((float)histimage.Width)*(float)width));

			xlab.Text = x.ToString();
			vlab.Text = bucket[x].ToString();
		}

		private void redToolStripMenuItem_Click(object sender, EventArgs e)
		{
			redCB.Checked = !redCB.Checked;
		}

		private void greenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			greenCB.Checked = !greenCB.Checked;
		}

		private void blueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			blueCB.Checked = !blueCB.Checked;
		}

		private void ignorePureWhiteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ignorePureWhiteToolStripMenuItem.Checked = !ignorePureWhiteToolStripMenuItem.Checked;
		}

		private void ignorePureBlackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ignorePureBlackToolStripMenuItem.Checked = !ignorePureBlackToolStripMenuItem.Checked;
		}

	}
}
