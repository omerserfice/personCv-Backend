using Microsoft.EntityFrameworkCore;
using personApp.Business.Abstract;
using personApp.DAL.Context;
using personApp.DAL.DTO.Education;
using personApp.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Concrete
{
    public class EducationService : IEducationService
    {
        private readonly personAppDbContext _personAppDbContext;

        public EducationService(personAppDbContext personAppDbContext)
        {
            _personAppDbContext = personAppDbContext;
        }

        public int AddEducation(AddEducationDto addEducationDto)
        {
            var newEducation = new Education
                
                {
                    SchoolName = addEducationDto.SchoolName,
                    Departmen = addEducationDto.Departmen,
                    EducationDetail = addEducationDto.EducationDetail,
                    StartTime = addEducationDto.StartTime,
                    EndTime = addEducationDto.EndTime,
                    Status = addEducationDto.Status,
                    PersonId = addEducationDto.PersonId

                };
            _personAppDbContext.Educations.Add(newEducation);
            return _personAppDbContext.SaveChanges();
        }

        public int DeleteEducation(int id)
        {
            var education = _personAppDbContext.Educations.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (education == null)
            {
                return -1;
            }
            education.IsDeleted = true;
            _personAppDbContext.Educations.Update(education);
           return  _personAppDbContext.SaveChanges();  
        }

        public GetEducationDto GetEducationById(int personId)
        {
            var education = _personAppDbContext.Educations.Where(p => !p.IsDeleted && p.Id == personId).Include(p => p.PersonFK)
                .Select(p => new GetEducationDto
                {
                    Id = p.Id,
                    SchoolName = p.SchoolName,
                    Departmen = p.Departmen,
                    EducationDetail = p.EducationDetail,
                    StartTime = p.StartTime,
                    EndTime = p.EndTime,
                    Status = p.Status,
                    PersonName = p.PersonFK.PersonName,
                    PersonSurname = p.PersonFK.PersonSurname

                }).FirstOrDefault();
            return education;   
        }

        public List<GetEducationListDto> GetEducationList()
        {
            var educationList = _personAppDbContext.Educations.Where(p => !p.IsDeleted).Include(p => p.PersonFK)
                 .Select(p => new GetEducationListDto
                 {
                     Id = p.Id, 
                     SchoolName = p.SchoolName,
                     Departmen = p.Departmen,
                     EducationDetail = p.EducationDetail,
                     StartTime = p.StartTime,
                     EndTime= p.EndTime,
                     Status = p.Status,
                     PersonName = p.PersonFK.PersonName,
                     PersonSurname = p.PersonFK.PersonSurname

                 }).ToList();
            return educationList;   
        }

        public int UpdateEducation(int id,UpdateEducationDto updateEducationDto)
        {
            var educationList = _personAppDbContext.Educations.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (educationList == null)
            {
                return -1;
            }

            educationList.SchoolName = updateEducationDto.SchoolName;
            educationList.EducationDetail = updateEducationDto.EducationDetail;
            educationList.Departmen = updateEducationDto.Departmen; 
            educationList.StartTime = updateEducationDto.StartTime; 
            educationList.EndTime = updateEducationDto.EndTime; 
            educationList.Status = updateEducationDto.Status;
            educationList.PersonId = updateEducationDto.PersonId;
            educationList.MDate = DateTime.Now;
            _personAppDbContext.Educations.Update(educationList);
          return  _personAppDbContext.SaveChanges();
        }
    }
}
