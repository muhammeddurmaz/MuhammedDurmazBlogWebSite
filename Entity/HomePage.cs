using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HomePage : BaseEntity
    {
        public string Title { get; set; }
        public string AboutInfo { get; set; }
        public int ViewCount { get; set; }
    }
}
