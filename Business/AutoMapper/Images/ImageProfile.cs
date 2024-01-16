using Entity.Dto.Categories;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Dto.Images;

namespace Business.AutoMapper.Images
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<ImageDTO, Image>().ReverseMap();
            CreateMap<ImageCreateRequest, Image>().ReverseMap();
        }
    }
}
