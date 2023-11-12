namespace NewAtmApp.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAty { get; set; }
    }
}