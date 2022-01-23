using Microsoft.EntityFrameworkCore;
using personApp.Business.Abstract;
using personApp.DAL.Context;
using personApp.DAL.DTO.Ability;
using personApp.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Concrete
{
    public class AbilityService : IAbilityService
    {
        private readonly personAppDbContext _personAppDbContext;

        public AbilityService(personAppDbContext personAppDbContext)
        {
            _personAppDbContext = personAppDbContext;
        }

        public List<GetAbilityListDto> GetAbilityList()
        {
            return _personAppDbContext.Abilities.Where(p => !p.IsDeleted).Include(p => p.PersonFK)
                 .Select(p => new GetAbilityListDto
                 {
                     Id = p.Id, 
                     AbilityName = p.AbilityName,
                     AbilityPoint = p.AbilityPoint, 
                     PersonName = p.PersonFK.PersonName,
                     PersonSurname = p.PersonFK.PersonSurname

                 }).ToList();
        }

        public int AddAbility(AddAbilityDto addAbilityDto)
        {
            var newAbility = new Ability
            {
                AbilityName = addAbilityDto.AbilityName,    
                AbilityPoint = addAbilityDto.AbilityPoint, 
                PersonId = addAbilityDto.PersonId,
            };
            _personAppDbContext.Abilities.Add(newAbility);
            return _personAppDbContext.SaveChanges();
        }

        public int DeleteAbility(int id)
        {
            var ability = _personAppDbContext.Abilities.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (ability == null)
            {
                return -1;  
            }
           ability.IsDeleted = true;
            _personAppDbContext.Abilities.Update(ability);
            return _personAppDbContext.SaveChanges();
        }

        public GetAbilityDto GetAbilityById(int abilityId)
        {
            var ability = _personAppDbContext.Abilities.Where(p => !p.IsDeleted && p.Id == abilityId).Include(p => p.PersonFK)
                 .Select(p => new GetAbilityDto
                 {
                     Id = p.Id,
                     AbilityName = p.AbilityName,
                     AbilityPoint = p.AbilityPoint,
                     PersonName = p.PersonFK.PersonName,
                     PersonSurname = p.PersonFK.PersonSurname
                 }).FirstOrDefault();
            return ability;
        }

       

        public int UpdateAbility(int id, UpdateAbilityDto updateAbilityDto)
        {
            var ability = _personAppDbContext.Abilities.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (ability == null)
            {
                return -1;
            }
            ability.AbilityName = updateAbilityDto.AbilityName; 
            ability.AbilityPoint = updateAbilityDto.AbilityPoint;
            ability.PersonId = updateAbilityDto.PersonId;
            ability.MDate = DateTime.Now;

            _personAppDbContext.Abilities.Update(ability);
            return _personAppDbContext.SaveChanges();
        }
    }
}
