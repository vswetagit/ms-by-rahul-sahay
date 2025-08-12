using AutoMapper;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery,
        ProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public GetProductByIdHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ProductResponse> Handle(GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            var items = await _repository.GetProduct(request.Id);
            var output = ProductMapper.Mapper.Map<ProductResponse>(items);
            return output;
        }
    }
}
