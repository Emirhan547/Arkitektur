using Arkitektur.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Validators
{
    public class TeamValidator:AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x=>x.NameSurname).NotEmpty().WithMessage("Ad Soyad Boş Olamaz");
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Unvan Boş Olamaz");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Resim Boş Olamaz");

        }
    }
}
