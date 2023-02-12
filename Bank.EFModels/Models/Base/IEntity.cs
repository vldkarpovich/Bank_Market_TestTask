namespace Bank.EFModels.Models.Base
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
