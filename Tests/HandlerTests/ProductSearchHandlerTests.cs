using Service.Dtos.Product;
using Service.Handlers;
using Tests.HandlerTests.Base;

namespace Tests.HandlerTests
{
	/// <summary>
	/// The tests for ProductSearchHandler
	/// </summary>
	public class ProductSearchHandlerTests : BaseProductHandlerTest<ProductSearchHandler, SearchProductsRequestDto, SearchProductsResponseDto>
	{
		/// <summary>
		/// create instance of the handler tests
		/// </summary>
		public ProductSearchHandlerTests() : base(false)
		{
			Handler = new ProductSearchHandler(ProductRepository, Mapper);
			ProductRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(Products));
		}

		[Fact]
		public void ProductSearchHandlerTests_FindTheProducts_WithSuccess()
		{
			var request = new SearchProductsRequestDto();

			var result = Handler.Handle(request, default).Result;
			Assert.NotNull(result);
			Assert.Null(result.ErrorCode);
			Assert.NotNull(result.Data);
		}
	}
}
