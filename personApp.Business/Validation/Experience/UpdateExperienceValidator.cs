using FluentValidation;
using personApp.DAL.DTO.Experience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Validation.Experience
{
    public class UpdateExperienceValidator : AbstractValidator<UpdateExperienceDto>
    {
        public UpdateExperienceValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty().WithMessage("Lütfen Çalıştığınız Şirketin İsmini Giriniz");
            RuleFor(p => p.Departman).NotEmpty().WithMessage("Lütfen Departman Bilgisini Giriniz");
            RuleFor(p => p.WorkDetail).NotEmpty().WithMessage("Lütfen Yaptığınız İş İle İlgili Bilgi Veriniz");
            RuleFor(p => p.StartDateOfWork).NotEmpty().WithMessage("Lütfen Başlangıç Tarihini Seçiniz.");
            RuleFor(p => p.WorkPosition).NotEmpty().WithMessage("Lütfen Pozisyon Bilgisini Giriniz");
            RuleFor(p => p.EndDateOfWork).NotEmpty().WithMessage("Lütfen Bitiş Tarihini Seçiniz.");
        }
    }
}
