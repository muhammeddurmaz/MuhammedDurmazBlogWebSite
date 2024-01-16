using AutoMapper;
using Entity;
using Entity.Dto.AboutPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.AboutPages
{
    public class AboutPageProfile : Profile
    {
        public AboutPageProfile() 
        {
            CreateMap<AboutPageCreateDTO, About>().ReverseMap();
            CreateMap<AboutPageViewDTO, About>().ReverseMap();
            CreateMap<AboutPageCreateDTO, AboutPageViewDTO>().ReverseMap();
        }
    }
}
