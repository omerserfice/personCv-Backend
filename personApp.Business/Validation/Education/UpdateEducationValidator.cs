using FluentValidation;
using personApp.DAL.DTO.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Validation.Education
{
    public class UpdateEducationValidator : AbstractValidator<UpdateEducationDto>
    {
        public UpdateEducationValidator()
        {
            RuleFor(p => p.SchoolName).NotEmpty().WithMessage("Okul Adı Boş Geçilemez");
            RuleFor(p => p.Departmen).NotEmpty().WithMessage("Departman Alanı Boş Geçilemez");
            RuleFor(p => p.EducationDetail).NotEmpty().WithMessage("Detay Alanı Boş Geçilemez")
               .MinimumLength(100).WithMessage("Detay Alanı 100 Karakterden Az Olamaz.");
            RuleFor(p => p.StartTime).NotEmpty().WithMessage("Başlangıç Zamanı Boş Geçilemez");
            RuleFor(p => p.EndTime).NotEmpty().WithMessage("Bitiş Zamanı Boş Geçilemez");
            RuleFor(p => p.Status).NotEmpty().WithMessage("Lütfen Mezuniyet Bilgisini Boş Geçmeyiniz");
        }
    }
}
