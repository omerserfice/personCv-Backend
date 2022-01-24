using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.Experience
{
    public class GetExperienceDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Departman { get; set; }
        public string WorkPosition { get; set; }
        public string WorkDetail { get; set; }
        public DateTime StartDateOfWork { get; set; }
        public DateTime EndDateOfWork { get; set; }
        public bool Status { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
    }
}
