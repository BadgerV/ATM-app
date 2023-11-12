using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewAtmApp.Domain.Entities;
using NewAtmApp.Helper;
using NewAtmApp.Services;

namespace NewAtmApp.Menu;
public class Menu
{
    public static void MainMenu(UserAccountService userAccountService, bool hasentbeenSeenBefore = true)
    {

        Console.Clear();
        if (hasentbeenSeenBefore)
        {
            Console.WriteLine("Welcome to MYATM app");
        }

        Console.WriteLine($"Select 1 to register if you don't have an account");
        Console.WriteLine($"Select 2 to login if you already have an account\n");
        Console.WriteLine($"Select 0 to quit application\n");
        Console.Write("Option: ");

        string option = Console.ReadLine()!;

        bool flag = true;

        while (flag)
        {
            switch (option)
            {
                case "1":
                    RegisterUserMenu(userAccountService);
                    MainMenu(userAccountService);
                    break;
                case "2":
                    Console.Clear();
                    LoginMenu(userAccountService);
                    MainMenu(userAccountService);
                    break;
                case "0":
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    MainMenu(userAccountService, false);
                    break;
            }
        }
    }

    public static void LoginMenu(UserAccountService request)
    {
        try
        {
            request.LoginAccount();
            Console.Clear();
            request.RunATMApplication();
            Console.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Utility.PressEnterToContinue();
            LoginMenu(request);
        }
    }


    public static void RegisterUserMenu(UserAccountService request)
    {
        Console.Clear();
        Console.WriteLine("Please follow the instructions to create a new account\nPlease select an option\n\n");
        bool flag = true;

        try
        {
            while (flag)
            {
                request.CreateAccount();
                Utility.PressEnterToContinue();
                Console.Clear();
                flag = false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");

        }
    }




}
