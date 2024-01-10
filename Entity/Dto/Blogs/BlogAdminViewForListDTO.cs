using Entity.Dto.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Blogs
{
    public class BlogAdminViewForListDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int ViewCount { get; set; }
        public CategoryDTO Category { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
