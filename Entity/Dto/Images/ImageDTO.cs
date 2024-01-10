using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Images
{
    public class ImageDTO
    {
        public Guid Id { get; set; }    
        public string Url { get; set; }
        public string Title { get; set; }
    }
}
