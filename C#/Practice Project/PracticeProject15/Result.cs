using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject15
{
    internal class Result
    {
        public string Semester {  get; set; }
        public double AvgPoint { get; set; }

        public Result(string semester, double avgPoint)
        {
            Semester = semester;
            AvgPoint = avgPoint;
        }
    }
}
