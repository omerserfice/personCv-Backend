using FluentValidation;
using personApp.DAL.DTO.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Validation.Project
{
    public class AddProjectValidator : AbstractValidator<AddProjectDto>
    {
        public AddProjectValidator()
        {
            RuleFor(p => p.ProjectName).NotEmpty().WithMessage("Lütfen Projenizin Adını Giriniz");
            RuleFor(p => p.ProjectDetail).NotEmpty().WithMessage("Lütfen Projenizin Detaylarını Açıklayınız");
            RuleFor(p => p.ProjectImage).NotEmpty().WithMessage("Lütfen Projenize Ait Bir Resim Ekleyiniz");
        }
    }
}
