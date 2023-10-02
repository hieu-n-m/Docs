using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject3
{
	internal class ClassB : Student
	{
		public double Math { get; set; }
		public double Biol { get; set; }
		public double Chem { get; set; }

		public ClassB(string id, string name, string address, int priority, double math, double biol, double chem)
			: base(id, name, address, priority)
		{
			Math = math;
			Biol = biol;
			Chem = chem;
		}

		public override string? ToString()
		{
			return base.ToString() + "\nClass B";
		}
	}
}
