using AutoMapper;
using Business.Abstract;
using Data.UnitOfWorks;
using Entity;
using Entity.Dto.AboutPages;
using Entity.Dto.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutPageServiceImpl : IAboutPageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IImageService imageService;

        public AboutPageServiceImpl(IUnitOfWork unitOfWork,IMapper mapper,IImageService imageService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.imageService = imageService;
        }
        public AboutPageViewDTO GetAboutContent()
        {
            var page = unitOfWork.GetRepository<About>().GetAll(about => !about.IsDeleted,about => about.Image).FirstOrDefault();
            if (page == null)
            {
                var pageDto = new AboutPageViewDTO();
                
                return pageDto;
            }
            var pageContentDto = mapper.Map<AboutPageViewDTO>(page);
            return pageContentDto;
        }

        public void Update(AboutPageCreateDTO aboutPageCreateDTO)
        {
            if(aboutPageCreateDTO.Id != Guid.Empty)
            {
                var entity = unitOfWork.GetRepository<About>().GetEntity(about => about.Id == aboutPageCreateDTO.Id,a => a.Image);
                aboutPageCreateDTO.Image.Id = entity.ImageId;
                aboutPageCreateDTO.Image.Title = entity.Image.Title;
                var updated = mapper.Map(aboutPageCreateDTO, entity);
                unitOfWork.GetRepository<About>().Update(updated);
            }
            else
            {
                Image image = new Image { Title = "AboutPage", Url = aboutPageCreateDTO.Image.Url };
                imageService.AddImage(image);
                var entity = mapper.Map<About>(aboutPageCreateDTO);
                entity.CreatedBy = "Admin";
                entity.Image = image;
                entity.ImageId = image.Id;
                unitOfWork.GetRepository<About>().Save(entity);
            }
            unitOfWork.SaveChanges();
        }
    }
}
