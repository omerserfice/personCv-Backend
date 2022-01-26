using personApp.DAL.DTO.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract
{
    public interface IProjectService
    {
        public List<GetProjectListDto> GetProjectList();
        public int AddProject(AddProjectDto addProjectDto);
        public GetProjectDto GetProjectById(int projectId);
        public int UpdateProject(int id, UpdateProjectDto updateProjectDto);
        public int DeleteProject(int id);
    }
}
