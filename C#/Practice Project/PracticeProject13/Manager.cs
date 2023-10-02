using System.Collections.Generic;
using System.Net.Mail;
using System.Reflection;

namespace PracticeProject13
{
    enum Position
    {
        Experience = 0, Fresher = 1, Intern = 2
    }
    enum CertificateOption
    {
        Add = 1, Esc = 2
    }
    internal class Manager
    {
        public List<Employee> employeelist;
        public Manager()
        {
            employeelist = new List<Employee>();
        }
        public void AddNewEmployee()
        {
            Employee e = null;
            Console.WriteLine("\n");
            InputFromConsole.GetInput<string>("Input ID: ", out string? id);
            InputFromConsole.GetInput<FullName>("Input name: ", out FullName name);
            InputFromConsole.GetInput<DateTime>("Input birthday: ", out DateTime bday);
            InputFromConsole.GetInput<PhoneNumber>("Input phone number: ", out PhoneNumber phone);
            InputFromConsole.GetInput<MailAddress>("Input email address: ", out MailAddress? mail);
            while (true)
            {
                try
                {
                    Console.Write("Insert position: ");
                    if (Enum.TryParse<Position>(Console.ReadLine(), ignoreCase: true, out Position op)
                        && Enum.IsDefined<Position>(op))
                    {
                        switch (op)
                        {
                            case Position.Experience:
                                InputFromConsole.GetInput<int>("Input Exp in year: ", out int eiyear);
                                InputFromConsole.GetInput<string>("Input professional skill: ", out string? pro);
                                e = new Experience(id, name, bday, phone, mail, eiyear, pro);
                                break;
                            case Position.Fresher:
                                InputFromConsole.GetInput<DateTime>("Input graduation date: ", out DateTime date);
                                InputFromConsole.GetInput<string>("Input granduation rank: ", out string? rank);
                                InputFromConsole.GetInput<string>("Input education: ", out string? edu);
                                e = new Fresher(id, name, bday, phone, mail, date, rank, edu);
                                break;
                            case Position.Intern:
                                InputFromConsole.GetInput<string>("Input major: ", out string? major);
                                InputFromConsole.GetInput<string>("Input semester: ", out string? semester);
                                InputFromConsole.GetInput<string>("Input university: ", out string? university);
                                e = new Intern(id, name, bday, phone, mail, major, semester, university);
                                break;
                        }
                        break;
                    }
                    else
                    {
                        throw new Exception("Option invalid");
                    }
                }
                catch
                {
                    throw;
                }
            }
            while(true)
            {
                Console.Write("Insert certificate option (Add, Esc): ");
                if (Enum.TryParse<CertificateOption>(Console.ReadLine(), ignoreCase: true, out CertificateOption op)
                        && Enum.IsDefined<CertificateOption>(op))
                {
                    switch (op)
                    {
                        case CertificateOption.Add:
                            InputFromConsole.GetInput<string>("Input cert name: ", out string? cname);
                            InputFromConsole.GetInput<string>("Input cert ID: ", out string? cid);
                            InputFromConsole.GetInput<string>("Input cert rank: ", out string? crank);
                            InputFromConsole.GetInput<DateTime>("Input cert date: ", out DateTime cdate);
                            e.certList.Add(new Certificate(cid, cname, crank, cdate));
                            break;
                        case CertificateOption.Esc:
                            employeelist.Add(e);
                            return;
                    }

                }

            }

        }
        public void PrintListEmployee()
        {
            employeelist.ForEach(e => Console.WriteLine(e));
        }
        public int GetTotalEmployee()
        {
            return Employee.count;
        }
        public Employee? GetEmployeeByID(string id)
        {
            if (employeelist.Count == 0)
            {
                Console.WriteLine("list empty");
            }
            return employeelist.FirstOrDefault(e => e.Id == id) ?? throw new NullReferenceException("Not found");
        } 

        public void EditInfor(Employee employee)
        {
            if (employee is null)
            {
                throw new NullReferenceException();
            }
            Console.Write("Employee information: ");
            Console.WriteLine(employee);
            Console.WriteLine("\nChoose field to edit: ");
            var field = employee.GetType().GetProperties().Select(f => f.Name).ToList();
            field.ForEach(f => { Console.WriteLine(f); });
            InputFromConsole.GetInput<string>("Input field: ", out string? editField);
            if (field.ConvertAll(d => d.ToLower()).Contains(editField.ToLower()))
            {
                var current = field.First(f => f.ToLower() == editField.ToLower());
                PropertyInfo? prop = employee.GetType().GetProperty(current) ?? throw new NullReferenceException();
                InputFromConsole.GetInput<string>("Input new field content: ", out var content);
                var newProp = InputFromConsole.ConvertTo(content, prop.PropertyType);
                prop.SetValue(employee, newProp);
            }
            else
            {
                throw new Exception("Invalid input");
            }
            Console.WriteLine("Edit success! \nNew Information: \n" + employee);
        }
        public void RemoveEmployee (Employee e)
        {
            employeelist.Remove(e);
            Console.WriteLine("Remove success!");
        }
        public List<Employee> GetInternList()
        {
            var list = employeelist.Where(e => e.GetType() == typeof(Intern)).ToList();
            if (list.Count == 0)
            {
                Console.WriteLine("No employee intern found");
            }
            return list;
        }
        public List<Employee> GetFresherList()
        {
            var list = employeelist.Where(e => e.GetType() == typeof(Fresher)).ToList();
            if (list.Count == 0)
            {
                Console.WriteLine("No employee fresher found");
            }
            return list;
        }
        public List<Employee> GetExperienceList()
        {
            var list = employeelist.Where(e => e.GetType() == typeof(Experience)).ToList();
            if (list.Count == 0)
            {
                Console.WriteLine("No employee experience found");
            }
            return list;
        }
    }
}
