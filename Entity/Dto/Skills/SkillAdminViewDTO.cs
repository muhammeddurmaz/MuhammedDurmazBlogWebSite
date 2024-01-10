using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Skills
{
    public class SkillAdminViewDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string ElementColor { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
