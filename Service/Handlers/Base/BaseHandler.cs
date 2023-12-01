using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Service.Dtos.Base;
using Service.Results;

namespace Service.Handlers.Base
{
	public abstract class BaseHandler<TRequest, TResponse> : IBaseHandler<TRequest, TResponse>
		where TRequest : IBaseRequestDto<TResponse>
		where TResponse : IBaseResponseDto
	{
		public abstract Task<IApiResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);

		protected virtual TResponseDto CreateResponseDto<TResponseDto>(string? errorCode = null) where TResponseDto : IBaseResponseDto, new()
		{
			var response = new TResponseDto()
			{
				RequestId = Guid.NewGuid()
			};

			if (errorCode != null)
			{
				response.ErrorCode = errorCode;
			}

			return response;
		}
	}
}
