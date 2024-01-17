using AutoMapper;
using Business.Abstract;
using Entity.Dto.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BlogController : Controller
	{
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public BlogController(IBlogService blogService,ICategoryService categoryService,IMapper mapper)
        {
            this.blogService = blogService;
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        public IActionResult Index()
		{
            List<BlogAdminViewForListDTO> blogDTOs = blogService.getAllBlogsForAdminList();
			return View(blogDTOs);
		}

        [HttpPost]
        public IActionResult Insert(BlogCreateDTO blogDTO)
        {
            blogService.AddBlog(blogDTO);
            return RedirectToAction("Index", "Blog", new { Area = "Admin" });
        }

        [HttpGet]
        public IActionResult Insert()
        {
            var categories = categoryService.getAllCategories();

            return View(new BlogCreateDTO { Categories = categories});
        }

        [HttpPost]
        public IActionResult Update(BlogUpdateDTO blogDTO)
        {
            blogService.UpdateBlog(blogDTO);
            Thread.Sleep(1500);
            return RedirectToAction("Index", "Blog", new { Area = "Admin" });
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            var categories = categoryService.getAllCategories();
            var blog = blogService.getBlogWithImageAndCategoryByBlogId(id);

            var blogUpdateDto = mapper.Map<BlogUpdateDTO>(blog);
            blogUpdateDto.Categories = categories;
            return View(blogUpdateDto);
        }

       
        public IActionResult HardDelete(Guid id)
        {
            blogService.HardDeleteBlog(id);
            return RedirectToAction("Index", "Blog", new { Area = "Admin" });
        }
        public IActionResult SafeDelete(Guid id)
        {
            blogService.SafeDeleteBlog(id);
            return RedirectToAction("Index", "Blog", new { Area = "Admin" });
        }

        public IActionResult DeletedBlog()
        {
            var result = blogService.getBlogsWithCategoryDeleted();
            return View(result);
        }

        public IActionResult UndoDelete(Guid id)
        {
            blogService.UndoDeleteBlog(id);
            return RedirectToAction("Index", "Blog", new { Area = "Admin" });
        }
    }
}
