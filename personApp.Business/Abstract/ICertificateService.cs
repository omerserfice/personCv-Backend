using personApp.DAL.DTO.Certificate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract
{
    public interface ICertificateService
    {
        public List<GetCertificateListDto> GetCertificateList();
        public int AddCertificate(AddCertificateDto addCertificateDto);
        public GetCertificateDto GetCertificateById(int certificateId);
        public int UpdateCertificate(int id, UpdateCertificateDto updateCertificateDto);
        public int DeleteCertificate(int id);
    }
}
