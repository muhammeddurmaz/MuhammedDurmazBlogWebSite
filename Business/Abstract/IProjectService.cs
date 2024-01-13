using Entity.Dto.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProjectService
    {
        void Insert(ProjectCreateRequestDTO projectDto);
        ProjectViewDTO GetProjectViewById(Guid id);
        List<ProjectViewDTO> GetAllProjectViews();
        List<ProjectAdminViewDTO> GetAllProjectAdminViews();
        List<ProjectAdminViewDTO> GetDeletedProjects();
        void Update(ProjectUpdateDTO projectDTO);
        void SafeDelete(Guid id);
        void HardDelete(Guid id);
        void UndoDelete(Guid id);
        ProjectDTO GetProjectDTOById(Guid id);
    }
}
