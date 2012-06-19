using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ANDREICSLIB;

namespace ImageOP
{
	public class formula
	{
		private const char nl = '\n';
		public String ID = "";

		public List<string> operations = new List<string>();
		public bool skip;
		public String subtype = "";
		public String type = "";

		public formula(String typeN, string subtypeN)
		{
			type = typeN;
			subtype = subtypeN;
			getID();
		}

		public formula()
		{
			getID();
		}

		private String getID()
		{
			var t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
			return t.TotalSeconds.ToString();
		}

		public String serialise()
		{
			var ret = "";
			ret += type + nl + subtype + nl;
			foreach (var s in operations)
			{
				ret += s + nl;
			}
			return ret;
		}

		public static void deserialise(List<formula> fl, ref PanelUpdates PU)
		{
			PU.clearControls();
			var F = ((FormulaEditor) PU.Parent);
			F.formulas.Clear();

			var controlcount = 0;
			foreach (var f in fl)
			{
				var f2 = FormulaEditor.addline(ref PU, f.type, f.subtype);
				//set the last panel formulas name to match
				var subcontrolcount = 0;
				foreach (var s in f.operations)
				{
					var X = PU.controlStack[controlcount].Controls[subcontrolcount];
					while (FormulaEditor.isUsableControl(X)==false)
					{
						subcontrolcount++;
						X = PU.controlStack[controlcount].Controls[subcontrolcount];
					}
					//we need to manually add the item to the combo box item list, or it wont be loaded - wtf lel
					if (X is ComboBox && ((ComboBox) X).Items.Contains(s) == false)
					{
						((ComboBox) X).Items.Add(s);
					}

					PU.controlStack[controlcount].Controls[subcontrolcount].Text = s;
					subcontrolcount++;
				}
				F.formulas.Add(f2);
				controlcount++;
			}
		}

		public static List<formula> deserialise(String filename)
		{
			var FS = new FileStream(filename, FileMode.Open);
			var SR = new StreamReader(FS);
			var s = SR.ReadToEnd();
			SR.Close();
			FS.Close();

			var chs = new string[2];
			chs[0] = "\r\n";
			chs[1] = "\n";
			var st = s.Split(chs, StringSplitOptions.None);
			var ops = st.ToList();

			//the input operation count
			var count = 0;
			var infunc = false;

			formula f = null;
			var listf = new List<formula>();
			var count2 = 0;
			while (count < ops.Count)
			{
				//FSTART = new formula
				if (ops[count].Equals("FSTART"))
				{
					infunc = true;
					count2 = 0;
				}
				else if (ops[count].Equals("FEND"))
				{
					infunc = false;
					listf.Add(f);
				}

				else if (infunc)
				{
					if (count2 == 1)
					{
						f = new formula(ops[count], ops[count + 1]);
					}
					else if (count2 > 2)
						f.operations.Add(ops[count]);
				}
				count++;
				count2++;
			}
			return listf;
		}

		public static void deserialise(String filename, ref PanelUpdates PU)
		{
			var FS = new FileStream(filename, FileMode.Open);
			var SR = new StreamReader(FS);
			var s = SR.ReadToEnd();
			SR.Close();
			FS.Close();

			var chs = new string[2];
			chs[0] = "\r\n";
			chs[1] = "\n";
			var st = s.Split(chs, StringSplitOptions.None);
			var ops = new List<string>();
			foreach (var str in st)
			{
				//if (String.IsNullOrEmpty(str) == false&&str.Equals("\r")==false&&str.Equals("\n")==false)
				ops.Add(str);
			}

			PU.clearControls();
			var F = ((FormulaEditor) PU.Parent);
			F.formulas.Clear();

			//the input operation count
			var count = 0;
			var infunc = false;

			var controlcount = 0;
			var subcontrolcount = 0;
			formula f = null;

			while (count < ops.Count)
			{
				//FSTART = new formula
				if (ops[count].Equals("FSTART"))
				{
					subcontrolcount = 0;
					f = FormulaEditor.addline(ref PU, ops[count + 1], ops[count + 2]);
					infunc = true;
					count += 2;
				}
				else if (ops[count].Equals("FEND"))
				{
					infunc = false;
					controlcount++;
					F.formulas.Add(f);
				}

				else if (infunc)
				{
					var X = PU.controlStack[controlcount].Controls[subcontrolcount];
					while (FormulaEditor.isUsableControl(X)==false)
					{
						subcontrolcount++;
						X = PU.controlStack[controlcount].Controls[subcontrolcount];
					}
					PU.controlStack[controlcount].Controls[subcontrolcount].Text = ops[count];
					subcontrolcount++;
				}
				count++;
			}
		}

		public void setoperations(ref PanelUpdates PU)
		{
			var retop = new List<string>();

			foreach (Control C in PU.Controls)
			{
				if (FormulaEditor.isUsableControl(C))
					retop.Add(C.Text);
			}
			operations = retop;
		}
	}
}