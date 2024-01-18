using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomePageService homePageService;
        private readonly IContactService contactService;
        private readonly IBlogService blogService;

        public HomeController(ILogger<HomeController> logger,IHomePageService homePageService,IContactService contactService,IBlogService blogService)
        {
            _logger = logger;
            this.homePageService = homePageService;
            this.contactService = contactService;
            this.blogService = blogService;
        }

        public IActionResult Index()
        {
            var content = homePageService.GetHomeContent();
            var contacts = contactService.GetContactView();
            var blogs = blogService.getAllBlogs();
            blogs = blogService.getAllBlogs().GetRange(0,Math.Min(4,blogs.Count));
            var result = new HomeViewModel { HomePageViewDTO = content, ContactViewDTO = contacts , Blogs = blogs};
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
