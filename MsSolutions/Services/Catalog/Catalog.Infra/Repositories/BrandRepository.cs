using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infra.Data;
using MongoDB.Driver;

namespace Catalog.Infra.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ICatalogContext _context;
        public BrandRepository(ICatalogContext context)
        {
            _context = context;
        }
        public async Task<IList<ProductBrand>> GetAllBrands()
        {
            return await _context.brands.Find(x => true).ToListAsync();
        }
    }
}
