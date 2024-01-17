using AutoMapper;
using Business.Abstract;
using Entity.Dto.Blogs;
using Entity.Dto.Categories;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = categoryService.getAllCategories();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(CategoryCreateDTO categoryDTO)
        {
            categoryService.AddCategory(categoryDTO);
			return RedirectToAction("Index", "Category", new { Area = "Admin" });
		}

        public IActionResult Delete(Guid id)
        {
            categoryService.DeleteCategory(id);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        [HttpPost]
        public IActionResult Update(CategoryUpdateDTO categoryCreateDTO)
        {
            categoryService.UpdateCategory(categoryCreateDTO);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
      
            var category = categoryService.getCategoryUpdateDto(id);

         
            return View(category);
        }
    }
}
