using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.User
{
    public class UserRegisterDto
    {
        public string TCNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }

    }
}
