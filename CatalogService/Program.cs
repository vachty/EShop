using CatalogService.Extensions;
using MediatR;
using Service.Handlers.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();

builder.Services.AddCatalogDbContext(builder.Configuration);

//AutoMapper DI
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Service.Mappers.Mappings.DomainToDtoMappingProfile)));

//Other components DI
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(BaseHandler<,>).GetTypeInfo().Assembly));
builder.Services.Register();

builder.Services.SetUpRoutes();

var app = builder.Build();

app.SetSwaggerUI();

//Migrations
app.UseMigrations();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
