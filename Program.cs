using NewAtmApp.Helper;
using NewAtmApp.Menu;
using NewAtmApp.Repositories;
using NewAtmApp.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        
        UserAccountRepository userAccountRepository = new();
        UserAccountService userAccountService = new(userAccountRepository);
        Menu.MainMenu(userAccountService);
    }
}