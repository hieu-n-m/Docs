using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject6
{
    internal class School
    {
        public List<Class> classes;

        public School()
        {
            classes = new List<Class>();
        }
        public void NewClass()
        {
            // get class name
            Console.Write("Input class name: ");
            string? className = Console.ReadLine();
            if (String.IsNullOrEmpty(className)) { throw new InvalidInputException(); }

            Class newClass = new Class(className);
            NewStudent(newClass);
            classes.Add(newClass);
        }

        public void NewStudent(Class newClass)
        {
            while (true)
            {
                try
                {
                    // get name
                    Console.Write("Input name: ");
                    string? name = Console.ReadLine();
                    if (String.IsNullOrEmpty(name)) { throw new InvalidInputException(); }

                    // get age
                    Console.Write("Input age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    if (age < 0) { throw new InvalidInputException(); }

                    // get home
                    Console.Write("Input hometown: ");
                    string? home = Console.ReadLine();
                    if (String.IsNullOrEmpty(home)) { throw new InvalidInputException(); }

                    newClass.students.Add(new Student(name, age, home));

                    Console.WriteLine("Add more? Y/N");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public override string? ToString()
        {
            StringBuilder temp = new StringBuilder();
            classes.ForEach(c => { temp.Append(c); });
            return temp.ToString();
        }
    }
}
