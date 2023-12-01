namespace Service.Dtos.Base
{
	public class BaseRequestDto<TResponse> : IBaseRequestDto<TResponse>
		where TResponse : IBaseResponseDto
	{
		Guid RequestId { get; set; }
	}
}
