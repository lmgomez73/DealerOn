using DealerOn.Models.Interfaces;

namespace DealerOn.Models
{
    public class Sale : ISale
    {
        public IDictionary<int,IItem> Items { get; set; }
        public double Total { get; set; }
        public double SalesTaxes { get; set; }
        public int Id { get; set; }
        public Sale()
        {
            Items = new Dictionary<int,IItem>();
        }
    }
}
