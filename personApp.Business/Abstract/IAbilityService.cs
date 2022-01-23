using personApp.DAL.DTO.Ability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract
{
    public interface IAbilityService
    {
        public List<GetAbilityListDto> GetAbilityList();
        public int AddAbility(AddAbilityDto addAbilityDto);
        public GetAbilityDto GetAbilityById(int abilityId);
        public int UpdateAbility(int id, UpdateAbilityDto updateAbilityDto);
        public int DeleteAbility(int id);
    }
}
