using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageScripter
{
	internal class Calculations
	{
		public static Form1 Baseform;
		private static List<Formula> Formulas = new List<Formula>();
		public static Information I;

		//op,subop
		public static Dictionary<string, List<string>> operationdic = new Dictionary<string, List<string>>();
		//store custom formulas here to save time
		private static Dictionary<String, List<List<float>>> storedCustomFormulas;
		private static Dictionary<String, xy> storedCustomSizes;
		public static int Threadfincount;
		public static int Thispassnumber = 1;

		public const String Operation = "Operation";

		public const String Moveoperation = "Moves";
		public const String Moveop = "Move";
		public const String Swapop = "Swap";
		public const String UserInputPixelOperation = "User Input Pixel Operation";
		public const String VarInputPixelOperation = "Variable Pixel Operation";
		public const String PresetNeighbourhoodOperations = "Preset Neighbourhood Operations";
		public const String CustomNeighbourhoodOperations = "Custom Neighbourhood Operations";
		public const String Conditionoperation = "Conditions";
		public const String Passoperation = "Passes";
		public const String Commentop = "Comment";
		
		//destination - along with all the dynamic vars - Var1-9 and images
		private const String Imagehead = "IM:";
		public const String Imageimage = Imagehead+"Image:";
		public const String CurrentpixelOut = Imagehead+"Output";
		public const String Imagevar = Imagehead + "Variable:";
		//calculations-pixel op
		public const String Subtractop = "Subtract";
		public const String Addop = "Add";
		public const String Multiplyop = "Multiply";
		public const String Divideop = "Divide";
		public const String Modulusop = "Modulus";

		//colour op
		public const String Vartype = "Colour:";
		public const String RedOP = Vartype+"Red";
		public const String BlueOP = Vartype+"Blue";
		public const String GreenOP = Vartype+"Green";
		public const String AllOP = Vartype+"All";
		//conditions
		public const string Ifcolcondition = "If-Colour";
		public const string Ifposcondition = "If-Position";
		public const string Endifcondition = "End If";
		//comparisons
		public const string LTop = "Less Than";
		public const string LEop = "Less Than or Equal to";
		public const string EQop = "Equal to";
		public const string GTop = "Greater Than";
		public const string GEop = "Greater Than or Equal to";
		//NH ops
		public const string MeanAverage = "Mean Average";
		public const string MedianAverage = "Median Average";
		//example cust matricies
		public const string Custom1 = "-1,-2,-1#0,0,0#1,2,1";
		public const string Custom2 = "-1,0,1#-2,0,2#-1,0,1";
		public const string Custom3 = "-1,0,1,0,-1#0,1,0,1,0#-1,0,1,0,-1#0,1,0,1,0#-1,0,1,0,-1";
		//if position
		public const string XPOS = "X";
		public const string YPOS = "Y";
		//if pos types
		public const string PosPixels = "Pixels";
		public const string PosPercent = "Percent";

		private List<bool> ifstack = new List<bool>();
		private int x;
		private int y;
		//MUST be non-static for thread safety
		public Dictionary<String, Color> Variables = new Dictionary<String, Color>();
		//link variables to their array
		public static Dictionary<String, CustomImage> ImageLocations = new Dictionary<string, CustomImage>();

		static Calculations()
		{
			//operation step 1 :mapping operations to suboperations
			var op = "";
			List<string> subop = null;

			//moveop
			op = Moveoperation;
			subop = new List<string>{Moveop,Swapop};
			operationdic.Add(op, subop);

			//pixel op
			op = Operation;
			subop = new List<string> { UserInputPixelOperation, VarInputPixelOperation, PresetNeighbourhoodOperations, CustomNeighbourhoodOperations };
			operationdic.Add(op, subop);

			//conditions
			op = Conditionoperation;
			subop = new List<string> { Ifcolcondition, Ifposcondition,Endifcondition };
			operationdic.Add(op, subop);

			//passes
			op = Passoperation;
			subop = new List<string>();
			operationdic.Add(op, subop);

			//comments
			op = Commentop;
			subop = new List<string>();
			operationdic.Add(op, subop);
		}

		public static void ApplyMain(object o)
		{
			try
			{
				var t = ((ThreadInfo) o);

				var c = new Calculations();
				for (var x = t.xmin; x < t.xmax; x++)
				{
					for (var y = t.ymin; y < t.ymax; y++)
					{
						c.Apply(x, y);
					}
				}
			}
			finally
			{
			Baseform.Invoke(new Form1.IncreaseProgressDel(Baseform.IncreaseProgress));
			Threadfincount++;
		}
	}

		private void Apply(int xIN, int yIN)
		{
			x = xIN;
			y = yIN;

			//if the user doesnt put a pass in, by default it is always 1
			var passrequired = 1;
			foreach (var f in Formulas)
			{
				//auto skip this op?
				if (f.skip)
					continue;

				//if/endif conditions
			if (f.type.Equals(Conditionoperation))
				{
					if (f.subtype.Equals(Endifcondition))
						EndIfCondition();
					else if ( f.subtype.Equals(Ifcolcondition))
						IfCondition(f);
					else if (f.subtype.Equals(Ifposcondition))
						IfPosCondition(f);
				}

				if (ifstack.Count > 0 && ifstack[ifstack.Count - 1] == false)
					continue;

				//pass conditions
				if (f.type.Equals(Passoperation))
					passrequired = passOperation(f);

				//if the formula is under a different pass, dont do it
				if (Thispassnumber != passrequired)
					continue;

				//continue with the actual operations
				if (f.type.Equals(Moveoperation))
				{
					if (f.subtype.Equals(Moveop))
						MoveOperation(f);
					else if (f.subtype.Equals(Swapop))
						SwapOperation(f);
			}
		else if (f.type.Equals(Operation))
				{
					if (f.subtype.Equals(UserInputPixelOperation))
						UserPixelOperation(f);
					else if (f.subtype.Equals(VarInputPixelOperation))
						VarPixelOperation(f);
					else if (f.subtype.Equals(PresetNeighbourhoodOperations))
						PresetNHoperation(f);
					else if (f.subtype.Equals(CustomNeighbourhoodOperations))
						CustNHoperation(f);
				}
			}
		}

		public static void SetImageLocations()
		{
			ImageLocations = new Dictionary<string, CustomImage>();
			foreach (var f in Formulas)
			{
				foreach (var op in f.Operations)
				{
					if (op.StartsWith(Imagehead) == false)
						continue;
					//see if it exists already
					if (ImageLocations.ContainsKey(op))
						continue;
					//see if it is the output
					if (op.Equals(CurrentpixelOut))
					{
						//if (imageLocations.ContainsKey(op)==false)
						//{
						ImageLocations.Add(op, I.pixelsTo);
						//}
					}
					//see if it is a variable ( we want to leave blank for vars)
					else if (op.StartsWith(Imagevar))
					{

					}
					//otherwise it is an image
					else if (op.StartsWith(Imageimage))
					{
						int im;
						if (int.TryParse(op.Substring(Imageimage.Length), out im))
						{
							ImageLocations.Add(op, I.imlist[im]);
						}
					}
				}
			}
		}

		public static IEnumerable<string> GetVarList(bool noVariables)
		{
			var ret = new List<string> {CurrentpixelOut};

			for (var a = 0; a < 10; a++)
			{
				ret.Add(Imageimage + a.ToString());
			}
			if (noVariables == false)
			{
				for (var a = 1; a < 10; a++)
				{
					ret.Add(Imagevar + a.ToString());
				}
			}
			return ret;
		}
		/*
		 * 
		 private static void Printmatrix(int diameter)
		{
			for (int a = 0; a < diameter; a++)
			{
				for (int b = 0; b < diameter; b++)
				{
					Console.Write(Appmatrix[a][b] + "\t");
				}
				Console.Write("\n");
			}
		}
		public static void InitMatrix(int diam)
		{
			Appmatrix = new int[diam][];
			for (int a = 0; a < diam; a++)
			{
				Appmatrix[a] = new int[diam];
			}
			int di = InitOrigSobel(diam);

			ExpandDiameter(di, diam);
			//run 0s down the middle
			int cent = misc.floor(diam/2);
			for (int a = 0; a < diam; a++)
			{
				Appmatrix[a][cent] = 0;
			}
			Printmatrix(diam);
		}
		 * 
		 * private static void ExpandDiameter(int current, int diameter)
		{
			int center = misc.floor(diameter/2);

			while (current < diameter)
			{
				int centrecurrent = misc.floor(current);

				//double existing
				for (int a = 0; a < diameter; a++)
					for (int b = 0; b < diameter; b++)
					{
						Appmatrix[a][b] *= 2;
					}

				//expand
				for (int a = 0; a < center; a++)
					for (int b = 0; b < diameter; b++)
					{
						if (Appmatrix[a][b] == 0)
							Appmatrix[a][b] = Appmatrix[a + 1][b]/2;

						if (Appmatrix[b][a] == 0)
							Appmatrix[b][a] = Appmatrix[b][a + 1]/2;
					}

				for (int a = center; a < diameter; a++)
					for (int b = 0; b < diameter; b++)
					{
						if (Appmatrix[a][b] == 0)
							Appmatrix[a][b] = Appmatrix[a - 1][b]/2;

						if (Appmatrix[b][a] == 0)
							Appmatrix[b][a] = Appmatrix[b][a - 1]/2;
					}
				current += 2;
			}
		}
		
		private static int InitOrigSobel(int diam)
		{
			int centre = misc.floor(diam/2);
			//101
			//202
			//101

			if (diam >= 3)
			{
				Appmatrix[centre - 1][centre - 1] = 1;
				Appmatrix[centre - 1][centre + 1] = -1;
				Appmatrix[centre][centre - 1] = 2;
				Appmatrix[centre][centre + 1] = -2;
				Appmatrix[centre + 1][centre - 1] = 1;
				Appmatrix[centre + 1][centre + 1] = -1;
			}
			else if (diam == 2)
			{
				Appmatrix[0][0] = 1;
				Appmatrix[0][1] = -1;
				Appmatrix[1][0] = -1;
				Appmatrix[1][1] = 1;
			}
			else
			{
				Appmatrix[0][0] = 1;
			}
			return 3;
		}
		*/

		private bool DoIfComparison(int value1, String comparison, int value2)
		{
			return ((comparison.Equals(LTop) && value1 < value2) ||
			        (comparison.Equals(LEop) && value1 <= value2) ||
			        (comparison.Equals(EQop) && value1 == value2) ||
			        (comparison.Equals(GTop) && value1 > value2) ||
			        (comparison.Equals(GEop) && value1 >= value2)
			       );
		}
		
		private bool DoIfColComparison(Color from, String fromloc, String comparison, int value)
		{
			var ret = false;
			if (fromloc.Equals(RedOP) || fromloc.Equals(AllOP))
			{
				ret = DoIfComparison(from.R, comparison, value);
			}
			if (fromloc.Equals(BlueOP) || fromloc.Equals(AllOP))
			{
				ret = DoIfComparison(from.B, comparison, value);
			}
			if (fromloc.Equals(GreenOP) || fromloc.Equals(AllOP))
			{
				ret = DoIfComparison(from.G, comparison, value);
			}
			return ret;
		}

		private int passOperation(Formula f)
		{
			return int.Parse(f.Operations[0]);
		}

		private void IfCondition(Formula f)
		{
			//op 0 is variable
			var from = GetFrom(f.Operations[0]);

			//op 1 is  R/G/B/ALL						

			//op 2 is the operation

			//op 3 is the value
			var am = int.Parse(f.Operations[3]);

			ifstack.Add(DoIfColComparison(from, f.Operations[1], f.Operations[2], am));
		}

		private void IfPosCondition(Formula f)
		{
			//op 0 = position type 1

			//op 1 = position type 2
			var loc = 0;
			var locstr = f.Operations[0];
			var locstr2 = f.Operations[1];
			if (locstr.Equals(XPOS)&&locstr2.Equals(PosPixels))
				loc = x;
			else if (locstr.Equals(YPOS)&&locstr2.Equals(PosPixels))
				loc = y;
			else if (locstr.Equals(XPOS)&&locstr2.Equals(PosPercent))
				loc = (int)(((float)x / (float)I.maxw) * 100.0);
			else if (locstr.Equals(YPOS)&&locstr2.Equals(PosPercent))
				loc = (int)(((float)y / (float)I.maxh) * 100.0);

			//op 2 = comparison type

			//op 3 = value

			var am = int.Parse(f.Operations[3]);

			ifstack.Add(DoIfComparison(loc, f.Operations[2], am));
		}

		private void EndIfCondition()
		{
			if (ifstack.Count > 0)
				ifstack.Remove(ifstack[ifstack.Count - 1]);
		}

		private void PerformMeanAverage(int diam, String fromS, string vartype, String toS)
		{
			var count = 0;
			var totR = 0;
			var totG = 0;
			var totB = 0;
			var xrad = diam / 2;
			var yrad = diam / 2;

			for (var y1 = y - yrad; y1 <= y + yrad; y1++)
			{
				if (y1 < 0 || y1 >= I.maxh)
					continue;

				for (var x1 = x - xrad; x1 <= x + xrad; x1++)
				{
					if (x1 < 0 || x1 >= I.maxw)
						continue;

					var from1 = GetFrom(x1, y1, fromS);
					totR += from1.R;
					totG += from1.G;
					totB += from1.B;
					count++;
				}
			}

			totR = Math.Abs(totR);
			totB = Math.Abs(totB);
			totG = Math.Abs(totG);

			var from2 = GetFrom(x, y, fromS);
			if ((vartype.Equals(RedOP) || vartype.Equals(AllOP)))
				totR /= count;
			else
				totR = from2.R;

			if (vartype.Equals(GreenOP) || vartype.Equals(AllOP))
				totG /= count;
			else
				totG = from2.G;

			if (vartype.Equals(BlueOP) || vartype.Equals(AllOP))
				totB /= count;
			else
				totB = from2.B;

			var toC = Color.FromArgb(totR, totG, totB);
			SetTo(toS, toC);
		}

		private void PerformMedianAverage(int diam, String fromS, string vartype, String toS)
		{
			var list = new SortedDictionary<String, Color>();
			var xrad = (int)Math.Ceiling((float)diam / 2);
			var yrad = (int)Math.Ceiling((float)diam / 2);

			for (var y1 = y - yrad; y1 <= y + yrad; y1++)
			{
				if (y1 < 0 || y1 >= I.maxh)
					continue;

				for (var x1 = x - xrad; x1 <= x + xrad; x1++)
				{
					if (x1 < 0 || x1 >= I.maxw)
						continue;

					var from = GetFrom(x1, y1, fromS);
					var sum = 0;
					if ((vartype.Equals(RedOP) || vartype.Equals(AllOP)))
						sum += from.R;

					if (vartype.Equals(GreenOP) || vartype.Equals(AllOP))
						sum += from.G;

					if (vartype.Equals(BlueOP) || vartype.Equals(AllOP))
						sum += from.B;
					var key = sum.ToString();
				retry:

					try
					{
						list[key] = from;
					}
					catch
					{
						key += " ";
						goto retry;
					}
				}
			}

			var count = 0;
			var toC = new Color();

			foreach (var kvp in list)
			{
				if (count == list.Count / 2)
				{
					toC = kvp.Value;
					break;
				}
				count++;
			}
			SetTo(toS, toC);
		}

		private void PerformCustomMatrixOP(String formulaID,String vartype, String fromS, String toS)
		{
			var totR = 0;
			var totG = 0;
			var totB = 0;
			int y2 = 0, x2 = 0;
			var xdiam = storedCustomSizes[formulaID].x;
			var ydiam = storedCustomSizes[formulaID].y;
			var xrad = xdiam / 2;
			var yrad = ydiam / 2;

			for (var y1 = y - yrad; y1 <= y + yrad; y1++)
			{
				if (y1 < 0 || y1 >= I.maxh)
				{
					y2++;
					x2 = 0;
					continue;
				}

				for (var x1 = x - xrad; x1 <= x + xrad; x1++)
				{
					if (x1 < 0 || x1 >= I.maxw)
					{
						x2++;
						continue;
					}

					var from = GetFrom(x1, y1, fromS);

					var a1 = storedCustomFormulas[formulaID][y2][x2];
					//int b1 = storedCustomFormulas[formulaID][x2][y2];
					if ((vartype.Equals(RedOP) || vartype.Equals(AllOP)))
						totR += (int)((from.R * a1));// + (from.R*b1));
					else
						totR = from.R;

					if (vartype.Equals(GreenOP) || vartype.Equals(AllOP))
						totG += (int)((from.G * a1));// + (from.G*b1));
					else
						totG = from.G;

					if (vartype.Equals(BlueOP) || vartype.Equals(AllOP))
						totB += (int)((from.B * a1));// + (from.B*b1));
					else
						totB = from.B;
					x2++;
				}
				y2++;
				x2 = 0;
			}

			totR = Math.Abs(totR);
			totB = Math.Abs(totB);
			totG = Math.Abs(totG);

			if (totR > 255) totR = 255;
			if (totB > 255) totB = 255;
			if (totG > 255) totG = 255;

			SetTo(toS, Color.FromArgb(totR, totG, totB));
		}

		static public bool GetCustomMatricies(IEnumerable<Formula> fl)
		{
			storedCustomFormulas = new Dictionary<string, List<List<float>>>();
			storedCustomSizes = new Dictionary<string, xy>();

			foreach (var f in fl)
			{
				//only for cust nh op
				if (f.type == Operation && f.subtype == CustomNeighbourhoodOperations && storedCustomFormulas.ContainsKey(f.ID) == false)
				{
					try
					{
						storedCustomFormulas.Add(f.ID, matrixeditor.deserialiseMatrix(f.Operations[0]));
					}
					catch (Exception e)
					{
						MessageBox.Show("Error applying matrix:\n" + e.ToString());
						return false;
					}
					
					var x = storedCustomFormulas[f.ID][0].Count;
					var y = storedCustomFormulas[f.ID].Count;
					storedCustomSizes.Add(f.ID, new xy { x = x, y = y });
				}
			}
			return true;
		}

		private void CustNHoperation(Formula f)
		{
			//apply matrix [12321] [?] from [ALL]  from [cOUT] to [cOUT]
			//op 0 is the matrix
			//var custform = storedCustomFormulas[f.ID];

			//op 1 is the from loc

			//op 2 is the var type

			//op 3 is the to loc

			PerformCustomMatrixOP(f.ID, f.Operations[2], f.Operations[1], f.Operations[3]);
		}

		private void PresetNHoperation(Formula f)
		{
			//op 0 is the diameter
			var diam = int.Parse(f.Operations[0]);

			//op 1 is the subsub op (eg mean)
			var mean = false;
			var median = false;
			if (f.Operations[1].Equals(MeanAverage))
				mean = true;
			else if (f.Operations[1].Equals(MedianAverage))
				median = true;

			//op 2 is from
			var fromS = f.Operations[2];

			//op 3 is the var type/r/g/b/all
			var vartype = f.Operations[3];

			//op 4 is the dest
			var toS = f.Operations[4];
			if (mean)
				PerformMeanAverage(diam, fromS, vartype, toS);
			if (median)
				PerformMedianAverage(diam, fromS, vartype, toS);
		}

		
		private void UserPixelOperation(Formula f)
		{
			//op 0 is from variable
			var from = GetFrom(f.Operations[0]);

			//op1 is the subsub operation
			var op = f.Operations[1];

			//op2 is the amount
			
			//op3 is R/G/B/ALL
			var vartype = f.Operations[3];

			//op4 is the dest
			PixelOperation(from, float.Parse(f.Operations[2]), op, vartype, f.Operations[4]);
		}

		private void VarPixelOperation(Formula f)
		{
			//op 0 is from variable
			var from = GetFrom(f.Operations[0]);

			//op1 is the subsub operation
			var op = f.Operations[1];

			//op2 is the amount
			var from2 = GetFrom(f.Operations[2]);

			//op3 is R/G/B/ALL
			var vartype = f.Operations[3];

			//op4 is the dest
			PixelOperation(from, from2.R,from2.G,from2.B, op, vartype, f.Operations[4]);
		}

		private void SwapOperation(Formula f)
		{
			//param 0 is from loc
			var from = GetFrom(f.Operations[0]);

			//param 1 is from var
			var op = f.Operations[1];
			var tot = 0;
			if (op.Equals(Calculations.RedOP))
				tot += from.R;
			else if (op.Equals(Calculations.GreenOP))
				tot += from.G;
			else if (op.Equals(Calculations.BlueOP))
				tot += from.B;
			else if (op.Equals(Calculations.AllOP))
				tot += from.R + from.G + from.B;

			//param 2 is to loc
			
			//param 3 is to var
			var op2 = f.Operations[3];
			var to = GetFrom(f.Operations[2]);
			if (op2.Equals(Calculations.RedOP))
				to = Color.FromArgb(tot, to.G, to.B);
			else if (op2.Equals(Calculations.GreenOP))
				to = Color.FromArgb(to.R,tot,to.B);
			else if (op2.Equals(Calculations.BlueOP))
				to = Color.FromArgb(to.R, to.G,tot);
			else if (op2.Equals(Calculations.AllOP))
				to = Color.FromArgb(tot,tot,tot);

			SetTo(f.Operations[2], to);
		}

		private void MoveOperation(Formula f)
		{
			//param 0 is FROM

			//param 1 is TO

			var from = GetFrom(f.Operations[0]);
			SetTo(f.Operations[1], from);
		}

		private int applyop(int orig,float change, String op)
		{
			float val = 0;
			if (op.Equals(Subtractop))
				val= orig - change;
			else if (op.Equals(Addop))
				val= orig + change;
			else if (op.Equals(Multiplyop))
				val= orig * change;
			else if (op.Equals(Divideop))
				val= orig / change;
			else if (op.Equals(Modulusop))
				val= orig%change;

			return ((int)val);
		}

		private void PixelOperation(Color from1,float amount, String op, String vartype, String toS)
		{
			PixelOperation(from1, amount, amount, amount, op, vartype, toS);

		}
		private void PixelOperation(Color from1,float RV,float GV,float BV, String op, String vartype, String toS)
		{
			int r = from1.R;
			int g = from1.G;
			int b = from1.B;

			if (vartype.Equals(RedOP) || vartype.Equals(AllOP))
			{
				r = applyop(r, RV, op);
			}
			if (vartype.Equals(GreenOP) || vartype.Equals(AllOP))
			{
				g = applyop(g, GV, op);
			}
			if (vartype.Equals(BlueOP) || vartype.Equals(AllOP))
			{
				b = applyop(b, BV, op);
			}
			if (r < 0) r = 0;
			if (g < 0) g = 0;
			if (b < 0) b = 0;
			if (r > 255) r = 255;
			if (g > 255) g = 255;
			if (b > 255) b = 255;
			var to = Color.FromArgb(r, g, b);

			//op4 is the dest
			SetTo(toS, to);
		}

		private static void GetPixelIndex(int x, int y, ref int rx, ref int gx, ref int bx,CustomImage imt)
		{
			int x2;
			switch (imt.Format)
			{
				case PixelFormat.Format24bppRgb:
					x2 = (y * imt.Stride) + (x * 3);
					rx = x2 + 2;
					gx = x2 + 1;
					bx = x2;
					break;
				case PixelFormat.Format32bppArgb:
					x2 = (y * imt.Stride) + (x * 4);
					rx = x2 + 2;
					gx = x2 + 1;
					bx = x2;
					break;
			}
		}

		private void SetPixel(int x, int y, Color newc, CustomImage to)
		{
			if (x >= to.Width || y >= to.Height)
				return;

			int rx = 0, gx = 0, bx = 0;
			GetPixelIndex(x, y, ref rx, ref gx, ref bx,to);
			to.Array[rx] = newc.R;
			to.Array[gx] = newc.G;
			to.Array[bx] = newc.B;
		}

		public static Color GetPixel(int x, int y, CustomImage fromim)
		{
			if (x >= fromim.Width || y >= fromim.Height)
				return new Color();

			int rx = 0, gx = 0, bx = 0;
			GetPixelIndex(x, y, ref rx, ref gx, ref bx, fromim);
			return Color.FromArgb(fromim.Array[rx], fromim.Array[gx], fromim.Array[bx]);
		}

		private Color GetFrom(String fromS)
		{
			return GetFrom(x, y, fromS);
		}
		
		private Color GetFrom(int xv, int yv, String fromS)
		{
			Color from;
			//see if it exists in the image dictionary, if not it is a var
			if (ImageLocations.ContainsKey(fromS)==false)
			{
				if (Variables.ContainsKey(fromS) == false)
					Variables[fromS] = new Color();
				from = Variables[fromS];
			}
			else
			{
				from = GetPixel(xv, yv, ImageLocations[fromS]);
			}

			return from;
		}

		private void SetTo(String toS, Color from)
		{
			//see if it exists in the image dictionary, if not it is a var
			if (ImageLocations.ContainsKey(toS) == false)
			{
				if (Variables.ContainsKey(toS) == false)
					Variables[toS] = new Color();

				Variables[toS] = from;
			}
			else
			{
				SetPixel(x, y, from, ImageLocations[toS]);
			}
		}

		public static void Initcalculations(List<Formula> formulasin, ref Information iIN)
		{
			Formulas = formulasin;
			I = iIN;
		}

		public static String FormulaChecks(IEnumerable<Formula> flist,Dictionary<int, ImagePanel> images)
		{
			//general checks
			var foundoutput = false;
			var ifcount = 0;
			foreach (var f in flist)
			{
				if (f.type.Equals(Conditionoperation))
				{
					if (f.subtype.Equals(Ifcolcondition)||f.subtype.Equals(Ifposcondition))
						ifcount++;
					else if (f.subtype.Equals(Endifcondition))
						ifcount--;
				}
				foreach (var s in f.Operations)
				{
					if (s.StartsWith(Imageimage))
					{
						var s2 = int.Parse(s.Substring(Imageimage.Length));
						//referenced image doesnt exist
						if (images.ContainsKey(s2) == false)
						{
							return s + " is not loaded";
						}
					}
					else if (s.Equals(CurrentpixelOut))
						foundoutput = true;
				}
			}
			if (foundoutput == false)
				return "Error, there is no output assignment, nothing will be created";
			if (ifcount != 0)
				return "Error, must be an equal number of if/endifs ";
			
			return "";
		}

	}
}