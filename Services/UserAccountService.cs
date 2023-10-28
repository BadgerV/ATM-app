using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewAtmApp.Domain.DTOs;
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

        public void ChangeAcccountPassword()
        {
            throw new NotImplementedException();
        }

        public void CreateAccount()
        {
            string fullname = Utility.Convert<string>("Enter you full name");
            int gender = Utility.Convert<int>("Select a Gender option\nSelelct 1 for male\nSelect 2 for female");
            int accountType = Utility.Convert<int>("Select Account Type\n1 for Savings account\n2 for Current account \n3 for Credit account");


            UserAccountRegistration userAccountRegistration = new()
            {
                Fullname = fullname,
                Gender = (GenderType)gender,
                AccountType = (AccountType)accountType
            };


            var createdUser = _userAccountRepository.CreateAccount(userAccountRegistration);

            Utility.PrintDotAnimation();

            Console.WriteLine($"Congratulaitons, Your account has been created. Your account number is {0}, your card number is {1}, your PIN is set to default 0000. Please proceed to login {2}\nThank you for your patronage.", createdUser.AccountNumber, createdUser.CardNumber, createdUser.Fullname);
        }

        public void UpdateAccount()
        {
            throw new NotImplementedException();
        }
    }
}