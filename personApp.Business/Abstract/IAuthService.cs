using personApp.DAL.DTO.User;
using personApp.DAL.Entites;
using personApp.DAL.LoginSecurity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract
{
    public interface IAuthService
    {
        AccessToken CreateAccessToken(User user);
        User GetLoginUser(UserLoginDto userLoginDto);
        int Register(UserRegisterDto userRegisterDto);

    }
}
