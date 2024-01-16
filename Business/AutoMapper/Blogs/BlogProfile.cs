using AutoMapper;
using Entity;
using Entity.Dto.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.Blogs
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogDTO, Blog>().ReverseMap();
            CreateMap<BlogCreateDTO, Blog>().ReverseMap();
            CreateMap<BlogAdminViewForListDTO, Blog>().ReverseMap();
            CreateMap<BlogUpdateDTO, Blog>().ReverseMap();
            CreateMap<BlogUpdateDTO, BlogDTO>().ReverseMap();
            CreateMap<BlogDetailDTO, Blog>().ReverseMap();
        }
    }
}
