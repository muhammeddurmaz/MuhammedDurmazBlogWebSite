using AutoMapper;
using Business.Abstract;
using Data.Abstract;
using Data.UnitOfWorks;
using Entity;
using Entity.Dto.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageServiceImpl : IImageService
    {
        private readonly IImageRepository imageRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ImageServiceImpl(IImageRepository imageRepository,IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void AddImage(Image imageCreateRequest)
        {
            imageCreateRequest.CreatedBy = "Admin";
            imageRepository.Save(imageCreateRequest);
            unitOfWork.SaveChanges();
        }

        public void DeleteImage(Guid id)
        {
            imageRepository.Delete(id);
            unitOfWork.SaveChanges();
        }

        public List<ImageDTO> getAllImages()
        {
            var images = imageRepository.GetAll();
            var imagesDtos = mapper.Map<List<ImageDTO>>(images);
            return imagesDtos;
        }

        public ImageDTO getImageById(Guid id)
        {
            var imageDb = imageRepository.GetById(id);
            var result = new ImageDTO() { Id = imageDb.Id,Url = imageDb.Url};
            return result;
        }
    }
}
