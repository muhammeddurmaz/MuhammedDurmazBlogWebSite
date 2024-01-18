using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult List()
        {
            var articles = _blogService.getAllBlogs();
            return View(articles);
        }
        public IActionResult Detail(Guid id) 
        {
            var result = _blogService.getBlogViewDetailById(id);
            return View(result);
        }
    }
}
