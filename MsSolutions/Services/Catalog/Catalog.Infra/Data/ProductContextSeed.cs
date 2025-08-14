using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infra.Data
{
    public static class ProductContextSeed
    {
        public async static void SeedData(IMongoCollection<Product> collection)
        {
            var exists = collection.Find(x => true).Any();
            var path = "../Catalog.Infra/Data/SeedData/products.json";
            if (!exists)
            {
                var items = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<IEnumerable<Product>>(items);

                foreach(var item in data)
                {
                    await collection.InsertOneAsync(item);
                }
            }
        }
    }
}
