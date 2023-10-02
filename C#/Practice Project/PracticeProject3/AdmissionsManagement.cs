using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
class InvalidInputException : Exception
{
	public InvalidInputException() : base("Invalid input") { }
}
enum StudentClass
{
	A, B, C
}

namespace PracticeProject3
{
	internal class AdmissionsManagement
	{
		private List<Student> students = new List<Student>();
		public void AddNewStudent()
		{
			// get id
			Console.Write("Input id: ");
			string? id = Console.ReadLine();
			if (String.IsNullOrEmpty(id)) { throw new InvalidInputException(); }

			// get name 
			Console.Write("Input name: ");
			string? name = Console.ReadLine();
			if (String.IsNullOrEmpty(name)) { throw new InvalidInputException(); }

			// get address
			Console.Write("Input address: ");
			string? address = Console.ReadLine();
			if (String.IsNullOrEmpty(address)) { throw new InvalidInputException(); }

			// get priority
			Console.Write("Input priority: ");
			int priority = Convert.ToInt32(Console.ReadLine());
			if (priority < 0) { throw new InvalidInputException(); }

			// get position
			Console.Write("Insert student class (A, B, C): ");
			if (Enum.TryParse<StudentClass>(Console.ReadLine(), ignoreCase: true, out var op)
				&& Enum.IsDefined<Option>(op))
			{
				Func<double, double> validEntryPoint = (double p) =>
				{
					if (p < 0 || p > 10) { throw new InvalidInputException(); }
					return p;
				};
				switch (op)
				{
					case StudentClass.A:
						{
							Console.Write("Input math: ");
							double p1 = validEntryPoint(Convert.ToDouble(Console.ReadLine()));
							Console.Write("Input phys: ");
							double p2 = validEntryPoint(Convert.ToDouble(Console.ReadLine()));
							Console.Write("Input chem: ");
							double p3 = validEntryPoint(Convert.ToDouble(Console.ReadLine()));
							students.Add(new ClassA(id, name, address, priority, p1, p2, p3));
							break;
						}
					case StudentClass.B:
						{
							Console.Write("Input math: ");
							double p1 = validEntryPoint(Convert.ToDouble(Console.ReadLine()));
							Console.Write("Input chem: ");
							double p2 = validEntryPoint(Convert.ToDouble(Console.ReadLine()));
							Console.Write("Input biol: ");
							double p3 = validEntryPoint(Convert.ToDouble(Console.ReadLine()));
							students.Add(new ClassB(id, name, address, priority, p1, p2, p3));
							break;
						} 
					case StudentClass.C:
						{
							Console.Write("Input lite: ");
							double p1 = validEntryPoint(Convert.ToDouble(Console.ReadLine()));
							Console.Write("Input hist: ");
							double p2 = validEntryPoint(Convert.ToDouble(Console.ReadLine()));
							Console.Write("Input geog: ");
							double p3 = validEntryPoint(Convert.ToDouble(Console.ReadLine()));
							students.Add(new ClassC(id, name, address, priority, p1, p2, p3));
							break;
						}
					default:
						throw new InvalidInputException();
				}
			}
			else
			{
				throw new InvalidInputException();
			}
		}
		public void PrintListStudent()
		{
			if (students.Count == 0)
			{
                Console.WriteLine("Empty list");
            }
			else
			{
				students.ForEach(student => { Console.WriteLine(student); });
			}
		}
		public Student GetStudentByID(string id)
		{
			if (students.Count == 0)
			{
				Console.WriteLine("List empty");
			}
			return students.FirstOrDefault(o => o.Id == id) ?? throw new NullReferenceException("Not found");
		}
	}
}
