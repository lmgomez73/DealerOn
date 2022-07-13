using DealerOn.Cache;
using DealerOn.Cache.Interfaces;
using DealerOn.Repository;
using DealerOn.Repository.Interfaces;
using DealerOn.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CacheConfiguration>(builder.Configuration.GetSection("CacheConfiguration"));
builder.Services.AddMemoryCache();

builder.Services.AddTransient<ICacheService, MemoryCacheService>();
builder.Services.AddTransient<ProductFactory>();
builder.Services.AddTransient<SaleHelper>();
builder.Services.AddTransient<Seeder>();

#region Repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<ISalesRepository, SaleRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
#endregion


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

var scope = app.Services.CreateScope();

var seeder = app.Services.GetService<Seeder>();

seeder.AddProductsToCache();

app.Run();
