namespace NewAtmApp.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int id { get; set; }

        public DateOnly CreatedAt { get; set; }

        public DateOnly ModifiedAty { get; set; }
    }
}