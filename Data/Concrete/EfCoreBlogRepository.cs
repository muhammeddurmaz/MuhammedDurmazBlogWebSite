using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class EfCoreBlogRepository : EfCoreRepository<Blog>, IBlogRepository
    {
        public EfCoreBlogRepository(WebSiteContext context) : base(context)
        {
        }
    }
}
