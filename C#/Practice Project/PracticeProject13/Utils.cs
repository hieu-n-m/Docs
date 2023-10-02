using System.Net.Mail;

class EmptyOrNullInputException : Exception
{
    public EmptyOrNullInputException() : base("Empty or null input") { }
}
class DateTimeInvalidException : Exception
{
    public DateTimeInvalidException() : base("Datetime invalid") { }
}
class PhoneNumberInvalidException : Exception
{
    public PhoneNumberInvalidException() : base("Phone number invalid") { }
}
class FullNameInvalidException : Exception
{
    public FullNameInvalidException() : base("Fullname invalid") { }
}
class EmailInvalidException : Exception
{
    public EmailInvalidException() : base("Email invalid") { }
}
struct PhoneNumber
{
    public string Value { get; }
    public PhoneNumber(string val)
    {
        Value = val;
    }
    public static bool IsValid(string input)
    {
        return input.All(char.IsDigit);
    }
    public override string? ToString()
    {
        return Value;
    }
}
struct FullName
{
    public string Value { get; }
    public FullName(string val)
    {
        Value = val;
    }
    public static bool IsValid(string input)
    {
        return input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
    }

    public override string? ToString()
    {
        return Value;
    }
}

class InputFromConsole
{
    public static object? ConvertTo(string input, Type type)
    {
        if (type == typeof(PhoneNumber))
        {
            if (!PhoneNumber.IsValid(input))
                throw new InvalidCastException();
            return new PhoneNumber(input);
        }
        if (type == typeof(FullName))
        {
            if (!FullName.IsValid(input)) 
                throw new InvalidCastException();
            return new FullName(input);
        }
        if (type == typeof(MailAddress))
        {
            try
            {
                return new MailAddress(input);
            }
            catch
            {
                throw;
            }
        }
        return Convert.ChangeType(input, type);
    }
    public static bool GetInput<T>(string message, out T? result)
    {
        int count = 3;
        while (true)
        {
            if (count == 0)
            {
                result = default(T);
                return false;
            }
            count--;
            try
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (String.IsNullOrEmpty(input)) { throw new EmptyOrNullInputException(); }
                try
                {
                    result = (T?)ConvertTo(input, typeof(T)) ?? throw new NullReferenceException();
                }
                catch
                {
                    if (typeof(T) == typeof(DateTime))
                        throw new DateTimeInvalidException();
                    if (typeof(T) == typeof(PhoneNumber))
                        throw new PhoneNumberInvalidException();
                    if (typeof(T) == typeof(FullName))
                        throw new FullNameInvalidException();
                    if (typeof(T) == typeof(MailAddress))
                        throw new EmailInvalidException();
                    throw;
                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        return true;
    }
}