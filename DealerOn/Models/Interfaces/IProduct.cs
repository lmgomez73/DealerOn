namespace DealerOn.Models.Interfaces
{
    public interface IProduct : IIdentifiable
    {
        public string Name { get; set; }
        public double ListPrice { get; set; }
        public double Price { get; }
    }
}
