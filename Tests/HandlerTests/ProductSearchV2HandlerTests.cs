using Service.Dtos.Product;
using Service.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Dtos.Product.V2;
using Service.Handlers.V2;
using Tests.HandlerTests.Base;
using AutoMapper;
using Infrastructure.Repositories;

namespace Tests.HandlerTests
{
	/// <summary>
	/// The tests for ProductSearchV2Handler
	/// </summary>
	public class ProductSearchV2HandlerTests : BaseProductHandlerTest<ProductSearchV2Handler, SearchProductV2RequestDto, SearchProductV2ResponseDto>
	{
		/// <summary>
		/// Create instance of the handler tests
		/// </summary>
		public ProductSearchV2HandlerTests() : base(true)
		{
			Handler = new ProductSearchV2Handler(ProductRepository, Mapper);
			ProductRepositoryMock.Setup(x => x.GetPagedListAsync(10,0)).Returns(Task.FromResult(Products));
		}

		[Fact]
		public void ProductSearchV2HandlerTests_FindProducts_WithSuccess()
		{
			var request = new SearchProductV2RequestDto();

			var result = Handler.Handle(request,default).Result;
			Assert.NotNull(result);
			Assert.NotNull(result.Data);
			Assert.Null(result.ErrorCode);
		}

		[Fact]
		public void ProductSearchV2HandlerTests_FindProducts_WithFailure()
		{
			var request = new SearchProductV2RequestDto()
			{
				Offset = 50,
				PageSize = 1
			};

			var result = Handler.Handle(request, default).Result;
			Assert.NotNull(result);
			Assert.Null(result.Data);
			Assert.NotNull(result.ErrorCode);
		}
	}
}
