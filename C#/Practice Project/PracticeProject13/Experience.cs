using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject13
{
    internal class Experience : Employee
    {
        public Experience(string id, FullName fullName, DateTime birthday, PhoneNumber phone, MailAddress email, int expInYear, string skill) 
            : base(id, fullName, birthday, phone, email)
        {
            ExpInYear = expInYear;
            ProSkill = skill;
        }

        public int ExpInYear { get; set; }
        public string ProSkill { get; set; }

        public override string? ToString()
        {
            return base.ToString() + 
                "\nExp In Year: " + ExpInYear +
                "\nProfessional Skill: " + ProSkill;
        }
    }
}
