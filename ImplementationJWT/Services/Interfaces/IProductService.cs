using ImplementationJWT.Models;
using ImplementationJWT.Utilities;

namespace ImplementationJWT.Services.Interfaces
{
    public interface IProductService
    {
        bool DeleteProductName(string Name);
        List<Product> GetProductName(string Name);
        List<Product> GetProductByDescription(Description description);
        List<Product> GetAnimeYear(decimal price);
    }
}
