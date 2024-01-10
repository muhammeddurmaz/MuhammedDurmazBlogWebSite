using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string ElementColor { get; set; }
    }
}
