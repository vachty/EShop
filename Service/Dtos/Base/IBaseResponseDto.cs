namespace Service.Dtos.Base
{
	public interface IBaseResponseDto
	{
		public Guid RequestId { get; set; }

		public string ErrorCode { get; set; }
	}
}
