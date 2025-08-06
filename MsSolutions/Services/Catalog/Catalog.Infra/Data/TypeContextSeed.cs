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
    public static class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> colllection)
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
                        colllection.InsertOne(item);
                    }
                }
            }
        }
    }
}
