using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.About
{
    public class UpdateAboutDto
    {
        public string AboutTitle { get; set; }
        public string AboutDetail { get; set; }
        public string AboutImage { get; set; }
        public int PersonId { get; set; }
    }
}