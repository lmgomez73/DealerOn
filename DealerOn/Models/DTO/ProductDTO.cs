using DealerOn.Utils;

namespace DealerOn.Models.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Imported { get; set; }
        public ProductTypes ProductType { get; set; }
    }
}
