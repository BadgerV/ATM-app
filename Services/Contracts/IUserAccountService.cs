using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAtmApp.Services.Contracts
{
    public interface IUserAccountService
    {
        void CreateAccount();
        void UpdateAccount();
        void ChangeAcccountPassword();
    }
}