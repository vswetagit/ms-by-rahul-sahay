using AutoMapper;

namespace Catalog.Application.Mappers
{
    public static class ProductMapper
    {
        private static readonly Lazy<IMapper> mapper = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(c =>
            {
                c.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                c.AddProfile<ProductMappingProfile>();
            }, null);
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => mapper.Value;

    }
}
