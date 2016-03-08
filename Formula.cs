using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ANDREICSLIB.ClassReplacements;

namespace ImageScripter
{
	public class Formula
	{
		private const char nl = '\n';
		public String ID = "";

		public List<string> Operations = new List<string>();
		public bool skip;
		public String subtype = "";
		public String type = "";

		public Formula(String typeN, string subtypeN)
		{
			type = typeN;
			subtype = subtypeN;
			getID();
		}

		public Formula()
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
			foreach (var s in Operations)
			{
				ret += s + nl;
			}
			return ret;
		}

		public static void Deserialise(List<Formula> fl, ref PanelReplacement PU)
		{
			PU.ClearControls();
			var F = ((FormulaEditor) PU.Parent);
			F.formulas.Clear();

			var controlcount = 0;
			foreach (var f in fl)
			{
				var f2 = FormulaEditor.addline(ref PU, f.type, f.subtype);
				//set the last panel formulas name to match
				var subcontrolcount = 0;
				foreach (var s in f.Operations)
				{
					var X = PU.GetControlStack()[controlcount].Controls[subcontrolcount];
					while (FormulaEditor.isUsableControl(X)==false)
					{
						subcontrolcount++;
						X = PU.GetControlStack()[controlcount].Controls[subcontrolcount];
					}
					//we need to manually add the item to the combo box item list, or it wont be loaded - wtf lel
					if (X is ComboBox && ((ComboBox) X).Items.Contains(s) == false)
					{
						((ComboBox) X).Items.Add(s);
					}

					PU.GetControlStack()[controlcount].Controls[subcontrolcount].Text = s;
					subcontrolcount++;
				}
				F.formulas.Add(f2);
				controlcount++;
			}
		}

		public static List<Formula> Deserialise(String filename)
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

			Formula f = null;
			var listf = new List<Formula>();
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
						f = new Formula(ops[count], ops[count + 1]);
					}
					else if (count2 > 2)
						f.Operations.Add(ops[count]);
				}
				count++;
				count2++;
			}
			return listf;
		}

		public static void Deserialise(String filename, ref PanelReplacement PU)
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

			PU.ClearControls();
			var F = ((FormulaEditor) PU.Parent);
			F.formulas.Clear();

			//the input operation count
			var count = 0;
			var infunc = false;

			var controlcount = 0;
			var subcontrolcount = 0;
			Formula f = null;

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
					var X = PU.GetControlStack()[controlcount].Controls[subcontrolcount];
					while (FormulaEditor.isUsableControl(X)==false)
					{
						subcontrolcount++;
						X = PU.GetControlStack()[controlcount].Controls[subcontrolcount];
					}
					PU.GetControlStack()[controlcount].Controls[subcontrolcount].Text = ops[count];
					subcontrolcount++;
				}
				count++;
			}
		}

		public void setoperations(ref PanelReplacement PU)
		{
			var retop = new List<string>();

			foreach (Control C in PU.Controls)
			{
				if (FormulaEditor.isUsableControl(C))
					retop.Add(C.Text);
			}
			Operations = retop;
		}
	}
}