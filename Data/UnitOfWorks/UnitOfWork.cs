using Data.Abstract;
using Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebSiteContext context;
        public UnitOfWork(WebSiteContext context) 
        {
            this.context = context;
        }
      
        public void Dispose()
        {
            context.Dispose();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new EfCoreRepository<T>(context);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
