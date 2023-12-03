using AutoMapper;
using Domain;
using Infrastructure;
using Infrastructure.Repositories;
using Service.Dtos.Product;
using Service.Mappers.Mappings;
using Tests.Database;

namespace Tests.MapperTest
{
	/// <summary>
	/// The Mapper unit tests
	/// </summary>
	public class MapperTests
	{
		/// <summary>
		/// The Product repository
		/// </summary>
		private readonly IProductRepository productRepository;

		/// <summary>
		/// Create instance of MapperTests
		/// </summary>
		public MapperTests()
		{
			Mapper = new Mapper(new MapperConfiguration(cfg=>{cfg.AddProfile(new DomainToDtoMappingProfile());}));
			DbContext = DbHelper.GetDbContext(false);
			productRepository = new ProductRepository(DbContext);
		}

		/// <summary>
		/// The mapper
		/// </summary>
		private IMapper Mapper { get; set; }

		/// <summary>
		/// The database context
		/// </summary>
		private CatalogDbContext DbContext { get; set; }

		/// <summary>
		/// The test for mapping product entity to product response dto
		/// </summary>
		[Fact]
		public void MapProduct_To_ProductResponseDto()
		{
			var product = productRepository.GetAllAsync().Result.FirstOrDefault();
			var productDto = Mapper.Map<Product, ProductResponseDto>(product);

			Assert.NotNull(product);
			Assert.NotNull(productDto);
			Assert.NotNull(productDto.Name);
			Assert.NotNull(productDto.Description);
			Assert.NotNull(productDto.ImgUri);
		}
	}
}
