using AutoMapper;
using Business.Abstract;
using Data.UnitOfWorks;
using Entity;
using Entity.Dto.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SkillServiceImpl : ISkillService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SkillServiceImpl(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public void AddSkill(SkillCreateDTO skillCreateDTO)
        {
            var skill = mapper.Map<Skill>(skillCreateDTO);
            skill.CreatedBy = "Admin";
            unitOfWork.GetRepository<Skill>().Save(skill);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            unitOfWork.GetRepository<Skill>().Delete(id);
            unitOfWork.SaveChanges();
        }

        public List<SkillAdminViewDTO> GetAllAdminViews()
        {
            var entities = unitOfWork.GetRepository<Skill>().GetAll();
            var skillDtos = mapper.Map<List<SkillAdminViewDTO>>(entities);
            return skillDtos;
        }

        public List<SkillViewDTO> GetAllViews()
        {
            var entities = unitOfWork.GetRepository<Skill>().GetAll();
            var skillDtos = mapper.Map<List<SkillViewDTO>>(entities);
            return skillDtos;
        }
    }
}
