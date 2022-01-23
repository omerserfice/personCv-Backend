using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.Education
{
    public class UpdateEducationDto 
    {
        
        public string SchoolName { get; set; }
        public string Departmen { get; set; }
        public string EducationDetail { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
        public string PersonName { get; set; }
        public int PersonId { get; set; }   
    }
}
