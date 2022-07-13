using DealerOn.Models;
using DealerOn.Models.DTO;
using DealerOn.Models.Interfaces;

namespace DealerOn.Utils
{
    public class ProductFactory
    {
        public IProduct CreateProduct(ProductDTO dto)
        {
            switch (dto.ProductType)
            {
                case ProductTypes.FOOD:
                case ProductTypes.MEDICAL:
                case ProductTypes.BOOK:
                    return dto.Imported ? new ImportedProduct(dto.Name,dto.Price) 
                        : new BasicProduct(dto.Name, dto.Price);
                case ProductTypes.OTHER:
                    return dto.Imported ? new ImportedTaxableProduct(dto.Name, dto.Price) 
                        : new TaxableProduct( dto.Name, dto.Price);
                default:
                    return null;
            }
        }
    }
}
