using AutoMapper;
using BSG.WebUI.Models;
using System.Linq;

namespace HOL.PMICompare.WebApp
{
    public static class AutoMapperConfig
    {
         public static void RegisterMappings(){

            Mapper.CreateMap<RegisterAsCoachViewModel, ApplicationUser>();
                //.ForMember(p => p.FirstName, d => d.MapFrom(src => src.FirstName));



            //    map.ForMember(dest => dest.MsmQuoteId, opt => opt.MapFrom(src => src.QuoteId));
        }

    }
}