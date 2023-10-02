using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PracticeProject4
{
	internal class City
	{
		public List<Residence> residences;

		public City()
		{
			this.residences = new List<Residence>();
		}

		public void NewResidence()
		{
			// get house number
			Console.Write("Input house number: ");
			int house = Convert.ToInt32(Console.ReadLine());
			if (house < 0) { throw new InvalidInputException(); }

			Residence residence = new Residence(house);
			NewCitizen(residence);
            residences.Add(residence);
		}
		public void NewCitizen(Residence residence)
		{
			while (true)
			{
				try
				{
					// get id
					Console.Write("Input ID: ");
					string? id = Console.ReadLine();
					if (String.IsNullOrEmpty(id)) { throw new InvalidInputException(); }

					//Console.WriteLine(residences.ForEach((r) => { Console.WriteLine(r.GetCitizenByID(id)); }));

					if (residences.Any(r => r.GetCitizenByID(id) != null))
					{
						throw new InputDuplicateException();
					}

					// get name
					Console.Write("Input name: ");
					string? name = Console.ReadLine();
					if (String.IsNullOrEmpty(name)) { throw new InvalidInputException(); }

					// get age
					Console.Write("Input age: ");
					int age = Convert.ToInt32(Console.ReadLine());
					if (age < 0) { throw new InvalidInputException(); }

					// get job
					Console.Write("Input job: ");
					string? job = Console.ReadLine();
					if (String.IsNullOrEmpty(job)) { throw new InvalidInputException(); }

					residence.citizens.Add(new Citizen(name, age, job, id));

					

					Console.WriteLine("Add more? Y/N");
					if (Console.ReadLine().ToLower() == "y")
					{
						continue;
					}
					else
					{
						break;
					}
				}
				catch (Exception e)
				{
                    Console.WriteLine(e.Message);
                }
			}
		}

		public override string? ToString()
		{
			StringBuilder temp = new StringBuilder();
			residences.ForEach(r => { temp.Append(r); });
			return temp.ToString();
		}
	}
}
