using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infra.Data
{
    public static class TypeContextSeed
    {
        public async static void SeedData(IMongoCollection<ProductType> colllection)
        {
            var exists = colllection.Find(x => true).Any();
            var path = Path.Combine("Data", "SeedData", "types.json");
            if (!exists)
            {
                var items = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<IEnumerable<ProductType>>(items);

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        await colllection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}
