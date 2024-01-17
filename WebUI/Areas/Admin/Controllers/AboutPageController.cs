using AutoMapper;
using Business.Abstract;
using Entity.Dto.AboutPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutPageController : Controller
    {
        private readonly IAboutPageService aboutPageService;
        private readonly IMapper mapper;

        public AboutPageController(IAboutPageService aboutPageService,IMapper mapper)
        {
            this.aboutPageService = aboutPageService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContentInsert()
        {
            var content = aboutPageService.GetAboutContent();
            var result = mapper.Map<AboutPageCreateDTO>(content);
            return View(result);
        }
        [HttpPost]
        public IActionResult ContentInsert(AboutPageCreateDTO aboutPageCreateDTO)
        {
            aboutPageService.Update(aboutPageCreateDTO);
            return RedirectToAction("Index", "Home", new { Area = "Admin" });
            
        }
    }
}
