namespace Domain.Base
{
	//The Base entity interface
	public interface IBaseEntity
	{
		Guid Id { get; set; }
		string CreatedOn { get; set; }
		string CreatedBy { get; set; }
		string UpdatedOn { get; set; }
		string UpdatedBy { get; set; }
	}
}
