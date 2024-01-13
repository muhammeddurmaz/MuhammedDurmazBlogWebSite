using Entity;
using Entity.Dto.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        BlogDTO getBlogById(Guid id);
        BlogDetailDTO getBlogViewDetailById(Guid id);
        List<BlogDTO> getAllBlogs();
        void AddBlog(BlogCreateDTO blog);
        List<BlogAdminViewForListDTO> getAllBlogsForAdminList();
        BlogDTO getBlogWithImageAndCategoryByBlogId(Guid id);
        void UpdateBlog(BlogUpdateDTO blog);
        void HardDeleteBlog(Guid id);
        void SafeDeleteBlog(Guid id);
        void UndoDeleteBlog(Guid id);
        List<BlogAdminViewForListDTO> getBlogsWithCategoryDeleted();
    }
}
