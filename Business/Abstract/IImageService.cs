
using Entity;
using Entity.Dto.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageService
    {
        ImageDTO getImageById(Guid id);
        List<ImageDTO> getAllImages();
        void AddImage(Image imageCreateRequest);
        void DeleteImage(Guid id);
    }
}
