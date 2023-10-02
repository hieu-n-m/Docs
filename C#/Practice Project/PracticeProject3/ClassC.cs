using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject3
{
	internal class ClassC : Student
	{
		public double Lite { get; set; }
		public double Hist { get; set; }
		public double Geog { get; set; }

		public ClassC(string id, string name, string address, int priority, double lite, double hist, double geog)
			: base(id, name, address, priority)
		{
			Lite = lite;
			Hist = hist;
			Geog = geog;
		}

		public override string? ToString()
		{
			return base.ToString() + "\nClass C";
		}
	}
}
