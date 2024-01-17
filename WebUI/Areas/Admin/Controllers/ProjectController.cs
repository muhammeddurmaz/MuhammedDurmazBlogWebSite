using AutoMapper;
using Business.Abstract;
using Entity.Dto.Projects;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IMapper mapper;

        public ProjectController(IProjectService projectService,IMapper mapper) 
        {
            this.projectService = projectService;
            this.mapper = mapper;
        }
        public IActionResult List()
        {
            var result = projectService.GetAllProjectAdminViews();
            return View(result);
        }
        [HttpPost]
        public IActionResult Update(ProjectUpdateDTO projectDTO) 
        {
            projectService.Update(projectDTO);
            return RedirectToAction("List", "Project", new { Area = "Admin" });
        }
        [HttpPost]
        public IActionResult Insert(ProjectCreateRequestDTO projectDTO)
        {
            projectService.Insert(projectDTO);
            return RedirectToAction("List", "Project", new { Area = "Admin" });
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update(Guid id)
        {
            var projectDto = projectService.GetProjectDTOById(id);
            var result = mapper.Map<ProjectUpdateDTO>(projectDto);
            return View(result);
        }

        public IActionResult SafeDelete(Guid id)
        {
            projectService.SafeDelete(id);
            return RedirectToAction("List", "Project", new { Area = "Admin" });
        }
        public IActionResult HardDelete(Guid id)
        {
            projectService.HardDelete(id);
            return RedirectToAction("DeletedProject", "Project", new { Area = "Admin" });
        }
        public IActionResult UndoDelete(Guid id)
        {
            projectService.UndoDelete(id);
            return RedirectToAction("List", "Project", new { Area = "Admin" });
        }

        public IActionResult DeletedProject() 
        {
            var result = projectService.GetDeletedProjects();
            return View(result);
        }
    }
}
