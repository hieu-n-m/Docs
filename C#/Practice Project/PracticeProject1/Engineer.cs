using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject1
{
	internal class Engineer : Officer
	{
		string Major {  get; set; }
		public Engineer(string name, int age, bool sex, string address, string major) : base(name, age, sex, address)
		{
			Major = major;
		}

		public override string ToString()
		{
			return base.ToString() + "\nMajor: " + Major;
		}
	}
}
