namespace Service.Dtos.Base
{
	/// <summary>
	/// The BaseResponseDto interface
	/// </summary>
	public interface IBaseResponseDto
	{
		/// <summary>
		/// The id of the request
		/// </summary>
		public Guid RequestId { get; set; }

		/// <summary>
		/// The error code
		/// </summary>
		public string ErrorCode { get; set; }
	}
}
