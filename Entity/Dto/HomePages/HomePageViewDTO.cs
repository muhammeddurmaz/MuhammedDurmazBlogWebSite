using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.HomePages
{
    public class HomePageViewDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AboutInfo { get; set; }
        public int ViewCount { get; set; }
    }
}
