namespace Domain.Base
{
	/// <summary>
	/// The base entity
	/// </summary>
	public abstract class BaseEntity : IBaseEntity
	{
		public Guid Id { get; set; }
		public string CreatedOn { get; set; }
		public string CreatedBy { get; set; }
		public string UpdatedOn { get; set;}
		public string UpdatedBy { get; set;}
	}
}
