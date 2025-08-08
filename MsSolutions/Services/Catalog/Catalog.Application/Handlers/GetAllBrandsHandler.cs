using AutoMapper;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery,
        IList<BrandResponse>>
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;
        public GetAllBrandsHandler(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IList<BrandResponse>> Handle(GetAllBrandsQuery request,
            CancellationToken cancellationToken)
        {
            var respList = await _repository.GetAllBrands();
            var output = ProductMapper.Mapper.Map<IList<BrandResponse>>(respList);
            return output;
        }
    }
}
