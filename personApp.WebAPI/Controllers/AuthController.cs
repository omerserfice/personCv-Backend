using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personApp.Business.Abstract;
using personApp.DAL.DTO.User;

namespace personApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(UserRegisterDto userRegisterDto)
        {
            var registerResult = _authService.Register(userRegisterDto);
            if (registerResult > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "Kullanıcı Kaydı Başarılı", type = "success" });
            }
            return Ok(new { code = StatusCode(1001), message = "Kullanıcı Kaydı Başarısız", type = "error" });
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(UserLoginDto userLoginDto)
        {
            var currentUser = _authService.GetLoginUser(userLoginDto);
            if (currentUser == null)
            {
                Ok(new { code = StatusCode(1001), message = "Kullanıcı Bulunamadı", type = "error" });
            }else if(currentUser.Surname == null)
            {
                Ok(new { code = StatusCode(1001), message = "Kullanıcı Adı veya Şifre Yanlış", type = "error" });
            }
            var accessToken = _authService.CreateAccessToken(currentUser);
            return Ok(accessToken);
        }

        //[Authorize]
        //[HttpGet]
        //public ActionResult GetAllUser(int id)
        //{
        //    return null;

        //}
        //[Authorize(Roles ="Admin")]
        //[HttpGet]
        //public ActionResult GetUserById(int id)
        //{
        //    return null;

        //}

    }
}
