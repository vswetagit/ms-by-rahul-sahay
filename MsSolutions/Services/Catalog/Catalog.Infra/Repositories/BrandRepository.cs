using Catalog.Core.Entities;
using Catalog.Core.Repositories;

namespace Catalog.Infra.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            throw new NotImplementedException();
        }
    }
}
