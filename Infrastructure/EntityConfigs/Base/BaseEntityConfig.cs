using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigs.Base
{
	/// <summary>
	/// The Base entity configuration
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>, IBaseEntityConfig<TEntity>
		where TEntity : class, IBaseEntity
	{
		/// <summary>
		/// Configures the entity properties
		/// </summary>
		/// <param name="builder"></param>
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).IsRequired();
			builder.Property(p => p.CreatedOn).IsRequired();
			builder.Property(p => p.CreatedBy).IsRequired();
			builder.Property(p => p.UpdatedOn).IsRequired();
			builder.Property(p => p.UpdatedBy).IsRequired();
		}
	}
}
