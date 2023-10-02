using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject1
{
	internal class Worker : Officer
	{
		public int Grade { get; set; }
		public Worker(string name, int age, bool sex, string address, int grade) : base(name, age, sex, address)
		{
			Grade = grade;
		}

		public override string ToString()
		{
			return base.ToString() + "\nGrade: " + Grade;
		}
	}
}
