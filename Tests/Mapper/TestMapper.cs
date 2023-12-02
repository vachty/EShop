using AutoMapper;
using Service.Mappers.Base;
using Service.Mappers.Mappings;

namespace Tests.Mapper
{
	/// <summary>
	/// The mapper for testing purposes
	/// </summary>
	public class TestMapper : BaseMapper
	{
		/// <summary>
		/// Create instance of TestMapperss
		/// </summary>
		public TestMapper() : base(new AutoMapper.Mapper(new MapperConfiguration(cfg =>
		{
			cfg.AddProfile(new DomainToDtoMappingProfile());
		})))
		{
		}
	}
}
