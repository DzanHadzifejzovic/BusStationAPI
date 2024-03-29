namespace Domain.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime CreatedOnUtc { get; set; }
        DateTime? ModifiedOnUtc { get; set; }
    }
}
