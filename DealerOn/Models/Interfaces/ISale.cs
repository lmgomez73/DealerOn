namespace DealerOn.Models.Interfaces
{
    public interface ISale : IIdentifiable
    {
        IDictionary<int, IItem> Items { get; set; }
        double Total { get; set; }
        double SalesTaxes { get; set; }
    }
}
