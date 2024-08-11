using PrinceApi.Models.Base;

namespace Prince_Mobile_Collection.Models.Products
{
    public class ProductsModel : BaseModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Weight { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
