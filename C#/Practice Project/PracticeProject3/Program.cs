using PracticeProject3;
enum Option
{
	Add = 1, Find = 2, Print = 3, Esc = 4
}
class Program
{
	public static void Main(string[] args)
	{
		AdmissionsManagement admin = new AdmissionsManagement();
		while (true)
		{
			try
			{
				Console.Write("Insert option (Add, Find, Print, Esc): ");
				if (Enum.TryParse<Option>(Console.ReadLine(), ignoreCase: true, out var op)
					&& Enum.IsDefined<Option>(op))
				{
					switch (op)
					{
						case Option.Add:
							admin.AddNewStudent();
							break;
						case Option.Find:
                            Console.WriteLine("Input ID: ");
                            string? id = Console.ReadLine();
							if (string.IsNullOrEmpty(id)) { throw new Exception("No input found"); }
							admin.GetStudentByID(id);
							break;
						case Option.Print:
							admin.PrintListStudent();
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