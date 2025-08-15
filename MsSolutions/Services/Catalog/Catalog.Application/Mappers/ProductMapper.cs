using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Mappers
{
    public static class ProductMapper
    {
        private static readonly Lazy<IMapper> mapper = new Lazy<IMapper>(() =>
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Microsoft", LogLevel.Warning)
                       .AddFilter("System", LogLevel.Warning)
                       .AddFilter("SampleApp.Program", LogLevel.Debug);
            });
            var config = new MapperConfiguration(c =>
            {
                c.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                c.AddProfile<ProductMappingProfile>();
            },loggerFactory);
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => mapper.Value;

    }
}
