using ImplementationJWT.Utilities;

namespace ImplementationJWT.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Description Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
