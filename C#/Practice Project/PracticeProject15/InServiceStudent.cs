using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject15
{
    internal class InServiceStudent : Student
    {
        public InServiceStudent(string name, string id, DateTime dateOfBirth, int year, double entryPoint, string location) : base(name, id, dateOfBirth, year, entryPoint)
        {
            Location = location;
        }

        public string Location { get; set; }

        public override string? ToString()
        {
            return base.ToString() + "\nLocation: " + Location;
        }
    }
}
