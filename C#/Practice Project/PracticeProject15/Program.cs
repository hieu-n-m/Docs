using PracticeProject15;
using System.Collections.Generic;

class Program
{
    enum Option
    {
        Add = 1, PrintAll = 2, CheckFormalStudent = 3, GetResultBySemester = 4, CountFormalStudent = 5,
        FindTopEntryPoint = 6, PrintInServiceByLocation = 7, PrintGoodStudent = 8, PrintBestStudent = 9,
        SortByYearAndEntry = 10, CountByYear = 11, Esc = 12
    }
    public static void Main(string[] args)
    {
        Department admin = new Department("Name of Department");
        while (true)
        {
            try
            {
                Console.WriteLine("\n--------------------");
                Console.Write("Option list:" +
                    "\n1.Add" +
                    "\n2.PrintAll" +
                    "\n3.CheckFormalStudent" +
                    "\n4.GetResultBySemester" +
                    "\n5.CountFormalStudent" +
                    "\n6.FindTopEntryPoint" +
                    "\n7.PrintInServiceByLocation" +
                    "\n8.PrintGoodStudent" +
                    "\n9.PrintBestStudent" +
                    "\n10.SortByYearAndEntry" +
                    "\n11.CountByYear" +
                    "\n12.Esc" +
                    "\nInsert option: ");
                if (Enum.TryParse<Option>(Console.ReadLine(), ignoreCase: true, out var op)
                    && Enum.IsDefined<Option>(op))
                {
                    Console.Write("\n");
                    switch (op)
                    {
                        case Option.Add:
                            admin.AddStudent();
                            break;
                        case Option.PrintAll:
                            admin.PrintAll();
                            break;
                        case Option.CheckFormalStudent:
                            {
                                GetInputFromUser.GetInput<string>("Input id: ", out var id);
                                var s = admin.GetStudentByID(id) ?? throw new Exception("Not found");
                                Console.WriteLine(admin.IsFormal(s));
                                break;
                            }
                        case Option.GetResultBySemester:
                            {
                                GetInputFromUser.GetInput<string>("Input id: ", out var id);
                                var s = admin.GetStudentByID(id) ?? throw new Exception("Not found");
                                GetInputFromUser.GetInput<string>("Input semester: ", out var semester);
                                Console.WriteLine(admin.GetResultBySemester(semester, s));
                                break;
                            }
                        case Option.CountFormalStudent:
                            {
                                Console.WriteLine("Number of Formal student: " + admin.CountFormalStudent());
                                break;
                            }
                        case Option.FindTopEntryPoint:
                            {
                                Console.WriteLine(admin.FindTopEntry() ?? throw new Exception("Not found"));
                                break;
                            }
                        case Option.PrintInServiceByLocation:
                            {
                                GetInputFromUser.GetInput<string>("Input id: ", out var location);
                                var list = admin.GetListInserviceByLocation(location);
                                if (list.Count == 0)
                                {
                                    throw new Exception("Not found");
                                }
                                else
                                {
                                    list.ForEach(Console.WriteLine);
                                }
                                break;
                            }
                        case Option.PrintGoodStudent:
                            {
                                var list = admin.GetGoodStudentList();
                                if (list.Count == 0)
                                {
                                    throw new Exception("Not found");
                                }
                                else
                                {
                                    list.ForEach(Console.WriteLine);
                                }
                                break;
                            }

                        case Option.PrintBestStudent:
                            {
                                var s = admin.GetBestStudent() ?? throw new Exception("Not found");
                                Console.WriteLine(s);
                                break;
                            }

                        case Option.SortByYearAndEntry:
                            {
                                var list = admin.SortByYearAndEntry();
                                if (list.Count == 0)
                                {
                                    throw new Exception("Not found");
                                }
                                else
                                {
                                    list.ForEach(Console.WriteLine);
                                }
                                break;
                            }

                        case Option.CountByYear:
                            {
                                admin.PrintNumberAllYear();
                                break;
                            }
                        case Option.Esc:
                            return;
                    }
                }
                else
                {
                    throw new Exception("Option is invalid");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}