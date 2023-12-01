using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
