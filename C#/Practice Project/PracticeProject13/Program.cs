using PracticeProject13;
using System;
using System.Collections;
using System.Net.Mail;
using System.Numerics;
using System.Reflection;
using System.Threading.Channels;
using System.Xml.Linq;

class Program
{
    enum Option
    {
        Add = 1, Edit = 2, Remove = 3, 
        PrintIntern = 4, PrintFresher = 5, PrintExperience = 6,
        Esc = 7
    }
    public static void Main(string[] args)
    {
        Manager manager = new Manager();
        while (true)
        {
            try
            {
                Console.Write("Insert option (Add, Edit, Remove, PrintIntern, PrintFresher, PrintExperience, Esc): ");
                if (Enum.TryParse<Option>(Console.ReadLine(), ignoreCase: true, out var op)
                    && Enum.IsDefined<Option>(op))
                {
                    switch (op)
                    {
                        case Option.Add:
                            manager.AddNewEmployee();
                            break;
                        case Option.Edit:
                            {
                                InputFromConsole.GetInput<string>("\nInput ID: ", out string? id);
                                Employee? e = manager.GetEmployeeByID(id);
                                manager.EditInfor(e);
                                break;
                            }
                        case Option.Remove:
                            {
                                InputFromConsole.GetInput<string>("\nInput ID: ", out string? id);
                                Employee? e = manager.GetEmployeeByID(id);
                                manager.RemoveEmployee(e);
                                break;
                            }
                        case Option.PrintIntern:
                            manager.GetInternList().ForEach(e => { Console.WriteLine(e); });
                            break;
                        case Option.PrintFresher:
                            manager.GetFresherList().ForEach(e => { Console.WriteLine(e); });
                            break;
                        case Option.PrintExperience:
                            manager.GetExperienceList().ForEach(e => { Console.WriteLine(e); });
                            break;
                        case Option.Esc:
                            return;
                    }
                }
                else
                {
                    throw new Exception("Option invalid");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
