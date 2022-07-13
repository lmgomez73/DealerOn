using DealerOn.Models.DTO;
using DealerOn.Repository.Interfaces;
using System.Text.Json;

namespace DealerOn.Utils
{
    public class Seeder
    {
        private readonly IProductRepository repository;
        private readonly ProductFactory factory;

        public Seeder(IProductRepository repository, ProductFactory factory)
        {
            this.repository = repository;
            this.factory = factory;
        }
        public void AddProductsToCache()
        {
            var products = GetProductsFromFile();
            foreach (var item in products)
            {
                var product = factory.CreateProduct(item);
                repository.Add(product);
            }
        }

        private ICollection<ProductDTO> GetProductsFromFile()
        {
            var jsonString = File.ReadAllText("Data/Seed.json");
            var products = JsonSerializer.Deserialize<ProductSeed>(jsonString);
            return products.products;
        }
    }

    class ProductSeed
    {
        public ProductDTO[] products { get; set; }
    }
}
