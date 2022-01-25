using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.Certificate
{
    public class GetCertificateListDto
    {
        public int Id { get; set; }
        public string CertificateName { get; set; }
        public string CertificateDetail { get; set; }
        public string CertificateImage { get; set; }
        public string Organisation { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
    }
}
