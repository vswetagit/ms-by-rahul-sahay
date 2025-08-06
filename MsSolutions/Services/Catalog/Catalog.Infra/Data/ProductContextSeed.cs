using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infra.Data
{
    public static class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Product> collection)
        {
            var exists = collection.Find(x => true).Any();
            var path = Path.Combine("Data", "SeedData", "products.json");
            if (!exists)
            {
                var items = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<IEnumerable<Product>>(items);

                foreach(var item in data)
                {
                    collection.InsertOne(item);
                }
            }
        }
    }
}
