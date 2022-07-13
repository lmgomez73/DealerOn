using DealerOn.Models.Interfaces;

namespace DealerOn.Models
{
    public class ImportedProduct : IProduct, ITaxable
    {
        protected int _idProduct;
        protected string _name;
        protected double _price;

        private const double TAX = 0.05;

        public virtual int IdProduct { get => _idProduct; set => _idProduct = value; }
        public virtual string Name { get => _name; set => _name = value; }
        public double Price { get => _price + Tax; }

        public double ListPrice { get => _price; set => _price = value; }
        public ImportedProduct()
        {

        }
        public ImportedProduct(string name, double price)
        {
            _name = name;
            _price = price;
        }

        //returns the price with the import tax rounded to the nearest 5
        public virtual double Tax => Math.Ceiling((ListPrice * TAX) * 20) / 20;

        public int Id { get => _idProduct; set => _idProduct = value; }
    }
}
