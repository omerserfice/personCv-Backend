using FluentValidation;
using personApp.DAL.DTO.Ability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Validation.Ability
{
    public class UpdateAbilityValidator : AbstractValidator<UpdateAbilityDto>
    {
        public UpdateAbilityValidator()
        {
            RuleFor(p => p.AbilityName).NotEmpty().WithMessage("Lütfen Yetenek Bilgisini Giriniz");
            RuleFor(p => p.AbilityPoint).NotEmpty().WithMessage("Lütfen Yetenek Derecesini Girin (0-100 arası)");
            RuleFor(p => p.PersonId).NotEmpty().WithMessage("Lütfen yeteneğe Ait Olan Kişiyi Seçiniz");
            RuleFor(p => p.AbilityName).MinimumLength(5).WithMessage("Yetenek Adı 5 Karakterden Az Olamaz");
        }
    }
}
