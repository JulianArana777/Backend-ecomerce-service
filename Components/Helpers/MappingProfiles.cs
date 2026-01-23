using Api.DTO;
using API.Entities;
using AutoMapper;

namespace API.Helper{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductDTO>()
            .ForMember( d => d.productbrand, o=> o.MapFrom(s=>s.productbrand.name))
            .ForMember(d=>d.producttype,o=>o.MapFrom(s=>s.producttype.name));

        }
    }
}