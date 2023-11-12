using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewAtmApp.Domain.DTOs;
using NewAtmApp.Domain.Entities;

namespace NewAtmApp.Repositories.Contracts
{
    public interface IUserAccountRepository
    {
        UserAccountDetails CreateAccount(UserAccountRegistration request);

        UserAccountDetails LoginAccount(string CardNumber, string cardPin);
        decimal CheckAccountBalance();

        void PlaceDeposit(decimal amount);

        void MakeWwithdrawal(decimal amount);
        void UpdateAccount(UserAccount userAccount);
        void ChangePIN(string formerPIN, string newPIN);
        List<Transaction> CheckUserTransactions();
        void MakeTransfer(string AccountNumber, string accountName, decimal amount);
    }
}