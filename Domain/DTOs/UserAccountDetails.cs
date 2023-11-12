using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewAtmApp.Domain.Enums;

namespace NewAtmApp.Domain.DTOs
{
    public class UserAccountDetails
    {
        public int id { get; set; }
        public string FullName { get; set; } = default!;
        public string AccountNumber { get; set; } = default!;
        public decimal AccountBalance { get; set; }
        public string CardNumber { get; set; } = default!;
        public GenderType Gender { get; set; }
        public AccountType AccountType { get; set; }
    }
}