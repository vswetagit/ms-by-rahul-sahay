using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infra.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<ProductBrand> brands { get; }
        public IMongoCollection<ProductType> types { get; }
        public IMongoCollection<Product> products { get; }
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var db = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            brands = db.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseSettings:BrandsCollection"));
            types = db.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseSettings:TypesCollection"));
            products = db.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            BrandContextSeed.SeedData(brands);
            TypeContextSeed.SeedData(types);    
            ProductContextSeed.SeedData(products);
        }
    }
}
