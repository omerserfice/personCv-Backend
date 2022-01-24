using FluentValidation;
using personApp.DAL.DTO.About;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Validation.About
{
    public class UpdateAboutValidator : AbstractValidator<UpdateAboutDto>
    {
        public UpdateAboutValidator()
        {
            RuleFor(p => p.AboutTitle).NotEmpty().WithMessage("Lütfen Hakkımızda Başlık Girin");
            RuleFor(p => p.AboutDetail).MinimumLength(200).WithMessage("Detay Alanı 200 Karakterden Az Olamaz")
            .NotEmpty().WithMessage("Lütfen Detay Kısmını Doldurun");
            RuleFor(p => p.PersonId).NotEmpty().WithMessage("Lütfen Kişiyi Seçiniz");
            RuleFor(p => p.AboutImage).NotEmpty().WithMessage("Lütfen Resim Ekleyin");
        }
    }
}
