using NewAtmApp.Domain.Enums;

namespace NewAtmApp.Domain.Entities
{
    public class UserAccount : BaseEntity
    {
        public string FullName { get; set; } = default!;
        public string AccountNumber { get; set; } = default!;
        public string CardNumber { get; set; } = default!;
        public string CardPin { get; set; } = default!;
        public DateOnly DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public AccountType AccountType { get; set; }
        public decimal AccountBalance { get; set; }
        public bool IsLocked { get; set; }
        public int TotalLogin { get; set; }
    }
}