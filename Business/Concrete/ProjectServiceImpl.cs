using AutoMapper;
using Business.Abstract;
using Data.Abstract;
using Data.UnitOfWorks;
using Entity;
using Entity.Dto.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProjectServiceImpl : IProjectService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProjectRepository projectRepository;
        private readonly IMapper mapper;
        private readonly IImageService imageService;

        public ProjectServiceImpl(IUnitOfWork unitOfWork,IProjectRepository projectRepository,IMapper mapper,IImageService imageService)
        {
            this.unitOfWork = unitOfWork;
            this.projectRepository = projectRepository;
            this.mapper = mapper;
            this.imageService = imageService;
        }
        public List<ProjectAdminViewDTO> GetAllProjectAdminViews()
        {
            var projects = projectRepository.GetAll(p => !p.IsDeleted,p => p.Image);
            List<ProjectAdminViewDTO> projectAdminViewDTOs = mapper.Map<List<ProjectAdminViewDTO>>(projects);
            return projectAdminViewDTOs;
        }
        public List<ProjectAdminViewDTO> GetDeletedProjects()
        {
            var projects = projectRepository.GetAll(p => p.IsDeleted, p => p.Image);
            List<ProjectAdminViewDTO> projectAdminViewDTOs = mapper.Map<List<ProjectAdminViewDTO>>(projects);
            return projectAdminViewDTOs;
        }

        public List<ProjectViewDTO> GetAllProjectViews()
        {
            var projects = projectRepository.GetAll(p => !p.IsDeleted, p => p.Image);
            List<ProjectViewDTO> projectAdminViewDTOs = mapper.Map<List<ProjectViewDTO>>(projects);
            return projectAdminViewDTOs;
        }

        public ProjectDTO GetProjectDTOById(Guid id)
        {
            var entity = projectRepository.GetEntity(p => p.Id == id,p => p.Image);
            var projectDto = mapper.Map<ProjectDTO>(entity);
            return projectDto;
        }

        public ProjectViewDTO GetProjectViewById(Guid id)
        {
            var project = projectRepository.GetById(id);
            ProjectViewDTO projectViewDTO = mapper.Map<ProjectViewDTO>(project);
            return projectViewDTO;
        }

        public void HardDelete(Guid id)
        {
            var project = projectRepository.GetById(id);
            projectRepository.Delete(id);
            imageService.DeleteImage(project.ImageId);
            unitOfWork.SaveChanges();
        }

        public void Insert(ProjectCreateRequestDTO projectDto)
        {
            Image image = new Image { Title = projectDto.Name, Url = projectDto.Image.Url };
            imageService.AddImage(image);
            var project = mapper.Map<Project>(projectDto);
            project.CreatedBy = "Admin";
            project.ViewCount = 0;
            project.Image = image;
            project.ImageId = image.Id;
            projectRepository.Save(project);
            unitOfWork.SaveChanges();
        }

        public void SafeDelete(Guid id)
        {
            var project = projectRepository.GetById(id);
            project.IsDeleted = true;
            projectRepository.Update(project);
            unitOfWork.SaveChanges();
        }
        public void UndoDelete(Guid id)
        {
            var project = projectRepository.GetById(id);
            project.IsDeleted = false;
            projectRepository.Update(project);
            unitOfWork.SaveChanges();
        }

        public void Update(ProjectUpdateDTO projectDTO)
        {
            var entity = projectRepository.GetEntity(p => p.Id == projectDTO.Id,p => p.Image);
            projectDTO.Image.Id = entity.ImageId;
            projectDTO.Image.Title = entity.Image.Title;
            var updated = mapper.Map(projectDTO, entity);

            projectRepository.Update(updated);
            unitOfWork.SaveChanges();
        }
    }
}
