using Domain;
using Infrastructure.EntityConfigs.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigs
{
	/// <summary>
	/// The Product entity configuration
	/// </summary>
	public class ProductEntityConfig : BaseEntityConfig<Product>, IProductEntityConfig
	{
		public override void Configure(EntityTypeBuilder<Product> builder)
		{
			base.Configure(builder);

			builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
			builder.Property(p => p.ImgUri).HasMaxLength(300).IsRequired();
			builder.Property(p => p.Price).IsRequired();
			builder.Property(p => p.Description).IsRequired(false);
		}
	}
}
