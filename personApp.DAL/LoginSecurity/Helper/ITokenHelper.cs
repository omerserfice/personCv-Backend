using personApp.DAL.Entites;
using personApp.DAL.LoginSecurity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.LoginSecurity.Helper
{
    public interface ITokenHelper 
    {
        AccessToken CreateToken(User user, IEnumerable<Role> userRoles);
    }
}
