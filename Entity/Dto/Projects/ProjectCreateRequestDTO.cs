using Entity.Dto.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Projects
{
    public class ProjectCreateRequestDTO
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ImageCreateRequest Image { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
