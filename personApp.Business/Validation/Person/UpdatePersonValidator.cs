using FluentValidation;
using personApp.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Validation.Person
{
    public class UpdatePersonValidator : AbstractValidator<UpdatePersonDto>
    {
        public UpdatePersonValidator()
        {
            RuleFor(p => p.PersonName).NotEmpty().WithMessage("Kişi adı boş geçilemez").MaximumLength(100)
           .WithMessage("Kişi adı 100 karakterden fazla olamaz");
            RuleFor(p => p.PersonSurname).NotEmpty().WithMessage("Kişi Soyadı boş geçilemez").MaximumLength(100)
            .WithMessage("Kişi Soyadı 100 karakterden fazla olamaz");
            RuleFor(p => p.PersonCity).NotEmpty().WithMessage("Şehir bilgisi boş geçielemez");
            RuleFor(p => p.PersonBirthDay).NotEmpty().WithMessage("Doğum Tarihi boş geçilemez");
        }
    }
}
