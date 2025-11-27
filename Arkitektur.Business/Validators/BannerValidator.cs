using Arkitektur.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Validators
{
    public class BannerValidator:AbstractValidator<Banner>
    {
        public BannerValidator()
        {
            RuleFor(b => b.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz.");

            RuleFor(b => b.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");

            RuleFor(b => b.ImageUrl).NotEmpty().WithMessage("Resim URL boş bırakılamaz.");
                                     
        }
    }
}
