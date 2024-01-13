using AutoMapper;
using Business.Abstract;
using Data.Abstract;
using Data.UnitOfWorks;
using Entity;
using Entity.Dto.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CategoryServiceImpl(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public void AddCategory(CategoryCreateDTO categoryDTO)
        {
            var category = mapper.Map<Category>(categoryDTO);
            category.CreatedBy = "Admin";
            categoryRepository.Save(category);
            unitOfWork.SaveChanges();
        }

        public void DeleteCategory(Guid id)
        {
            categoryRepository.Delete(id);
            unitOfWork.SaveChanges();
        }

        public List<CategoryDTO> getAllCategories()
        {
            var resultCategories = mapper.Map<List<CategoryDTO>>(categoryRepository.GetAll());
            return resultCategories;
        }

        public CategoryDTO getCategoryById(Guid id)
        {
            var result = mapper.Map<CategoryDTO>(categoryRepository.GetById(id));
            return result;
        }

        public CategoryUpdateDTO getCategoryUpdateDto(Guid id)
        {
            var category = categoryRepository.GetById(id);
            return mapper.Map<CategoryUpdateDTO>(category);
        }

        public void UpdateCategory(CategoryUpdateDTO categoryDTO)
        {
            var category = mapper.Map<Category>(categoryDTO);
            categoryRepository.Update(category);
            unitOfWork.SaveChanges();
        }
    }
}
