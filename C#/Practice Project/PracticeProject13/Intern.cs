using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject13
{
    internal class Intern : Employee
    {
        public Intern(string id, FullName fullName, DateTime birthday, PhoneNumber phone, MailAddress email,
            string major, string semester, string university) : base(id, fullName, birthday, phone, email)
        {
            Major = major;
            Semester = semester;
            University = university;
        }

        public string Major { get; set; }
        public string Semester { get; set; }
        public string University { get; set; }

        public override string? ToString()
        {
            return base.ToString() +
                "\nMajor: " + Major +
                "\nSemester: " + Semester +
                "\nUniversity: " + University;
        }
    }
}
