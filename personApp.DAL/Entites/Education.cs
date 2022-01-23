using personAppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.Entites
{
    public class Education : Audit, IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Departmen { get; set; }
        public string EducationDetail { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
        public int PersonId { get; set; }
        public Person PersonFK { get; set; }
        public bool IsDeleted { get; set; }
    }
}
