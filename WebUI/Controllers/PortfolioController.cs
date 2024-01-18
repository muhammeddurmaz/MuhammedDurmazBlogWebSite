using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IProjectService projectService;

        public PortfolioController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        public IActionResult Index()
        {
            var projects = projectService.GetAllProjectViews();
            return View(projects);
        }
    }
}
