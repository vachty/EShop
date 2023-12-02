using AutoMapper;
using Domain;
using Service.Dtos.Product;

namespace Service.Mappers.Mappings
{
	/// <summary>
	/// The mapping profile for the automapper
	/// </summary>
    public class DomainToDtoMappingProfile : Profile
	{
		/// <summary>
		/// Create instance of the profile
		/// </summary>
		public DomainToDtoMappingProfile()
		{
			CreateMap<Product, ProductResponseDto>();
		}
	}
}
