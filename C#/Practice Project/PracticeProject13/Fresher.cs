using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject13
{
    internal class Fresher : Employee
    {
        public Fresher(string id, FullName fullName, DateTime birthday, PhoneNumber phone, MailAddress email,
            DateTime graduationDate, string granduationRank, string education) 
            : base(id, fullName, birthday, phone, email)
        {
            GraduationDate = graduationDate;
            GraduationRank = granduationRank;
            Education = education;
        }

        public DateTime GraduationDate { get; set; }
        public string GraduationRank { get; set; }
        public string Education { get; set; }

        public override string? ToString()
        {
            return base.ToString() +
                "\nGraduation Date: " + GraduationDate +
                "\nGraduation Rank: " + GraduationRank + 
                "\nEducation: " + Education;
        }
    }
}
