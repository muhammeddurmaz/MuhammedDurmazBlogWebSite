using AutoMapper;
using Entity;
using Entity.Dto.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.Skills
{
    public class SkillProfile : Profile
    {
        public SkillProfile() 
        {
            CreateMap<SkillAdminViewDTO, Skill>().ReverseMap();
            CreateMap<SkillCreateDTO, Skill>().ReverseMap();
            CreateMap<SkillViewDTO, Skill>().ReverseMap();
        }
    }
}
