using AutoMapper;
using Domain;
using Infrastructure.Repositories;
using Moq;
using Service.Dtos.Base;
using Service.Handlers.Base;
using Service.Mappers.Mappings;
using Tests.Database;

namespace Tests.HandlerTests.Base
{
	/// <summary>
	/// The Base Tests for ProductHandlers
	/// </summary>
	public abstract class BaseProductHandlerTest<TRequestHandler,TRequestDto, TResponseDto>
		where TRequestDto : IBaseRequestDto<TResponseDto>
		where TResponseDto : IBaseResponseDto
		where TRequestHandler : IBaseHandler<TRequestDto, TResponseDto>
	{
		public BaseProductHandlerTest(bool useMockedData = true)
		{
			UseMockedData = useMockedData;

			Mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile(new DomainToDtoMappingProfile()); }));
			Products.Add(new Product(){Id = Guid.NewGuid(), Name = "MockedProduct", Description = "Mocked",Price = 0,ImgUri = "Mocked"});

			DbContext = DbHelper.GetDbContext(UseMockedData);
			if (UseMockedData)
			{
				ProductRepository = ProductRepositoryMock.Object;
			}
			else
			{
				ProductRepository = new ProductRepository(DbContext);
			}
		}

		/// <summary>
		/// The flag indicating the mocked data
		/// </summary>
		protected bool UseMockedData { get; set; }

		/// <summary>
		/// The Handler
		/// </summary>
		protected TRequestHandler Handler { get; set; }

		/// <summary>
		/// The Mapper
		/// </summary>
		protected IMapper Mapper { get; set; }

		/// <summary>
		/// The Db context
		/// </summary>
		protected CatalogDbContextTest DbContext { get; set; }

		/// <summary>
		/// The Mock for Product Repository
		/// </summary>
		protected Mock<IProductRepository> ProductRepositoryMock { get; set; } = new Mock<IProductRepository>();

		/// <summary>
		/// The Product Repository
		/// </summary>
		protected IProductRepository ProductRepository { get; set; }

		/// <summary>
		/// The Collection of Products
		/// </summary>
		protected IList<Product> Products { get; set; } = new List<Product>();
	}
}
