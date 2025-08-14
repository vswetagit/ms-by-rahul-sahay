using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypesResponse>>
    {
        private readonly ITypesRepository _repository;
        public GetAllTypesHandler(ITypesRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<TypesResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetAllTypes();
            var output = ProductMapper.Mapper.Map<IList<TypesResponse>>(items);
            return output;
        }
    }
}
