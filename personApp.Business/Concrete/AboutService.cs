using Microsoft.EntityFrameworkCore;
using personApp.Business.Abstract;
using personApp.DAL.Context;
using personApp.DAL.DTO.About;
using personApp.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly personAppDbContext _personAppDbContext;

        public AboutService(personAppDbContext personAppDbContext)
        {
            _personAppDbContext = personAppDbContext;
        }

        public int AddAbout(AddAboutDto addAboutDto)
        {
            var newAbout = new About
            {
                AboutTitle = addAboutDto.AboutTitle,
                AboutDetail = addAboutDto.AboutDetail,
                AboutImage = addAboutDto.AboutImage,
                PersonId = addAboutDto.PersonId
            };
            _personAppDbContext.Add(newAbout);
            return _personAppDbContext.SaveChanges();

        }

        public int DeleteAbout(int id)
        {
            var currentAbout = _personAppDbContext.Abouts.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (currentAbout == null)
            {
                return -1;
            }
            currentAbout.IsDeleted = true;
            _personAppDbContext.Abouts.Update(currentAbout);
            return _personAppDbContext.SaveChanges();
        }

        public GetAboutDto GetAboutById(int aboutId)
        {
            var currentAbout = _personAppDbContext.Abouts.Where(p => !p.IsDeleted && p.Id == aboutId).Include(p => p.PersonFK)
                .Select(p => new GetAboutDto
                {
                    Id = p.Id,
                    AboutTitle = p.AboutTitle,
                    AboutDetail = p.AboutDetail,
                    AboutImage = p.AboutImage,
                    PersonName = p.PersonFK.PersonName,
                    PersonSurname = p.PersonFK.PersonSurname
                }).FirstOrDefault();
            return currentAbout;
        }

        public List<GetAboutListDto> GetAboutList()
        {
            return _personAppDbContext.Abouts.Where(p => !p.IsDeleted).Include(p => p.PersonFK)
                 .Select(p => new GetAboutListDto
                 {
                     Id = p.Id, 
                     AboutTitle = p.AboutTitle,
                     AboutDetail = p.AboutDetail,
                     AboutImage = p.AboutImage, 
                     PersonName = p.PersonFK.PersonName,
                     PersonSurname = p.PersonFK.PersonSurname
                 }).ToList();
        }

        public int UpdateAbout(int id, UpdateAboutDto updateAboutDto)
        {
            var currentAbout = _personAppDbContext.Abouts.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (currentAbout == null)
            {
                return -1;
            }
            currentAbout.AboutTitle = updateAboutDto.AboutTitle;
            currentAbout.AboutDetail = updateAboutDto.AboutDetail;
            currentAbout.AboutImage = updateAboutDto.AboutImage;
            currentAbout.PersonId = updateAboutDto.PersonId;
            currentAbout.MDate = DateTime.Now;

            _personAppDbContext.Abouts.Update(currentAbout);
            return _personAppDbContext.SaveChanges();

        }
    }
}
