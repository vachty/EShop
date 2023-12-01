using System.ComponentModel.DataAnnotations;

namespace Service.Dtos.Base
{
	public class BaseResponseDto : IBaseResponseDto
	{
		public BaseResponseDto() { }

		public BaseResponseDto(Guid requestId, string errorCode)
		{
			RequestId = requestId;
			ErrorCode = errorCode;
		}

		/// <summary>
		/// Request id
		/// </summary>
		[Required]
		public Guid RequestId { get; set; }

		/// <summary>
		/// Error of response
		/// </summary>
		public string ErrorCode { get; set; }
	}
}
