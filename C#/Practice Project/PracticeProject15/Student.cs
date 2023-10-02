using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject15
{
    internal class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Year {  get; set; }
        public double EntryPoint { get; set; }
        public List<Result> results;

        public Student(string name, string id, DateTime dateOfBirth, int year, double entryPoint)
        {
            Name = name;
            Id = id;
            DateOfBirth = dateOfBirth;
            Year = year;
            EntryPoint = entryPoint;
            results = new List<Result>();
        }

        public override string? ToString()
        {
            return "Name: " + Name +
                "\nID: " + Id + 
                "\nDate of birth: " + DateOfBirth + 
                "\nEntry year: " + Year + 
                "\nEntry point: " + EntryPoint;
        }
    }
}
