using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject13
{
    internal abstract class Employee
    {
        public static string[] types = { "Experience", "Fresher", "Intern" };
        public static int count = 0;
        public string Id { get; set; }
        public FullName FullName { get; set; }
        public DateTime Birthday { get; set; }
        public PhoneNumber Phone { get; set; }
        public MailAddress Email { get; set; }
        public List<Certificate> certList;

        public Employee(string id, FullName fullName, DateTime birthday, PhoneNumber phone, MailAddress email)
        {
            Id = id;
            FullName = fullName;
            Birthday = birthday;
            Phone = phone;
            Email = email;
            certList = new List<Certificate>();
            count++;
        }

        public override string? ToString()
        {
            StringBuilder listCertificate = new StringBuilder();
            certList.ForEach(c => listCertificate.Append(c + "\n"));
            return "\nId: " + Id +
                "\nFull name: " + FullName + 
                "\nBirthday: " + Birthday + 
                "\nPhone: " + Phone + 
                "\nEmail: " + Email + 
                "\nCertificate List:\n" + listCertificate;
        }
    }
}
