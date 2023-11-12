namespace NewAtmApp.Helper
{
    public static class ScreenDisplay
    {
        public static void PrintLoginMenuOptions()
        {
            Console.WriteLine($"Welcome to MYATM app. Please proceed to change your password if you haven't already\v\n");
            Console.WriteLine("-------My ATM App Menu-------");
            Console.WriteLine(":                            ");
            Console.WriteLine("1. Account Balance           ");
            Console.WriteLine("2. Cash Deposit              ");
            Console.WriteLine("3. Withdrwal                 ");
            Console.WriteLine("4. Transfer                  ");
            Console.WriteLine("5. Transactions              ");
            Console.WriteLine("5. Change PIN                ");
            Console.WriteLine("5. Profile                   ");
            Console.WriteLine("6. Logout                    \n");
            Console.Write("Option: ");
        }
    }
}