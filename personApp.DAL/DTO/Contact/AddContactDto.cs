using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.Contact
{
    public class AddContactDto
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string Instagram { get; set; }
        public string Github { get; set; }
        public int PersonId { get; set; }
    }
}
