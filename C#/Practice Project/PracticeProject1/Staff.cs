using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject1
{
	internal class Staff : Officer
	{
		public string Task {  get; set; }
		public Staff(string name, int age, bool sex, string address, string task) : base(name, age, sex, address)
		{
			Task = task;
		}

		public override string ToString()
		{
			return base.ToString() + "\nTask: " + Task;
		}
	}
}
