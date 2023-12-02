using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tests.Database
{
	/// <summary>
	/// The database helper for tests
	/// </summary>
	public static class DbHelper
	{
		/// <summary>
		/// Create and get the database context
		/// </summary>
		/// <param name="useMockedData">Indicates whether to use mocked data or data from database</param>
		/// <returns></returns>
		public static CatalogDbContextTest GetDbContext(bool useMockedData = true)
		{
			var dbContextBuilder = new DbContextOptionsBuilder<CatalogDbContext>();
			dbContextBuilder.UseInMemoryDatabase("EshopTest", x => x.EnableNullChecks());

			var dbContext = new CatalogDbContextTest(dbContextBuilder.Options);

			if (!useMockedData)
			{
				var configuration = new ConfigurationBuilder();
				var conn = configuration.AddJsonFile("appsettings.json").Build().GetConnectionString("Catalog");

				var optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>();
				optionsBuilder.UseSqlServer(conn);

				var dbContextSql = new CatalogDbContext(optionsBuilder.Options);
				dbContext.Products.AddRange(dbContextSql.Products);
				dbContext.SaveChanges();
			}
			else
			{
				SeedData(dbContext);
			}

			return dbContext;
		}

		/// <summary>
		/// Seeds the data to in memory database if mocked data option is selected
		/// </summary>
		/// <param name="dbContext"></param>
		public static void SeedData(CatalogDbContextTest dbContext)
		{
			var products = new List<Product>();
			for (int i = 0; i < 20; i++)
			{
				var product = new Product()
				{
					Id = Guid.NewGuid(),
					Name = "product" + i,
					Description = "Description of product " + i,
					ImgUri = $"product{i}\\imgages\\image.jpg",
					UpdatedBy = "systemseedtest",
					UpdatedOn = DateTime.Now,
					CreatedBy = "systemseedtest",
					CreatedOn = DateTime.Now,
				};

				products.Add(product);
			}

			dbContext.Products.AddRange(products);
			dbContext.SaveChanges();
		}
	}
}
