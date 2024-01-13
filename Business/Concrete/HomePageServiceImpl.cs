using AutoMapper;
using Business.Abstract;
using Data.UnitOfWorks;
using Entity;
using Entity.Dto.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HomePageServiceImpl : IHomePageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public HomePageServiceImpl(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public HomePageViewDTO GetHomeContent()
        {
            var homeContent = unitOfWork.GetRepository<HomePage>().GetAll().FirstOrDefault();
            if (homeContent == null )
            {
                var content = new HomePageViewDTO();
               
                return new HomePageViewDTO();
            }
            var homeContentDto = mapper.Map<HomePageViewDTO>(homeContent);
            return homeContentDto;
        }

        public void Update(HomePageCreateDTO content)
        {
            if (content.Id != Guid.Empty)
            {
                var entity = unitOfWork.GetRepository<HomePage>().GetById(content.Id);
                var updated = mapper.Map(content, entity);
                unitOfWork.GetRepository<HomePage>().Update(updated);
            }
            else
            {
                var entity = mapper.Map<HomePage>(content);
                entity.CreatedBy = "Admin";
                unitOfWork.GetRepository<HomePage>().Save(entity);
            }
            unitOfWork.SaveChanges();
        }
    }
}
