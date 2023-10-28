using NewAtmApp.Domain.DTOs;
using NewAtmApp.Domain.Entities;
using NewAtmApp.Helper;
using NewAtmApp.Repositories.Contracts;

namespace NewAtmApp.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private List<UserAccount> UserAccountList = new();
        public UserAccountDetails CreateAccount(UserAccountRegistration request)
        {
            try
            {
                UserAccount userAccount = new()
                {
                    FullName = request.Fullname,
                    Gender = request.Gender,
                    AccountType = request.AccountType,
                    DateOfBirth = request.DateOfBirth,
                    IsLocked = false,
                    CardPin = "0000",
                    AccountBalance = 0.0m,
                    TotalLogin = 0,
                    AccountNumber = Utility.CreateAccountNumber(),
                    CardNumber = Utility.GeneratecaredNumber()
                };

                UserAccountList.Add(userAccount);
                UserAccountDetails userAccountDetails = new()
                {
                    Fullname = userAccount.FullName,
                    Gender = userAccount.Gender,
                    AccountType = userAccount.AccountType,
                    AccountNumber = userAccount.AccountNumber,
                    CardNumber = userAccount.CardNumber
                };

                return userAccountDetails;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                UserAccountDetails userAccountDetails = new();

                return userAccountDetails;
            }
        }
        public void ChangeAcccountPassword(UserAccount userAccount)
        {
            throw new NotImplementedException();
        }



        public void UpdateAccount(UserAccount userAccount)
        {
            throw new NotImplementedException();
        }
    }
}