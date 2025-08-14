using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infra.Data
{
    public static class BrandContextSeed
    {
        public async static void SeedData(IMongoCollection<ProductBrand> collection)
        {
            var item = collection.Find(x => true).Any();
            string path = "../Catalog.Infra/Data/SeedData/brands.json"; //Path.Combine("~/Data", "SeedData", "brands.json");

            if (!item)
            {
                var items = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<List<ProductBrand>>(items);
                if (data != null)
                {
                    foreach (var brand in data)
                    {
                        await collection.InsertOneAsync(brand);
                    }
                }
            }
        }
    }
}
