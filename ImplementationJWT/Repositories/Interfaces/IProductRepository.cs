using ImplementationJWT.Models;
using ImplementationJWT.Utilities;

namespace ImplementationJWT.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProductByName(string Name);
        List<Product> GetProductByDescription(Description Description);
        List<Product> GetProductByPrice(Decimal Price);
        bool DeleteProductName(string Name);


    }
}

