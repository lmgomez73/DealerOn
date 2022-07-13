namespace DealerOn.Models.Interfaces
{
    public interface IItem
    {
        int Amount { get; set; }
        IProduct Product { get; set; }
    }
}
