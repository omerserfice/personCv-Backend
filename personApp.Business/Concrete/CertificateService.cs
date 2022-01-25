using Microsoft.EntityFrameworkCore;
using personApp.Business.Abstract;
using personApp.DAL.Context;
using personApp.DAL.DTO.Certificate;
using personApp.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Concrete
{
    public class CertificateService : ICertificateService
    {
        private readonly personAppDbContext _personAppDbContext;

        public CertificateService(personAppDbContext personAppDbContext)
        {
            _personAppDbContext = personAppDbContext;
        }

        public int AddCertificate(AddCertificateDto addCertificateDto)
        {
            var newCertificate = new Certificates
            {
                CertificateName = addCertificateDto.CertificateName,
                CertificateDetail = addCertificateDto.CertificateDetail,
                CertificateImage  = addCertificateDto.CertificateImage, 
                Organisation = addCertificateDto.Organisation,
                DateOfIssue = addCertificateDto.DateOfIssue,    
                PersonId = addCertificateDto.PersonId,
            };
            _personAppDbContext.Certificates.Add(newCertificate);  
            return _personAppDbContext.SaveChanges();
        }

        public int DeleteCertificate(int id)
        {
            var currentCertificate = _personAppDbContext.Certificates.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (currentCertificate == null)
            {
                return -1;
            }
            currentCertificate.IsDeleted = true;
            _personAppDbContext.Certificates.Update(currentCertificate);
            return _personAppDbContext.SaveChanges();   
        }

        public GetCertificateDto GetCertificateById(int certificateId)
        {
            var currentCertificate = _personAppDbContext.Certificates.Where(p=>!p.IsDeleted && p.Id == certificateId).Include(p=>p.PersonFK)
                .Select(p=>new GetCertificateDto
                {
                    Id= p.Id,
                    CertificateName = p.CertificateName,
                    CertificateDetail = p.CertificateDetail,
                    CertificateImage = p.CertificateImage,
                    Organisation =  p.Organisation,
                    DateOfIssue = p.DateOfIssue,
                    PersonName = p.PersonFK.PersonName,
                    PersonSurname = p.PersonFK.PersonSurname

                }).FirstOrDefault();
            return currentCertificate;
        }

        public List<GetCertificateListDto> GetCertificateList()
        {
            return _personAppDbContext.Certificates.Where(p => !p.IsDeleted).Include(p => p.PersonFK)
                .Select(p => new GetCertificateListDto
                {
                    Id = p.Id,
                    CertificateName = p.CertificateName,
                    CertificateDetail = p.CertificateDetail,
                    CertificateImage = p.CertificateImage,
                    Organisation = p.Organisation,
                    DateOfIssue = p.DateOfIssue,
                    PersonName = p.PersonFK.PersonName,
                    PersonSurname = p.PersonFK.PersonSurname
                }).ToList();
        }

        public int UpdateCertificate(int id, UpdateCertificateDto updateCertificateDto)
        {
            var currentCertificate = _personAppDbContext.Certificates.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (currentCertificate == null)
            {
                return -1;
            }
            currentCertificate.CertificateName = updateCertificateDto.CertificateName;
            currentCertificate.CertificateDetail = updateCertificateDto.CertificateDetail;
            currentCertificate.CertificateImage = updateCertificateDto.CertificateImage;    
            currentCertificate.DateOfIssue = updateCertificateDto.DateOfIssue;  
            currentCertificate.Organisation = updateCertificateDto.Organisation;
            currentCertificate.PersonId = updateCertificateDto.PersonId;
            currentCertificate.MDate = DateTime.Now;

            _personAppDbContext.Certificates.Update(currentCertificate);
            return _personAppDbContext.SaveChanges();

        }
    }
}
