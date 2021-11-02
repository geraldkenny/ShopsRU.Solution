using AutoMapper;
using ShopRU.Core.ModelDTO;
using ShopsRU.Entities;
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
            CreateMap<Customers, CustomerDTO>().ReverseMap();
            CreateMap<Discounts, DiscountDTO>().ReverseMap();
            CreateMap<Invoices, InvoiceBillDTO>().ForMember(x => x.Items, opt => opt.Ignore()).ReverseMap();
        }
    }
}