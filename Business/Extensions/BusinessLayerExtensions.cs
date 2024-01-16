using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.Concrete;
using Data.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class BusinessLayerExtensions
    {
        public static IServiceCollection LoadBusinessLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
			services.AddScoped<ICategoryService, CategoryServiceImpl>();
			services.AddScoped<IImageService, ImageServiceImpl>();
			services.AddScoped<IBlogService, BlogServiceImpl>();
            services.AddScoped<IContactFormService, ContactFormServiceImpl>();
            services.AddScoped<IContactService, ContactServiceImpl>();
            services.AddScoped<IHomePageService, HomePageServiceImpl>();
            services.AddScoped<IProjectService, ProjectServiceImpl>();
            services.AddScoped<ISkillService, SkillServiceImpl>();
            services.AddScoped<IAboutPageService, AboutPageServiceImpl>();

            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
