using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task<IList<Product>> GetProductsByName(string name);
        Task<IList<Product>> GetProductsByBrand(string brandName);
        Task<IList<Product>> GetProductsByType(string typeId);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);
    }
}
