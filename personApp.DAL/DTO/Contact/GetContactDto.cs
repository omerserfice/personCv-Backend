using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.Contact
{
    public class GetContactDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string Instagram { get; set; }
        public string Github { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
    }
}
