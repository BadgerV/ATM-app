using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewAtmApp.Domain.DTOs;
using NewAtmApp.Domain.Entities;
using NewAtmApp.Domain.Enums;
using NewAtmApp.Helper;
using NewAtmApp.Repositories;
using NewAtmApp.Services.Contracts;

namespace NewAtmApp.Services
{
    public class UserAccountService : IUserAccountService
    {
        public readonly UserAccountRepository _userAccountRepository;
        public UserAccountService(UserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }


        public void ChangePIN()
        {
            string formerPIN = Utility.Convert<string>("Please input your former PIN");

            string newPIN = Utility.Convert<string>("Please input your new PIN");
            string confirmNewPIN = Utility.Convert<string>("Please input your confirm new PIN");

            if (newPIN != confirmNewPIN)
            {
                Console.WriteLine("PIN do not match. Please try again");
                Utility.PressEnterToContinue();
                ChangePIN();
            }

            _userAccountRepository.ChangePIN(formerPIN, newPIN);
            Utility.PrintDotAnimation();

            Console.WriteLine($"You have successfully chnaged you Card PIN");
            Utility.PressEnterToContinue();
        }

        public void CreateAccount()
        {

            string fullname = Utility.Convert<string>("Enter you full name");
            int gender = Utility.Convert<int>("\nSelect a Gender option\nSelelct 1 for male\nSelect 2 for female");
            int accountType = Utility.Convert<int>("\nSelect Account Type\n1 for Savings account\n2 for Current account \n3 for Credit account");


            UserAccountRegistration userAccountRegistration = new()
            {
                Fullname = fullname,
                Gender = (GenderType)gender,
                AccountType = (AccountType)accountType
            };


            var createdUser = _userAccountRepository.CreateAccount(userAccountRegistration);

            Utility.PrintDotAnimation();

            Console.WriteLine("Congratulaitons, Your account has been created. Your account number is {0}, your card number is {1}, your PIN is set to default 0000.\n\nPlease proceed to login {2}\nThank you for your patronage.", createdUser.AccountNumber, createdUser.CardNumber, createdUser.FullName);
        }

        public void LoginAccount()
        {
            bool flag = true;

            while (flag)
            {
                try
                {
                    string cardNumber = Utility.Convert<string>("Please enter your card number");
                    string cardPin = Utility.Convert<string>("Please enter your card pin");

                    Utility.PrintDotAnimation();
                    UserAccountDetails tempUserAccount = _userAccountRepository.LoginAccount(cardNumber, cardPin);

                    Console.WriteLine($"Welcome {tempUserAccount!.FullName}");
                    flag = false;

                    Utility.PressEnterToContinue();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            Console.WriteLine($"Interesting shit");

        }

        public void RunATMApplication()
        {
            bool flag = true;

            while (flag)
            {
                try
                {
                    ScreenDisplay.PrintLoginMenuOptions();
                    string option = Utility.Convert<string>("");

                    switch (option)
                    {
                        case "1":
                            CheckAccoutnBalance();
                            Console.Clear();
                            break;

                        case "2":
                            PlaceDeposit();
                            Console.Clear();
                            break;
                        case "3":
                            MakeWithdrawal();
                            Console.Clear();
                            break;
                        case "4":
                            MakeTransfer();
                            Console.Clear();
                            break;
                        case "5":
                            CheckUserTransactions();
                            Console.Clear();
                            break;
                        case "6":
                            ChangePIN();
                            break;
                        case "7":
                            Console.WriteLine("You have successfully logged out\n");
                            Utility.PressEnterToContinue();
                            flag = false;
                            break;

                        default:
                            Console.WriteLine($"Invalid input. Please try again");
                            Utility.PressEnterToContinue();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public void UpdateAccount()
        {
            throw new NotImplementedException();
        }

        public void CheckAccoutnBalance()
        {
            decimal accountBalance = _userAccountRepository.CheckAccountBalance();
            Utility.PrintDotAnimation();

            Console.WriteLine($"Your acccount balance as of {DateTime.Now} is {accountBalance}");
            Utility.PressEnterToContinue();
        }

        public void PlaceDeposit()
        {
            decimal amount = Utility.Convert<decimal>("Please enter the amount you want to deposit.\nNOTE: It must be in multiples of 500");

            try
            {
                _userAccountRepository.PlaceDeposit(amount);
                Utility.PrintDotAnimation();
                Console.WriteLine($"you have successfully deposited {amount} in your account.\n\n");
                Utility.PressEnterToContinue();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Utility.PressEnterToContinue();
                Console.Clear();
                PlaceDeposit();
            }
        }

        public void MakeWithdrawal()
        {
            decimal amount = Utility.Convert<decimal>("Please enter the amount you want to withdraw.\nNOTE: It must be in multiples of 500");
            try
            {
                _userAccountRepository.MakeWwithdrawal(amount);
                Utility.PrintDotAnimation();
                Console.WriteLine($"you have successfully withdrwan {amount} in your account.\n\n");
                Utility.PressEnterToContinue();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Utility.PressEnterToContinue();
                Console.Clear();
                MakeWithdrawal();
            }
        }

        public void CheckUserTransactions()
        {
            var userTransactions = _userAccountRepository.CheckUserTransactions();

            foreach (Transaction transaction in userTransactions)
            {
                Console.WriteLine($"{transaction.TransactionType} {transaction.Amount} {transaction.RecieverID} {transaction.CreatedAt}");
            }
            Utility.PressEnterToContinue();
        }

        public void MakeTransfer()
        {
            string AccountNumber = Utility.Convert<string>("Enter recipient account number");
            Console.WriteLine($"\n");

            string accountName = Utility.Convert<string>("Enter recipient name");
            Console.WriteLine($"\n");

            decimal amount = Utility.Convert<decimal>("Enter amount you wish to transfer");

            try
            {
                _userAccountRepository.MakeTransfer(AccountNumber, accountName, amount);

                Utility.PrintDotAnimation();

                Console.WriteLine($"You have successfully transferred {amount} to {accountName}");
                Utility.PressEnterToContinue();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Utility.PressEnterToContinue();
                Console.Clear();
                MakeTransfer();
            }
        }
    }
}