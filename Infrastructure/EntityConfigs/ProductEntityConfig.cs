﻿using Domain;
using Infrastructure.EntityConfigs.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigs
{
	/// <summary>
	/// The Product entity configuration
	/// </summary>
	public class ProductEntityConfig : BaseEntityConfig<Product>, IProductEntityConfig
	{
		/// <summary>
		/// Configures the entity/table
		/// </summary>
		/// <param name="builder"></param>
		public override void Configure(EntityTypeBuilder<Product> builder)
		{
			base.Configure(builder);

			builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
			builder.Property(p => p.ImgUri).HasMaxLength(300).IsRequired();
			builder.Property(p => p.Price).HasPrecision(18,2).IsRequired();
			builder.Property(p => p.Description).IsRequired(false);
		}
	}
}
