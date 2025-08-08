using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infra.Data;
using MongoDB.Driver;

namespace Catalog.Infra.Repositories
{
    public class TypesRepository : ITypesRepository
    {
        private readonly ICatalogContext _context;
        public TypesRepository(ICatalogContext context)
        {
            _context = context;
        }
        public async Task<IList<ProductType>> GetAllTypes()
        {
            return await _context.types.Find(x => true).ToListAsync();
        }
    }
}
