using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject3
{
	internal class Student
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public int Priority { get; set; }

		public Student(string id, string name, string address, int priority)
		{
			Id = id;
			Name = name;
			Address = address;
			Priority = priority;
		}

		public override string? ToString()
		{
			return "\nID: " + Id + 
				"\nName: " + Name +
				"\nAddress: " + Address +
				"\nPriority: " + Priority;
		}
	}
}
