class InvalidInputException : Exception
{
    public InvalidInputException() : base("Invalid input") { }
}
enum OfficerType
{
    Worker, Engineer, Staff
}

namespace PracticeProject1
{
    internal class Management
    {
        private List<Officer> officers = new List<Officer>();
        public void AddNewOfficer()
        {
            // get name 
            Console.Write("Input name: ");
            string? name = Console.ReadLine();
            if (String.IsNullOrEmpty(name)) { throw new InvalidInputException(); }

            // get age 
            Console.Write("Input age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            if (age < 1) { throw new InvalidInputException(); }

            // get sex
            Console.Write("Is male?: ");
            bool sex, check = bool.TryParse(Console.ReadLine(), out sex);
            if (!check) { throw new InvalidInputException(); }

            // get address
            Console.Write("Input address: ");
            string? address = Console.ReadLine();
            if (String.IsNullOrEmpty(address)) { throw new InvalidInputException(); }

            // get position
            Console.Write("Insert officer type (Worker, Engineer, Staff): ");
            if (Enum.TryParse<OfficerType>(Console.ReadLine(), ignoreCase: true, out var op)
                && Enum.IsDefined<OfficerType>(op))
            {

                switch (op)
                {
                    case OfficerType.Worker:
                        Console.Write("Input grade (1 - 10): ");
                        int grade = Convert.ToInt32(Console.ReadLine());
                        if (grade < 1 || grade > 10) { throw new InvalidInputException(); }
                        officers.Add(new Worker(name, age, sex, address, grade));
                        break;

                    case OfficerType.Engineer:
                        Console.Write("Input major: ");
                        string? major = Console.ReadLine();
                        if (String.IsNullOrEmpty(major)) { throw new InvalidInputException(); }
                        officers.Add(new Engineer(name, age, sex, address, major));
                        break;

                    case OfficerType.Staff:
                        Console.Write("Input task: ");
                        string? task = Console.ReadLine();
                        if (String.IsNullOrEmpty(task)) { throw new InvalidInputException(); }
                        officers.Add(new Staff(name, age, sex, address, task));
                        break;
                }
            }
            else
            {
                throw new Exception("Invalid option");
            }
        }
        public Officer GetOfficerByName(string name)
        {
            if (officers.Count == 0)
            {
                Console.WriteLine("List empty");
            }
            return officers.FirstOrDefault(o => o.Name == name) ?? throw new NullReferenceException("Not found");
        }
        public void PrintListOfficers()
        {
            if (officers.Any())
            {
                officers.ToList().ForEach(o => Console.WriteLine(o));
            }
            else
            {
                Console.WriteLine("List empty");
            }
        }

    }
}
