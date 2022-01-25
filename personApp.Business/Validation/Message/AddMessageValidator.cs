using FluentValidation;
using personApp.DAL.DTO.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Validation.Message
{
    public class AddMessageValidator : AbstractValidator<AddMessageDto>
    {
        public AddMessageValidator()
        {
            RuleFor(p=>p.Name).NotEmpty().WithMessage("Lütfen Adınızı Giriniz");
            RuleFor(p=>p.Surname).NotEmpty().WithMessage("Lütfen Soyadınızı Giriniz");
            RuleFor(p => p.Mail).NotEmpty().WithMessage("Lütfen Mail Adresinizi Giriniz");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("Lütfen Telefon Numaranızı Giriniz");
            RuleFor(p => p.Subject).NotEmpty().WithMessage("Lütfen İletmek İstediğiniz Konu Başlığını Giriniz");
            RuleFor(p => p.MessageDetail).NotEmpty().WithMessage("Lütfen Mesajınızı Giriniz");


        }
    }
}
