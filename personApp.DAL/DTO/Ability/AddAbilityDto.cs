using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.Ability
{
    public class AddAbilityDto
    {
        public string AbilityName { get; set; }
        public int AbilityPoint { get; set; }
        public int PersonId { get; set; }
    }
}
