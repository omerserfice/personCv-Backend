using personAppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.Entites
{
    public class Role : Audit, IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public bool IsDeleted { get; set; }
    }
}
