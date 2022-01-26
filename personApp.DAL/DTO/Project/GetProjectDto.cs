using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.Project
{
    public class GetProjectDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDetail { get; set; }
        public string ProjectImage { get; set; }
        public string ProjectGithubLink { get; set; }
        public bool Status { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
    }
}
