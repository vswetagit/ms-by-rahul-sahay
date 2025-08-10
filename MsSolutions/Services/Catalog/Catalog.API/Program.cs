using Catalog.Core.Repositories;
using Catalog.Infra.Data;
using Catalog.Infra.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Catalog.API v1",
        Version = "ver1"
    });
});
// register automapper
//builder.Services.AddAutoMapper(config =>
//{
//    config.AddProfile<ProductMappingProfile>();
//});
builder.Services.AddAutoMapper(cfg => {
    //cfg.AddMaps(typeof(Program).Assembly);
    cfg.AddMaps(Assembly.GetExecutingAssembly());
});

// register mediatr
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

//registering service
builder.Services.AddScoped<ICatalogContext,CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBrandRepository,BrandRepository>();
builder.Services.AddScoped<ITypesRepository, TypesRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
