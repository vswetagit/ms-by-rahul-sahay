using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infra.Data
{
    public static class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> collection)
        {
            var item = collection.Find(x => true).Any();
            string path = Path.Combine("Data", "SeedData", "brands.json");

            if (!item)
            {
                var items = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<List<ProductBrand>>(items);
                if (data != null)
                {
                    foreach (var brand in data)
                    {
                        collection.InsertOne(brand);
                    }
                }
            }
        }
    }
}
