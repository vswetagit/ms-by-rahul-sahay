using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infra.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<ProductBrand> brands { get; }
        IMongoCollection<ProductType> types { get; }
        IMongoCollection<Product> products { get; }
    }
}
