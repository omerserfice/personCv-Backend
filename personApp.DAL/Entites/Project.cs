using personAppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.Entites
{
    public class Project : Audit, IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDetail { get; set; }
        public string ProjectImage { get; set; }
        public string ProjectGithubLink { get; set; }
        public bool Status { get; set; }
        public int PersonId { get; set; }
        public Person PersonFK { get; set; }
        public bool IsDeleted { get; set; }
    }
}
