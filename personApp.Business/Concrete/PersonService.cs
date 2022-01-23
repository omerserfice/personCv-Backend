using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;
using personApp.Business.Abstract;
using personApp.DAL.Context;
using personApp.DAL.DTO;
using personApp.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Concrete
{
    public class PersonService : IPersonService
    {

        private readonly personAppDbContext _personAppDbContext;

        public PersonService(personAppDbContext personAppDbContext)
        {
            _personAppDbContext = personAppDbContext;
        }

        public List<GetPersonListDto> GetPersonList()
        {
            return _personAppDbContext.Persons.Where(p => !p.IsDeleted)
                .Select(p => new GetPersonListDto
                {
                    Id = p.Id, 
                    PersonName = p.PersonName,
                    PersonSurname = p.PersonSurname,
                    PersonCity = p.PersonCity,
                    PersonBirthDay = p.PersonBirthDay
                }
                ).ToList();
        }

        public int AddPerson(AddPersonDto addPersonDto)
        {
            var newPerson = new Person
            {
                PersonName = addPersonDto.PersonName,
                PersonSurname = addPersonDto.PersonSurname,
                PersonCity = addPersonDto.PersonCity,
                PersonBirthDay = addPersonDto.PersonBirthDay,
            };
            _personAppDbContext.Persons.Add(newPerson);
            return _personAppDbContext.SaveChanges();  
        }

        public int DeletePerson(int personId)
        {
            var person = _personAppDbContext.Persons.Where(p => !p.IsDeleted && p.Id == personId).FirstOrDefault();
            if (person == null)
            {
                return -1;
            }
            person.IsDeleted = true;
            _personAppDbContext.Update(person);
            return _personAppDbContext.SaveChanges();
        }

        public GetPersonDto GetPersonById(int personId)
        {
            return _personAppDbContext.Persons.Where(p => !p.IsDeleted && p.Id == personId)
                .Select(p => new GetPersonDto
                {
                    Id = p.Id,
                    PersonName = p.PersonName,
                    PersonSurname = p.PersonSurname,
                    PersonCity = p.PersonCity,
                    PersonBirthDay= p.PersonBirthDay,   


                }).FirstOrDefault();
        }

       

        public int UpdatePerson(int id,UpdatePersonDto updatePersonDto)
        {
            var person = _personAppDbContext.Persons.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (person == null )
            {
                return -1;
            }
            person.PersonName = updatePersonDto.PersonName;
            person.PersonSurname = updatePersonDto.PersonSurname;
            person.PersonCity = updatePersonDto.PersonCity;
            person.PersonBirthDay = updatePersonDto.PersonBirthDay;
            _personAppDbContext.Persons.Update(person);

            return _personAppDbContext.SaveChanges();
        }
    }
}
