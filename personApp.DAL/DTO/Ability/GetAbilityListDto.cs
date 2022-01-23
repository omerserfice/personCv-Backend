using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.Ability
{
    public class GetAbilityListDto
    {
        public int Id { get; set; }
        public string AbilityName { get; set; }
        public int AbilityPoint { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
    }
}
