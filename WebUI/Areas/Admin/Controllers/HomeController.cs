using AutoMapper;
using Business.Abstract;
using Entity.Dto.Blogs;
using Entity.Dto.HomePages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
		private readonly IBlogService blogService;
        private readonly IHomePageService homePageService;
        private readonly IMapper mapper;

        public HomeController(IBlogService blogService,IHomePageService homePageService,IMapper mapper)
		{
			this.blogService = blogService;
            this.homePageService = homePageService;
            this.mapper = mapper;
        }

		public IActionResult Index()
        {
			List<BlogAdminViewForListDTO> blogDTOs = blogService.getAllBlogsForAdminList();
			return View(blogDTOs);
        }
		[HttpPost]
		public IActionResult ContentInsert(HomePageCreateDTO pageDto)
		{
            homePageService.Update(pageDto);
            return RedirectToAction("Index", "Home", new { Area = "Admin" });
        }
        [HttpGet]
        public IActionResult ContentInsert()
        {
            var content =  homePageService.GetHomeContent();
            var result = mapper.Map<HomePageCreateDTO>(content);
            return View(result);
        }
    }
}
