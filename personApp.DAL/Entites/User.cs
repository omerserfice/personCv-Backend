using personAppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.Entites
{
    public class User : Audit, IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string TCNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //Şifre direkt olarak değil şifrelenmiş halde veritabanında tutulur.
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public bool IsDeleted { get; set; }
    }
}
