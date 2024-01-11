using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class EfCoreProjectRepository : EfCoreRepository<Project> , IProjectRepository
    {
        public EfCoreProjectRepository(WebSiteContext context) : base(context) 
        {

        }
    }
}
