
using Entity.Dto.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        CategoryDTO getCategoryById(Guid id);
        List<CategoryDTO> getAllCategories();
        void AddCategory(CategoryCreateDTO categoryDTO);
        void DeleteCategory(Guid id);
        void UpdateCategory(CategoryUpdateDTO categoryDTO);
        CategoryUpdateDTO getCategoryUpdateDto(Guid id);
    }
}
