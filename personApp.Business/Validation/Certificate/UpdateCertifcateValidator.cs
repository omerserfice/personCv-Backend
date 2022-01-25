using FluentValidation;
using personApp.DAL.DTO.Certificate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Validation.Certificate
{
    public class UpdateCertifcateValidator : AbstractValidator<UpdateCertificateDto>
    {
        public UpdateCertifcateValidator()
        {
            RuleFor(p => p.CertificateName).NotEmpty().WithMessage("Lütfen Sertifika Adını Giriniz")
                .MinimumLength(10).WithMessage("En Az 10 Karakter Giriniz");
            RuleFor(p => p.CertificateImage).NotEmpty().WithMessage("Lütfen Resim Ekleyiniz");
            RuleFor(p => p.Organisation).NotEmpty().WithMessage("Lütfen Sertifika Aldığınız Kurum Bilgisini Giriniz");
            RuleFor(p => p.CertificateDetail).NotEmpty().WithMessage("Lütfen Sertifkayla İlgili Detaylı Bilgi Veriniz");
            RuleFor(p => p.DateOfIssue).NotEmpty().WithMessage("Lütfen Veriliş Tarhini Giriniz");
        }
    }
}
