using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutPageService aboutPageService;

        public AboutController(IAboutPageService aboutPageService)
        {
            this.aboutPageService = aboutPageService;
        }
        public IActionResult Index()
        {
            var result = aboutPageService.GetAboutContent();
            return View(result);
        }
    }
}
