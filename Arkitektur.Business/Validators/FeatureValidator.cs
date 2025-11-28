using Arkitektur.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Validators
{
    public class FeatureValidator:AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
            RuleFor(x=>x.BackgroundImage).NotEmpty().WithMessage("Arkaplan boş bırakılamaz.");
            RuleFor(x=>x.Icon).NotEmpty().WithMessage("İkon boş bırakılamaz.");
        }
    }
}
