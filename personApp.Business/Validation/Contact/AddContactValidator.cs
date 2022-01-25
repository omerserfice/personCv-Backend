using FluentValidation;
using personApp.DAL.DTO.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Validation.Contact
{
    public class AddContactValidator : AbstractValidator<AddContactDto>
    {
        public AddContactValidator()
        {
            RuleFor(p => p.Address).NotEmpty().WithMessage("Lütfen Adres Giriniz");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("Lütfen Telefon Numaranızı Giriniz").MaximumLength(11).WithMessage("Telefon No En Fazla 11 Karakter Olmalıdır.");
            RuleFor(p => p.EMail).NotEmpty().WithMessage("Lütfen Email Giriniz");
            
        }
    }
}
