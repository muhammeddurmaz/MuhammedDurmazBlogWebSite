using AutoMapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dto.HomePages;

namespace Business.AutoMapper.HomePages
{
    public class HomePageProfile : Profile
    {
        public HomePageProfile() 
        {
            CreateMap<HomePageCreateDTO, HomePage>().ReverseMap();
            CreateMap<HomePageViewDTO, HomePage>().ReverseMap();
            CreateMap<HomePageCreateDTO, HomePageViewDTO>().ReverseMap();
        }
    }
}
