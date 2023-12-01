using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class Contact : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
