using Entity.Dto.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISkillService
    {
        List<SkillViewDTO> GetAllViews();
        List<SkillAdminViewDTO> GetAllAdminViews();
        void AddSkill(SkillCreateDTO skillCreateDTO);
        void Delete(Guid id);
    }
}
