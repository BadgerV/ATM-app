using NewAtmApp.Domain.Enums;

namespace NewAtmApp.Domain.Entities;

public class Transaction : BaseEntity
{
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    public int UserID { get; set; }
    public int? RecieverID
    {
        get; set;
    }
}