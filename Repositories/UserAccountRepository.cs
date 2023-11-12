using System.Security.Cryptography.X509Certificates;
using NewAtmApp.Domain.DTOs;
using NewAtmApp.Domain.Entities;
using NewAtmApp.Domain.Enums;
using NewAtmApp.Helper;
using NewAtmApp.Repositories.Contracts;

namespace NewAtmApp.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private List<UserAccount> UserAccountList = new();
        private List<Transaction> AllTransactions = new();

        private UserAccountDetails tempUserAccount = default!;

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
                    CardNumber = Utility.GeneratecaredNumber(),
                    id = Utility.GenerateId(),
                    CreatedAt = DateTime.Now,
                };

                UserAccountList.Add(userAccount);
                UserAccountDetails userAccountDetails = new()
                {
                    FullName = userAccount.FullName,
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

        public UserAccountDetails LoginAccount(string cardNumber, string cardPin)
        {
            tempUserAccount = new UserAccountDetails();
            int userExists = 1;
            foreach (var user in UserAccountList)
            {
                if (user.CardNumber == cardNumber)
                {
                    userExists = 2;
                    if (cardPin == user.CardPin)
                    {
                        tempUserAccount.FullName = user.FullName;
                        tempUserAccount.AccountBalance = user.AccountBalance
                        ;
                        tempUserAccount.AccountNumber = user.AccountNumber;
                        tempUserAccount.CardNumber = user.CardNumber;
                        tempUserAccount.Gender = user.Gender;
                        tempUserAccount.id = user.id;
                        return tempUserAccount;
                    }
                }
            }

            if (userExists == 1)
            {
                throw new Exception("User does not exist");
            }
            else if (userExists == 2)
            {
                throw new Exception("Incorrect pin");
            }
            return tempUserAccount;
        }
        public void ChangePIN(string formerPIN, string newPIN)
        {
            UserAccount user = UserAccountList.Find(x => x.id == tempUserAccount.id)!;

            if (user == null)
            {
                throw new Exception("Please login to change your password");
            }

            if (formerPIN != user.CardPin)
            {
                throw new Exception("Incorrect PIN");
            }

            user.CardPin = newPIN;
        }

        public void UpdateAccount(UserAccount userAccount)
        {
            throw new NotImplementedException();
        }

        public void PlaceDeposit(decimal amount)
        {
            if (tempUserAccount == null)
            {
                throw new Exception("You have to login before you can perfomr a transaction");
            }

            if (amount % 500 != 0)
            {
                throw new Exception("Amount can only be in multiples of 500");
            }

            Transaction transaction = new()
            {
                TransactionType = TransactionType.Deposit,
                Amount = amount,
                UserID = tempUserAccount.id,
            };

            AllTransactions.Add(transaction);

            tempUserAccount.AccountBalance += amount;
        }

        public void MakeWwithdrawal(decimal amount)
        {
            if (tempUserAccount == null)
            {
                throw new Exception("You have to login before you can perfomr a transaction");
            }


            if (tempUserAccount.AccountBalance < amount)
            {
                throw new Exception("Insufficient funds");
            }

            if (amount % 500 != 0)
            {
                throw new Exception("Amount can only be in multiples of 500");
            }

            Transaction transaction = new()
            {
                TransactionType = TransactionType.Withdrawal,
                Amount = amount,
                UserID = tempUserAccount.id,
                CreatedAt = DateTime.Now
            };

            AllTransactions.Add(transaction);

            tempUserAccount.AccountBalance -= amount;
        }

        public decimal CheckAccountBalance()
        {
            if (tempUserAccount == null)
            {
                throw new Exception("You have to login before you can perfomr a transaction");
            }

            return tempUserAccount.AccountBalance;
        }

        public List<Transaction> CheckUserTransactions()
        {
            if (tempUserAccount == null)
            {
                throw new Exception("You have to login before you can perform a transaction");
            }

            List<Transaction> userTransactions = new();


            foreach (Transaction transaction in AllTransactions)
            {
                if (transaction.UserID == tempUserAccount.id)
                {
                    userTransactions.Add(transaction);
                }
            }
            return userTransactions;
        }

        public void MakeTransfer(string accountNumber, string accountName, decimal amount)
        {
            UserAccount userAccount;

            userAccount = UserAccountList.Find(x => x.AccountNumber == accountNumber)!;

            if (userAccount == null)
            {
                throw new Exception("Invalid user details");
            }

            if (userAccount.FullName != accountName)
            {
                throw new Exception("Invalid user details");
            }

            Transaction transaction = new Transaction()
            {
                TransactionType = TransactionType.Transfer,
                Amount = amount,
                UserID = tempUserAccount.id,
                RecieverID = userAccount.id
            };

            AllTransactions.Add(transaction);

            tempUserAccount.AccountBalance -= amount;
            userAccount.AccountBalance += amount;
        }
    }
}