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
        public int abilityId { get; set; }
        public string abilityName { get; set; }
        public int abilityPoint { get; set; }
        public int PersonID { get; set; }
        public Person PersonFK { get; set; }
        public bool IsDeleted { get; set ; }
    }
}
