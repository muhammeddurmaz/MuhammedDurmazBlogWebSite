using Entity.Dto.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.AboutPages
{
    public class AboutPageCreateDTO
    {
        public Guid Id { get; set; }
        public string desc { get; set; }
        public ImageDTO Image { get; set; }
    }
}
