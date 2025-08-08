using AutoMapper;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery,
        IList<ProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public GetAllProductHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<IList<ProductResponse>> Handle(GetAllProductQuery request,
            CancellationToken cancellationToken)
        {
            var items = await _repository.GetProducts();
            var output = ProductMapper.Mapper.Map<IList<ProductResponse>>(items);
            return output;
        }
    }
}
