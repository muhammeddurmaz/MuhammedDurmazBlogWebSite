using Data.Abstract;
using Data.Concrete;
using Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services,IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>),typeof(EfCoreRepository<>));
            services.AddScoped<IBlogRepository, EfCoreBlogRepository>();
			services.AddScoped<IImageRepository, EfCoreImageRepository>();
			services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<IProjectRepository, EfCoreProjectRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            

            services.AddDbContext<WebSiteContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
