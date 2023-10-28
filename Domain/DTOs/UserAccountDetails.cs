using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewAtmApp.Domain.Enums;

namespace NewAtmApp.Domain.DTOs
{
    public class UserAccountDetails
    {
        public string Fullname { get; set; } = default!;
        public string AccountNumber { get; set; } = default!;
        public string CardNumber {get; set;} = default!;
        public GenderType Gender { get; set; }
        public AccountType AccountType { get; set; }
    }
}