using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class SkillViewComponent : ViewComponent
    {
        private readonly ISkillService skillService;

        public SkillViewComponent(ISkillService skillService) 
        {
            this.skillService = skillService;
        }

        public IViewComponentResult Invoke()
        {
            var result = skillService.GetAllViews();
            return View(result);
        }
    }
}
