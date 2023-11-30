namespace Domain.Base
{
	//The Base entity interface
	public interface IBaseEntity
	{
		Guid Id { get; set; }
		DateTime CreatedOn { get; set; }
		string CreatedBy { get; set; }
		DateTime UpdatedOn { get; set; }
		string UpdatedBy { get; set; }
	}
}
