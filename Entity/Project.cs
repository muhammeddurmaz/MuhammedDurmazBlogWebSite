using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Project : BaseEntity
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } 
    }
}
