using PracticeProject1;

enum Option
{
	Add = 1, Find = 2, Print = 3, Esc = 4
}

class Program
{
	public static void Main(string[] args)
	{	
		Management officers = new Management();
		while (true)
		{
			try
			{
				Console.Write("Insert option (Add, Find, Print, Esc): ");
				if (Enum.TryParse<Option>(Console.ReadLine(), ignoreCase: true, out Option op)
					&& Enum.IsDefined<Option>(op))
				{ 
                    switch (op)
					{
						case Option.Add:
							officers.AddNewOfficer();
							break;
						case Option.Find:
                            Console.Write("Input name: ");
                            string? name = Console.ReadLine();
							if (name == null) { break; }
							officers.GetOfficerByName(name);
							break;
						case Option.Print:
							officers.PrintListOfficers();
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