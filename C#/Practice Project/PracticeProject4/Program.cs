using PracticeProject4;

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
class Program
{
    public static void Main(string[] args)
    {

        Console.Write("Input n: ");
        int n = Convert.ToInt32(Console.ReadLine());
        City hanoi = new City();
        for (int i = 0; i < n; i++)
        {
            hanoi.NewResidence();
        }
        Console.WriteLine(hanoi);


    }
}