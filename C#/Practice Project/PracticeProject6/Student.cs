using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject6
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Home { get; set; }

        public Student(string name, int age, string home)
        {
            Name = name;
            Age = age;
            Home = home;
        }

        public override string? ToString()
        {
            return "\nName: " + Name +
                "\nAge: " + Age + 
                "\nHometown: " + Home;
        }
    }
}
