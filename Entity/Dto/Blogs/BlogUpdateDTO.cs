using Entity.Dto.Categories;
using Entity.Dto.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Blogs
{
    public class BlogUpdateDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public ImageDTO Image { get; set; }
        public IList<CategoryDTO> Categories { get; set; }
        public CategoryDTO Category { get; set; }
        public string Author { get; set; }
        public bool IsActive { get; set; }
    }
}
