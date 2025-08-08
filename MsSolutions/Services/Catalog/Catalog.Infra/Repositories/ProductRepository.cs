using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infra.Data;
using MongoDB.Driver;

namespace Catalog.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;
        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            await _context.products.InsertOneAsync(product);
            return product;
        }
        public async Task<bool> UpdateProduct(Product product)
        {
            var resp = await _context.products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return resp.IsAcknowledged && resp.ModifiedCount > 0 && resp.UpsertedId > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var result = await _context.products.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context.products.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Product>> GetProducts()
        {
            return await _context.products.Find(x => true).ToListAsync();
        }

        public async Task<IList<Product>> GetProductsByBrand(string brandName)
        {
            return await _context.products.Find(x => x.Brands.Name == brandName).ToListAsync();
        }

        public async Task<IList<Product>> GetProductsByName(string name)
        {
            return await _context.products.Find(x => x.Name == name).ToListAsync();
        }

        public async Task<IList<Product>> GetProductsByType(string typeName)
        {
            return await _context.products.Find(x => x.Types.Name == typeName).ToListAsync();
        }

        public async Task<IList<ProductBrand>> GetAllBrands()
        {
            return await _context.brands.Find(x => true).ToListAsync();
        }

       public async Task<IList<ProductType>> GetAllTypes()
        {
            return await _context.types.Find(x => true).ToListAsync();  
        }
    }
}
