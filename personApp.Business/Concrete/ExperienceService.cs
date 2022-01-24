using Microsoft.EntityFrameworkCore;
using personApp.Business.Abstract;
using personApp.DAL.Context;
using personApp.DAL.DTO.Experience;
using personApp.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Concrete
{
    public class ExperienceService : IExperienceService
    {
        private readonly personAppDbContext _personAppDbContext;

        public ExperienceService(personAppDbContext personAppDbContext)
        {
            _personAppDbContext = personAppDbContext;
        }

        public int AddExperience(AddExperienceDto addExperienceDto)
        {
            var newExperience = new Experience
            {
                CompanyName = addExperienceDto.CompanyName, 
                Departman = addExperienceDto.Departman, 
                WorkDetail = addExperienceDto.WorkDetail,
                WorkPosition = addExperienceDto.WorkPosition,   
                StartDateOfWork = addExperienceDto.StartDateOfWork,
                EndDateOfWork = addExperienceDto.EndDateOfWork,
                Status = addExperienceDto.Status,   
                PersonId =  addExperienceDto.PersonId,

            };
            _personAppDbContext.Add(newExperience);
            return _personAppDbContext.SaveChanges();  
        }

        public int DeleteExperience(int id)
        {
            var currentExperience = _personAppDbContext.Experiences.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (currentExperience == null)
            {
                return -1;
            }
            currentExperience.IsDeleted = true;
            _personAppDbContext.Experiences.Update(currentExperience);
            return _personAppDbContext.SaveChanges();
        }

        public GetExperienceDto GetExperienceById(int experienceId)
        {
           
           var currentExperience = _personAppDbContext.Experiences.Where(p=>!p.IsDeleted && p.Id == experienceId).Include(p=>p.PersonFK)
            .Select(p=>new GetExperienceDto
            {
                Id = p.Id,
                CompanyName = p.CompanyName,
                WorkPosition = p.WorkPosition,
                WorkDetail = p.WorkDetail,
                Departman = p.Departman,
                StartDateOfWork = p.StartDateOfWork,
                EndDateOfWork = p.EndDateOfWork,
                Status = p.Status,
                PersonName = p.PersonFK.PersonName,
                PersonSurname = p.PersonFK.PersonSurname
            }).FirstOrDefault();

            return currentExperience;
        }

        public List<GetExperienceListDto> GetExperienceList()
        {
            return _personAppDbContext.Experiences.Where(p => !p.IsDeleted).Include(p => p.PersonFK)
                .Select(p => new GetExperienceListDto
                {
                    Id = p.Id,
                    CompanyName = p.CompanyName,
                    WorkPosition = p.WorkPosition,
                    WorkDetail = p.WorkDetail,  
                    Departman = p.Departman,
                    StartDateOfWork = p.StartDateOfWork,    
                    EndDateOfWork = p.EndDateOfWork,
                    Status = p.Status,
                    PersonName = p.PersonFK.PersonName,
                    PersonSurname = p.PersonFK.PersonSurname

                }).ToList();
        }

        public int UpdateExperience(int id, UpdateExperienceDto updateExperienceDto)
        {
            var currentExperience = _personAppDbContext.Experiences.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (currentExperience == null)
            {
                return -1;
            }
            currentExperience.CompanyName = updateExperienceDto.CompanyName;
            currentExperience.Departman = updateExperienceDto.Departman;    
            currentExperience.WorkDetail = updateExperienceDto.WorkDetail;  
            currentExperience.WorkPosition = updateExperienceDto.WorkPosition;
            currentExperience.StartDateOfWork = updateExperienceDto.StartDateOfWork;    
            currentExperience.EndDateOfWork = updateExperienceDto.EndDateOfWork;
            currentExperience.MDate = DateTime.Now;
            currentExperience.PersonId = updateExperienceDto.PersonId;

            _personAppDbContext.Experiences.Update(currentExperience);
            return _personAppDbContext.SaveChanges();
        }
    }
}
