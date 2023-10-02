using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject15
{
    class GetInputFromUser
    {
        public static void GetInput<T>(string message, out T? result)
        {
            int count = 3;
            while (true)
            {
                if (count == 0)
                {
                    result = default(T);
                }
                count--;
                try
                {
                    Console.Write(message);
                    string? input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input)) { throw new Exception("Empty input"); }
                    try
                    {
                        result = (T?)Convert.ChangeType(input, typeof(T)) ?? throw new NullReferenceException();
                    }
                    catch
                    {
                        throw;
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
    internal class Department
    {
        public string Name { get; set; }
        public List<Student> students;

        public Department(string name)
        {
            Name = name;
            this.students = new List<Student>();
        }
        public void AddStudent()
        {
            Student s;
            GetInputFromUser.GetInput<string>("Input ID: ", out var id);
            GetInputFromUser.GetInput<string>("Input name: ", out var name);
            GetInputFromUser.GetInput<DateTime>("Input date of birth: ", out var date);
            GetInputFromUser.GetInput<int>("Input entry year: ", out var year);
            GetInputFromUser.GetInput<double>("Input entry point: ", out var entryPoint);
            GetInputFromUser.GetInput<bool>("Is In-service student?(true/false): ", out var isInService);
            if (isInService)
            {
                GetInputFromUser.GetInput<string>("Input location: ", out var location);
                s = new InServiceStudent(name, id, date, year, entryPoint, location);
            }
            else
            {
                s = new Student(name, id, date, year, entryPoint);
            }
            while (true)
            {
                GetInputFromUser.GetInput<string>("Add result infor? (y/n): ", out var adding);
                if (adding.ToLower() == "y")
                {
                    GetInputFromUser.GetInput<string>("Input semester: ", out var semester);
                    GetInputFromUser.GetInput<double>("Input average point of semester " + semester + ": ", out var avgPoint);
                    s.results.Add(new Result(semester, avgPoint));
                }
                else if (adding.ToLower() == "n")
                {
                    break;
                }
                else
                {
                    throw new Exception("Invalid option");
                }
            }
            students.Add(s);
        }
        public void PrintAll()
        {
            students.ForEach(Console.WriteLine);
        }
        public bool IsFormal(Student s)
        {
            return s.GetType() == typeof(Student);
        }
        public Student? GetStudentByID (string id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
        public double GetResultBySemester (string semester, Student s)
        {
            var student = s.results.FirstOrDefault(item => item.Semester == semester) ?? throw new Exception("This semester has no record");
            return student.AvgPoint;
        }
        public int CountFormalStudent()
        {
            return students.Where(IsFormal).Count();
        }
        public Student? FindTopEntry()
        {
            return students.MaxBy(s => s.EntryPoint);
        }
        public List<InServiceStudent> GetListInserviceByLocation(string location)
        {
            return students.Where(s => !IsFormal(s))
                .Select(s => (InServiceStudent)s)
                .Where(s => s.Location == location)
                .ToList();
        }
        public List<Student> GetGoodStudentList()
        {
            return students.Where(s => s.results.Count > 0)
                .Where(s => s.results.Last().AvgPoint >= 8.0)
                .ToList();
        }
        public Student? GetBestStudent()
        {
            return students.Where(s => s.results.Count > 0)
                .MaxBy(s => s.results.MaxBy(r => r.AvgPoint));
        }
        public List<Student> SortByYearAndEntry()
        {
            return students.OrderBy(s => s.EntryPoint).ThenByDescending(s => s.Year).ToList();
        }
        public void PrintNumberAllYear()
        {
            var list = students.GroupBy(s => s.Year)
                .Select(s => new { Year = s.Key, Count = s.Count(student => student.Year == s.Key) });
            
            foreach (var item in list)
            {
                Console.WriteLine(item.Year + ": " + item.Count);
            }
        }
    }
}
