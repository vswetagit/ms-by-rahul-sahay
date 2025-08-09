using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductByBrandHandler : IRequestHandler<GetProductByBrandQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _repository; 
        public GetProductByBrandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<ProductResponse>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetProductsByBrand(request.BrandName);
            var output = ProductMapper.Mapper.Map<IList<ProductResponse>>(items);
            return output;
        }
    }
}
