namespace Domain.Base
{
	/// <summary>
	/// The base entity
	/// </summary>
	public abstract class BaseEntity : IBaseEntity
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public DateTime CreatedOn { get; set; }
		public string CreatedBy { get; set; }
		public DateTime UpdatedOn { get; set;}
		public string UpdatedBy { get; set;}
	}
}
