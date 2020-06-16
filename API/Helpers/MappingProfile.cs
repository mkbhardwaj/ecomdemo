using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using API.DTO;


namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            CreateMap<Product, ProductToReturnDto>().ForMember(d=>d.ProductBrand,o=>o.MapFrom(s=> s.ProductBrand.Name)).
                ForMember(d=>d.ProductType,o=>o.MapFrom(s=>s.ProductType.Name)).ForMember(d=>
                d.PictureUrl,o=> o.MapFrom<ProductUrlResolver>());

        }
    }
}
