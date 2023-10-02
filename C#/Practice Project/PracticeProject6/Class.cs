using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject6
{
    internal class Class
    {
        public string ClassName {  get; set; }
        public List<Student> students;

        public Class(string className)
        {
            ClassName = className;
            this.students = new List<Student>();
        }

        public override string? ToString()
        {
            StringBuilder temp = new StringBuilder("\nClass: " + ClassName);
            students.ForEach(student => { temp.Append(student); });
            return temp.ToString();
        }
    }
}
