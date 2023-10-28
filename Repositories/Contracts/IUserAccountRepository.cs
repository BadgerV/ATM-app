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
        void UpdateAccount(UserAccount userAccount);
        void ChangeAcccountPassword(UserAccount userAccount);
    }
}