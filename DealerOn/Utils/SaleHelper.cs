using DealerOn.Models;
using DealerOn.Models.DTO;
using DealerOn.Models.Interfaces;
using DealerOn.Repository.Interfaces;
using System.Text;

namespace DealerOn.Utils
{
    public class SaleHelper
    {
        private readonly IProductRepository _repository;

        public SaleHelper(IProductRepository repository)
        {
            this._repository = repository;
        }
        public ISale CreateSale(SaleDTO value)
        {
            Sale sale = new Sale();
            double totalTaxes = 0;
            double total = 0;
            foreach (var productId in value.ProductsIds)
            {
                var product = _repository.GetById(productId);
                var taxes = GetTaxesFromProduct(product);
                totalTaxes += taxes;
                total += product.ListPrice + taxes;
                AddProductToDictionary(sale.Items, product);
            }

            sale.Total = total;
            sale.SalesTaxes = totalTaxes;

            return sale;
        }
        private void AddProductToDictionary(IDictionary<int, IItem> items, IProduct product)
        {
            var id = product.Id;
            if (items.ContainsKey(id))
            {
                items[id].Amount++;
            }
            else
            {
                Item item = new Item()
                {
                    Amount = 1,
                    Product = product
                };
                items.Add(id, item);
            }
        }
        private double GetTaxesFromProduct(IProduct product)
        {
            if (!(product is ITaxable))
            {
                return 0;
            }
            else
            {
                ITaxable taxable = (ITaxable)product;
                return taxable.Tax;
            }
        }
        public string SaleToString(ISale sale)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in sale.Items)
            {
                var name = item.Value.Product.Name;
                var amount = item.Value.Amount;
                var price = item.Value.Product.Price;
                var total = price * amount;
                var obs = item.Value.Amount > 1 ? $" ({amount} @ {price.ToString("#.##")})" : "";

                builder.AppendLine($"{name}: {total.ToString("#.##")}{obs}");
            }
            builder.AppendLine($"Sales Taxes: {sale.SalesTaxes.ToString("#.##")}");
            builder.AppendLine($"Total: {sale.Total.ToString("#.##")}");

            return builder.ToString();
        }
    }
}
