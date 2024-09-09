using ImplementationJWT.Models;
using ImplementationJWT.Repositories.Interfaces;
using ImplementationJWT.Utilities;
using System.Xml.Linq;

namespace ImplementationJWT.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> ProductList { get; set; }
        public ProductRepository()
        {
            ProductList = new List<Product>()
            {
                new Product{ Id = Guid.NewGuid(), Name = "iphone 12", Description = Description.usado, Stock = 13, Price = 670.12m },
                new Product{ Id = Guid.NewGuid(), Name = "iphone 13", Description = Description.nuevo, Stock = 9, Price = 870.12m },
                new Product{ Id = Guid.NewGuid(), Name = "iphone 15", Description = Description.usado, Stock = 13, Price = 1170.12m },
            };
        }

        public List<Product> GetProductByName(string Name)
        {
            return ProductList.Where(e => e.Name.ToLower() == Name.ToLower()).ToList();
        }

        public List<Product> GetProductByDescription(Description Description)
        {

            var filter = ProductList.Where(e => e.Description == Description).ToList();
            return filter;
        }

        public List<Product> GetProductByPrice(Decimal Price)
        {
            var filter = ProductList.Where(e => e.Price >= Price).ToList();
            return filter;
        }

        public bool DeleteProductName(string Name)
        {
            var prod = ProductList.FirstOrDefault(a => a.Name.ToLower() == Name.ToLower());
            if (prod != null)
            {
                ProductList.Remove(prod);
                return true;
            }
            return false;
        }
    }
}

