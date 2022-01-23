using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO
{
    public class UpdatePersonDto
    {

        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public DateTime PersonBirthDay { get; set; }
        public string PersonCity { get; set; }
    }
}
