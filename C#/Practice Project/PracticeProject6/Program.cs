using PracticeProject6;
class InvalidInputException : Exception
{
    public InvalidInputException() : base("Invalid input")
    {

    }
}
class InputDuplicateException : Exception
{
    public InputDuplicateException() : base("Duplicated")
    {

    }
}
enum Option
{
    Add = 1, Find = 2, Count = 3, Esc = 4
}
class Program 
{
    public static void Main(string[] args)
    {
        School admin = new School();
        while (true)
        {
            try
            {
                Console.Write("Insert option (Add, Find, Count, Esc): ");
                if (Enum.TryParse<Option>(Console.ReadLine(), ignoreCase: true, out var op)
                    && Enum.IsDefined<Option>(op))
                {
                    switch (op)
                    {
                        case Option.Add:
                            admin.NewClass();
                            break;
                        case Option.Find:
                            admin.classes.ForEach(c =>
                            {
                                foreach (var item in c.students.Where(s => s.Age == 20))
                                {
                                    Console.WriteLine(item);
                                }
                            });
                            break;
                        case Option.Count:
                            int total = 0;
                            admin.classes.ForEach(c =>
                            {
                                total += c.students.Where(s => s.Age == 23 && s.Home == "DN").Count();
                            });
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