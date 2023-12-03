using Service.Dtos.Product.Update;
using Service.Handlers;
using Tests.HandlerTests.Base;

namespace Tests.HandlerTests
{
	/// <summary>
	/// The tests for ProductUpdateHandler
	/// </summary>
	public class ProductUpdateHandlerTests : BaseProductHandlerTest<ProductUpdateHandler, ProductUpdateRequestDto, ProductUpdateResponseDto>
	{
		/// <summary>
		/// Create instance for Handler tests
		/// </summary>
		public ProductUpdateHandlerTests() : base(true)
		{
			Handler = new ProductUpdateHandler(ProductRepository, Mapper);
			ProductRepositoryMock.Setup(x => x.GetAsync(Products.FirstOrDefault().Id)).Returns(Task.FromResult(Products.FirstOrDefault()));
		}

		[Fact]
		public void ProductUpdateHandlerTests_UpdateTheProduct_WithSuccess()
		{
			var request = new ProductUpdateRequestDto() { ProductId = Products.FirstOrDefault().Id, Description = "UpdatedMocked" };

			if (!UseMockedData)
			{
				request.ProductId = Guid.Parse("552E86CB-50BB-42AF-A2E3-0A1AEFE4FC54");
			}

			var result = Handler.Handle(request, default).Result;
			Assert.Null(result.ErrorCode);
			Assert.Empty(result.Errors);
		}
	}
}
