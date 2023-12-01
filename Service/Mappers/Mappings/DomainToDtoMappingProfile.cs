using AutoMapper;
using Domain;
using Service.Dtos.Product;

namespace Service.Mappers.Mappings
{
    public class DomainToDtoMappingProfile : Profile
	{
		public DomainToDtoMappingProfile()
		{
			CreateMap<Product, ProductResponseDto>();
		}
	}
}
