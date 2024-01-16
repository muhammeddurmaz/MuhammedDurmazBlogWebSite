using AutoMapper;
using Entity;
using Entity.Dto.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.Projects
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile() 
        {
            CreateMap<ProjectAdminViewDTO, Project>().ReverseMap();
            CreateMap<ProjectCreateRequestDTO, Project>().ReverseMap();
            CreateMap<ProjectViewDTO, Project>().ReverseMap();
            CreateMap<ProjectDTO, Project>().ReverseMap();
            CreateMap<ProjectUpdateDTO, ProjectDTO>().ReverseMap();
            CreateMap<ProjectUpdateDTO, Project>().ReverseMap();
        }
    }
}
