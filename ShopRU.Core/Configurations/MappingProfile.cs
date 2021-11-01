using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRU.Core.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //=== Add as many of these lines as you need to map your objects
            //=== ReverseMap maps the destination to source type
            //CreateMap<App, RegisterAppViewModel>().ReverseMap();
        }
    }
}