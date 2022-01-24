using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.About
{
    public class GetAboutListDto
    {
        public int Id { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDetail { get; set; }
        public string AboutImage { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
    }
}
