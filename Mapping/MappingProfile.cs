using AutoMapper;
using RealEstate.Api.Data.Entities;
using RealEstate.Api.DTOs;

namespace RealEstate.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // از CreatePropertyDto به Property
            CreateMap<CreatePropertyDto, Property>();

            // از UpdatePropertyDto به Property
            CreateMap<UpdatePropertyDto, Property>();

            // از Property به PropertyDto
            CreateMap<Property, PropertyDto>();
        }
    }
}