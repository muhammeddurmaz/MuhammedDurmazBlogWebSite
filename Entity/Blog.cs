using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Blog: BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public string Author { get; set; } 
        public bool IsActive { get; set; }
    }
}
