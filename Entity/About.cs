using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class About : BaseEntity
    {
        public string desc { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
    }
}
