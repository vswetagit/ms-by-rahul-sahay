using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            //var product = ProductMapper.Mapper.Map<Product>(request);
            var item = await _repository.UpdateProduct(new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Brands = request.Brands,
                Description = request.Description,
                ImageFile = request.ImageFile,
                Price = request.Price,
                Summary = request.Summary,
                Types = request.Types,
            });
            return item;
        }
    }
}
