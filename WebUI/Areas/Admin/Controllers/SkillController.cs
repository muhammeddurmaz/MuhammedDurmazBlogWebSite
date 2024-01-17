using Business.Abstract;
using Entity.Dto.Skills;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly ISkillService skillService;

        public SkillController(ISkillService skillService)
        {
            this.skillService = skillService;
        }
        public IActionResult List()
        {
            var result = skillService.GetAllAdminViews();
            return View(result);
        }

        [HttpGet]
        public IActionResult Insert() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(SkillCreateDTO skillCreateDTO)
        {
            skillService.AddSkill(skillCreateDTO);
            return RedirectToAction("List", "Skill", new { Area = "Admin" });
        }
        public IActionResult Delete(Guid id) 
        {
            skillService.Delete(id);
            return RedirectToAction("List", "Skill", new { Area = "Admin" });
        }
    }
}
