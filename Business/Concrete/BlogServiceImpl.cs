using AutoMapper;
using Business.Abstract;
using Data.Abstract;
using Data.UnitOfWorks;
using Entity;
using Entity.Dto.Blogs;
using Entity.Dto.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogServiceImpl : IBlogService
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService imageService;

        public BlogServiceImpl(IBlogRepository blogRepository,IMapper mapper,IUnitOfWork unitOfWork,IImageService imageService)
        {
            this.blogRepository = blogRepository;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this.imageService = imageService;
        }

        public void AddBlog(BlogCreateDTO blogDto)
        {
            //var data = _mapper.Map<Blog>(blogDto);
            Image image = new Image { Title = blogDto.Title, Url = blogDto.Image.Url };
            imageService.AddImage(image);
            //var data = new Blog { CategoryId = blogDto.CategoryId, Content = blogDto.Content, Title = blogDto.Title , ImageId = image.Id};
            var data = _mapper.Map<Blog>(blogDto);
            data.ViewCount = 0;
            data.CreatedBy = "Admin";
            data.ImageId = image.Id;
            data.Image = image;
            blogRepository.Save(data);
            _unitOfWork.SaveChanges();
        }

        public void HardDeleteBlog(Guid id)
        {
            var blog = blogRepository.GetEntity(blog => blog.IsDeleted, blog => blog.Image);
            blogRepository.Delete(id);
            imageService.DeleteImage(blog.ImageId);
            _unitOfWork.SaveChanges();
        }
        public void SafeDeleteBlog(Guid id)
        {
            var entity = blogRepository.GetById(id);
            entity.IsDeleted = true;
            blogRepository.Update(entity);
            _unitOfWork.SaveChanges();
        }
        public void UndoDeleteBlog(Guid id)
        {
            var entity = blogRepository.GetById(id);
            entity.IsDeleted = false;
            blogRepository.Update(entity);
            _unitOfWork.SaveChanges();
        }


        public List<BlogDTO> getAllBlogs()
        {
            var blogs = blogRepository.GetAll(blog => blog.IsActive && !blog.IsDeleted, blog => blog.Category, blog => blog.Image);
            var map = _mapper.Map<List<BlogDTO>>(blogs);
            return map;
        }


        public List<BlogAdminViewForListDTO> getAllBlogsForAdminList()
        {
            var blogs = blogRepository.GetAll(blog => !blog.IsDeleted, blog => blog.Category);
            var map = _mapper.Map<List<BlogAdminViewForListDTO>>(blogs);
            return map;
        }

        public BlogDTO getBlogById(Guid id)
        {
            var blog = blogRepository.GetById(id);
            var map = _mapper.Map<BlogDTO>(blog);
            return map;
        }

        public List<BlogAdminViewForListDTO> getBlogsWithCategoryDeleted()
        {
            var blogs = blogRepository.GetAll(blog => blog.IsDeleted, blog => blog.Category);
            var map = _mapper.Map<List<BlogAdminViewForListDTO>>(blogs);
            return map;
        }

        public BlogDetailDTO getBlogViewDetailById(Guid id)
        {
            var blog = blogRepository.GetEntity(blog => blog.Id == id, blog => blog.Category, blog => blog.Image);
            var map = _mapper.Map<BlogDetailDTO>(blog);
            return map;
        }

        public BlogDTO getBlogWithImageAndCategoryByBlogId(Guid id)
        {
            var blog = blogRepository.GetEntity(blog => blog.Id == id,blog => blog.Category,blog => blog.Image);
            var map = _mapper.Map<BlogDTO>(blog) ;
            return map;
        }

        public void UpdateBlog(BlogUpdateDTO blogDTO)
        {
            var blogEntity = blogRepository.GetEntity(blog => blog.Id == blogDTO.Id, blog => blog.Category, blog => blog.Image);
            blogDTO.Image.Id = blogEntity.ImageId;
            blogDTO.Image.Title = blogEntity.Image.Title;
            _mapper.Map(blogDTO,blogEntity);
          
            blogRepository.Update(blogEntity);
            _unitOfWork.SaveChanges();
        }
    }
}
