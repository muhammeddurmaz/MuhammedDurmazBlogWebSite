using Entity.Dto.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.AboutPages
{
    public class AboutPageViewDTO
    {
        public Guid Id { get; set; }
        public string desc { get; set; }
        public Guid ImageId { get; set; }
        public ImageDTO Image { get; set; }
    }
}
