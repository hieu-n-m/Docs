using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject4
{
	internal class Citizen
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Job { get; set; }
		public string Id { get; set; }

		public Citizen(string name, int age, string job, string id)
		{
			Name = name;
			Age = age;
			Job = job;
			Id = id;
		}
		public override string ToString()
		{
			return "\nName: " + Name +
				"\nAge: " + Age +
				"\nJob: " + Job + 
				"\nId: " + Id;
		}
		
	}
}
