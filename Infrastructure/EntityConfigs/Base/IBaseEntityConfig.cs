using Domain.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigs.Base
{
	/// <summary>
	/// The Base Entity Configuration interface
	/// </summary>
	public interface IBaseEntityConfig<TEntity>
		where TEntity : class, IBaseEntity
	{
		public void Configure(EntityTypeBuilder<TEntity> builder);
	}
}
