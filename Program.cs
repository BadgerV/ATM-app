using NewAtmApp.Helper;

internal class Program
{
    private static void Main(string[] args)
    {

        string GeneratedNumber = Utility.GeneratecaredNumber();
        Console.WriteLine($"{GeneratedNumber}");
        
    }
}