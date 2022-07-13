using DealerOn.Models.Interfaces;

namespace DealerOn.Models
{
    public class Item : IItem
    {
        public IProduct Product { get; set; }
        public int Amount { get; set; }
    }
}
