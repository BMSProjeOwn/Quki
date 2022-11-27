using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.DtoModels;

namespace Quki.Entity.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Products, Product>().ReverseMap();
            CreateMap<Counrty, CountryApiModel>().ReverseMap();

            CreateMap<RvcMenuItemDef, RvcMenuItemDefModel>().ReverseMap();
        }
    }
}
