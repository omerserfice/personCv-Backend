using Microsoft.EntityFrameworkCore;
using personApp.Business.Abstract;
using personApp.DAL.Context;
using personApp.DAL.DTO.Project;
using personApp.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Concrete
{
    public class ProjectService : IProjectService
    {
        private readonly personAppDbContext _personAppDbContext;

        public ProjectService(personAppDbContext personAppDbContext)
        {
            _personAppDbContext = personAppDbContext;
        }

        public int AddProject(AddProjectDto addProjectDto)
        {
            var newProject = new Project
            {
               ProjectName = addProjectDto.ProjectName, 
               ProjectDetail = addProjectDto.ProjectDetail, 
               ProjectImage = addProjectDto.ProjectImage,   
               ProjectGithubLink = addProjectDto.ProjectGithubLink,
               Status = addProjectDto.Status,
               PersonId = addProjectDto.PersonId,

            };
            _personAppDbContext.Projects.Add(newProject);
            return _personAppDbContext.SaveChanges();
        }

        public int DeleteProject(int id)
        {
            var currentProject = _personAppDbContext.Projects.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (currentProject == null)
            {
                return -1;
            }
            currentProject.IsDeleted = true;
            _personAppDbContext.Projects.Update(currentProject);
            return _personAppDbContext.SaveChanges();
        }

        public GetProjectDto GetProjectById(int projectId)
        {
           var currentProject = _personAppDbContext.Projects.Where(p=>!p.IsDeleted && p.Id == projectId).Include(p=>p.PersonFK)
                .Select(p=>new GetProjectDto
                {
                    Id = p.Id,
                    ProjectName = p.ProjectName,
                    ProjectDetail = p.ProjectDetail,    
                    ProjectGithubLink= p.ProjectGithubLink, 
                    ProjectImage = p.ProjectImage,
                    Status = p.Status,
                    PersonName = p.PersonFK.PersonName,
                    PersonSurname = p.PersonFK.PersonSurname,
                }).FirstOrDefault();
            return currentProject;

        }

        public List<GetProjectListDto> GetProjectList()
        {
            return _personAppDbContext.Projects.Where(p => !p.IsDeleted).Include(p => p.PersonFK)
                .Select(p=> new GetProjectListDto
                {
                    Id = p.Id,
                    ProjectName = p.ProjectName,
                    ProjectDetail = p.ProjectDetail,
                    ProjectGithubLink = p.ProjectGithubLink,
                    ProjectImage = p.ProjectImage,
                    Status = p.Status,
                    PersonName = p.PersonFK.PersonName,
                    PersonSurname = p.PersonFK.PersonSurname,

                }).ToList();
            
         }

        public int UpdateProject(int id, UpdateProjectDto updateProjectDto)
        {
            var currentProject = _personAppDbContext.Projects.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (currentProject == null)
            {
                return -1;
            }
            currentProject.ProjectName = updateProjectDto.ProjectName;
            currentProject.ProjectDetail = updateProjectDto.ProjectDetail;
            currentProject.ProjectGithubLink = updateProjectDto.ProjectGithubLink;
            currentProject.ProjectImage = updateProjectDto.ProjectImage;
            currentProject.Status = updateProjectDto.Status;
            currentProject.PersonId = updateProjectDto.PersonId;
            currentProject.MDate = DateTime.Now;

            _personAppDbContext.Projects.Update(currentProject);
            return _personAppDbContext.SaveChanges();
        }
    }
}
