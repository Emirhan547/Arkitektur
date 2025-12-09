using Arkitektur.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Validators
{
    public class TeamSocialValidator:AbstractValidator<TeamSocial>
    {
        public TeamSocialValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz.");

            RuleFor(x => x.Icon).NotEmpty().WithMessage("İkon boş olamaz.");

            RuleFor(x => x.Url).NotEmpty().WithMessage("Başlık boş olamaz.");

        }
    }
}
