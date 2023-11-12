using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAtmApp.Helper
{
    public static class Utility
    {

        public static int id;
        public static void PrintMessage(string msg, bool success)
        {
            Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
            PressEnterToContinue();
        }

        public static void PrintDotAnimation(int timer = 15)
        {
            for (int i = 0; i < timer; i++)
            {
                Console.Write(" . ");
                Thread.Sleep(50);
            }

            Console.Clear();
        }

        public static int GenerateId()
        {
            return ++id;
        }

        public static void PressEnterToContinue()
        {
            Console.Write("\n\nPress Enter To Continue... ");
            Console.ReadLine();
            Console.Write(Environment.NewLine);
        }

        public static string GetUserInput(string prompt)
        {
            Console.WriteLine($"{prompt}");
            return Console.ReadLine()!;
        }

        public static T Convert<T>(string prompt)
        {
            bool valid = false;
            string userInput;

            while (!valid)
            {
                userInput = GetUserInput(prompt);

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    return Convert<T>(prompt);
                }

                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));

                    if (converter != null)
                    {
                        return (T)converter.ConvertFromString(userInput)!;
                    }
                    else
                    {
                        return default!;
                    }
                }
                catch
                {
                    PrintMessage("Invalid Input. Try again", false);
                }
            }
            return default!;
        }
        public static string GeneratecaredNumber()
        {
            return GenerateRandomNumbers(16);
        }
        public static string CreateAccountNumber()
        {
            return GenerateRandomNumbers(10);
        }
        private static string GenerateRandomNumbers(int length)
        {

            StringBuilder randomNumber = new();
            Random random = new();


            for (int i = 0; i < length; i++)
            {
                randomNumber.Append(random.Next(10));
            }

            return randomNumber.ToString();
        }
    }
}