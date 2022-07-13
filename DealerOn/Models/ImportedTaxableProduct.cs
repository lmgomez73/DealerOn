namespace DealerOn.Models
{
    public class ImportedTaxableProduct : ImportedProduct
    {
        private const double TAX = 0.1;
        public ImportedTaxableProduct()
        {

        }
        public ImportedTaxableProduct(string name, double price) : base( name, price)
        {
            _name = name;
            _price = price;
        }

        //returns the price with the import tax rounded to the nearest 5
        public override double Tax => base.Tax + Math.Ceiling((ListPrice * TAX) * 20) / 20;
    }
}
