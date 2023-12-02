using System.ComponentModel.DataAnnotations;

namespace Service.Dtos.Base
{
	/// <summary>
	/// The base class for response data transfer objects
	/// </summary>
	public abstract class BaseResponseDto : IBaseResponseDto
	{
		/// <summary>
		/// Create instance of the dto
		/// </summary>
		public BaseResponseDto() { }

		/// <summary>
		/// Create instance of the dto
		/// </summary>
		/// <param name="requestId"></param>
		/// <param name="errorCode"></param>
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
