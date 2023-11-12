using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewAtmApp.Domain.Entities;

namespace NewAtmApp.Services.Contracts
{
    public interface IUserAccountService
    {
        void CreateAccount();
        void LoginAccount();
        void UpdateAccount();
        void ChangePIN();
        void RunATMApplication();
        void CheckAccoutnBalance();
        void PlaceDeposit();
        void MakeWithdrawal();
        void CheckUserTransactions();
        void MakeTransfer();
    }
}