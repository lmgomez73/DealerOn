using DealerOn.Models.Interfaces;

namespace DealerOn.Models
{
    public class TaxableProduct : IProduct, ITaxable
    {

        protected int _idProduct;
        protected string _name;
        protected double _price;
        public TaxableProduct()
        {

        }
        public TaxableProduct(string name, double listPrice)
        {
            _name = name;
            _price = listPrice;
        }

        public int Id { get => _idProduct; set => _idProduct = value; }
        public int IdProduct { get => _idProduct; set => _idProduct = value; }
        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price + Tax; }
        public double ListPrice { get => _price; set => _price = value; }

        //Returns the nearest up 5 of 10 percent of the price
        public virtual double Tax => Math.Ceiling((_price*0.1) * 20) / 20;

    }
}
