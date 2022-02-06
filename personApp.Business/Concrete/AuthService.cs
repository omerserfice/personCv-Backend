using Microsoft.EntityFrameworkCore;
using personApp.Business.Abstract;
using personApp.DAL.Context;
using personApp.DAL.DTO.User;
using personApp.DAL.Entites;
using personApp.DAL.LoginSecurity.Entity;
using personApp.DAL.LoginSecurity.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly personAppDbContext _context;
        private readonly ITokenHelper _tokenHelper;

        public AuthService(personAppDbContext context, ITokenHelper tokenHelper)
        {
            _context = context;
            _tokenHelper = tokenHelper;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var currentUserRoles = GetUserRolesByUserId(user.Id);
            return currentUserRoles == null ? null : _tokenHelper.CreateToken(user, currentUserRoles);
        }

        private IEnumerable<Role> GetUserRolesByUserId(int userId)
        {
            return _context.UserRoles.Where(p=>!p.IsDeleted && p.UserId == userId)
                .Include(p=>p.RoleFK)
                .Select(p=>p.RoleFK)
                .ToList();
        }



        public User GetLoginUser(UserLoginDto userLoginDto)
        {
            var currentUser =  _context.Users
                 .Where(p => !p.IsDeleted).FirstOrDefault();
            if (currentUser == null) return null;
            var passwordMatchResult = HashingHelper.VerifyPasswordHash(userLoginDto.Password, currentUser.PasswordHash,
                currentUser.PasswordSalt);
            if (passwordMatchResult)
            {
                return currentUser;
            }
            else
            {
                return new User();  
            }
        }

        public int Register(UserRegisterDto userRegisterDto)
        {
           var currentTime = DateTime.Now;
            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out var passwordHash, out var passwordSalt);
            var user = new User
            {
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,  
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CDate = currentTime,
                UserRoles = new List<UserRole>
                {
                    new() {RoleId = userRegisterDto.UserRole,CDate=currentTime},
                }
            };
            _context.Users.Add(user);
            return _context.SaveChanges();

        }
    }
}
