using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.Project
{
    public class AddProjectDto
    {
       
        public string ProjectName { get; set; }
        public string ProjectDetail { get; set; }
        public string ProjectImage { get; set; }
        public string ProjectGithubLink { get; set; }
        public bool Status { get; set; }
        public int PersonId { get; set; }
    }
}
