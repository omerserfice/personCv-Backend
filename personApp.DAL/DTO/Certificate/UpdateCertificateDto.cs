using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.DTO.Certificate
{
    public class UpdateCertificateDto
    {
        public string CertificateName { get; set; }
        public string CertificateDetail { get; set; }
        public string CertificateImage { get; set; }
        public string Organisation { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int PersonId { get; set; }
    }
}
