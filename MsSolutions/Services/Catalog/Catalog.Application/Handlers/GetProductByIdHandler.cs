using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductByNameHandler : IRequestHandler<GetProductByNameQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _repository;
        public GetProductByNameHandler(IProductRepository repository)
        {
            this._repository = repository;
        }
        public async Task<IList<ProductResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetProductsByName(request.Name);
            var output = ProductMapper.Mapper.Map<IList<ProductResponse>>(item);
            return output;
        }
    }
}
