using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject4
{
	internal class Residence
	{
		public int HouseNumber { get; set; }
		public List<Citizen> citizens;
		public int Num
		{
			get { return citizens.Count; }
		}

		public Residence(int houseNumber)
		{
			HouseNumber = houseNumber;
			this.citizens = new List<Citizen>();
		}

		public Citizen GetCitizenByID (string id)
		{
			if (Num == 0) {
                Console.WriteLine("Empty list");
            }
			return citizens.FirstOrDefault(c => c.Id == id);
		}

		public override string? ToString()
		{
			StringBuilder temp = new StringBuilder("\n\nHouse No: " + HouseNumber);
			citizens.ForEach(c => temp.Append(c));
			return temp.ToString() ;
		}
	}
}
