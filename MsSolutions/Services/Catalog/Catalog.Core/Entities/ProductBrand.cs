using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Entities
{
    public class ProductBrand : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        // Additional properties can be added here as needed
        // For example, you might want to add a description or a logo URL
        // public string Description { get; set; }
        // public string LogoUrl { get; set; }


    }
}
