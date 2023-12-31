﻿using Domain.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigs.Base
{
	/// <summary>
	/// The Base Entity Configuration interface
	/// </summary>
	public interface IBaseEntityConfig<TEntity>
		where TEntity : class, IBaseEntity
	{
		/// <summary>
		/// Configures the entity/table
		/// </summary>
		/// <param name="builder"></param>
		public void Configure(EntityTypeBuilder<TEntity> builder);
	}
}
