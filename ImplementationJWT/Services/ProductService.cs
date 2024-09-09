using ImplementationJWT.Models;
using ImplementationJWT.Repositories.Interfaces;
using ImplementationJWT.Services.Interfaces;
using ImplementationJWT.Utilities;
using System.Xml.Linq;

namespace ImplementationJWT.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public bool DeleteProductName(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }
            return _productRepository.DeleteProductName(Name);
        }

        public List<Product> GetProductName(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return new List<Product>();
            }
            return _productRepository.GetProductByName(Name);
        }

        public List<Product> GetProductByDescription(Description description)
        {
            if (description <= 0)
            {
                return new List<Product>();
            }
            return _productRepository.GetProductByDescription(description);
        }

        public List<Product> GetAnimeYear(decimal price)
        {
            if (price <= 00.0m)
            {
                return new List<Product>();
            }
            return _productRepository.GetProductByPrice(price);
        }
    }
}
