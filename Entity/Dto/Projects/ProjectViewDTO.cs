using Entity.Dto.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Projects
{
    public class ProjectViewDTO
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ImageDTO Image { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
