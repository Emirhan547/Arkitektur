using Arkitektur.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Validators
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
              RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez.");
              RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez.");
              RuleFor(x => x.StartYear).NotEmpty().WithMessage("Sektöre Giriş Yılı boş geçilemez.");
              RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel boş geçilemez.");
              
        }
    }
}
