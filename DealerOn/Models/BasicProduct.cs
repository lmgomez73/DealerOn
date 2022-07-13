using DealerOn.Models.Interfaces;

namespace DealerOn.Models
{
    public class BasicProduct : IProduct
    {
        protected int _idProduct;
        protected string _name;
        protected double _price;
        public BasicProduct()
        {

        }
        public BasicProduct(string name, double listPrice)
        {
            _name = name;
            _price = listPrice;
        }


        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price; }


        public double ListPrice { get => _price; set => _price = value; }
        public int Id { get => _idProduct; set => _idProduct = value; }
    }
}
