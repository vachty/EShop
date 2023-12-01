using CatalogService.Extensions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Service.Handlers.Base;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCatalogDbContext(builder.Configuration);

//AutoMapper DI
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Service.Mappers.Mappings.DomainToDtoMappingProfile)));

//Other components DI
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(BaseHandler<,>).GetTypeInfo().Assembly));
builder.Services.Register();

builder.Services.SetUpRoutes();

var app = builder.Build();

//Migrations
app.UseMigrations();

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
