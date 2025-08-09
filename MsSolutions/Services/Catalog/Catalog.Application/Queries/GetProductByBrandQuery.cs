﻿using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductByBrandQuery:IRequest<IList<ProductResponse>>
    {
        public string BrandName { get; set; }
        public GetProductByBrandQuery(string brandName) {
            this.BrandName = brandName;
        }
        private GetProductByBrandQuery()
        {
            
        }
    }
}
