using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject3
{
	internal class ClassA : Student
	{
		public double Math { get; set; }
		public double Phys { get; set; }
		public double Chem { get; set; }

		public ClassA(string id, string name, string address, int priority, double math, double phys, double chem)
			: base(id, name, address, priority)
		{
			Math = math;
			Phys = phys;
			Chem = chem;
		}

		public override string? ToString()
		{
			return base.ToString() + "\nClass A";
		}
	}
}
