using personAppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.Entites
{
    public class Ability : Audit, IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string AbilityName { get; set; }
        public int AbilityPoint { get; set; }
        public int PersonId { get; set; }
        public Person PersonFK { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}
