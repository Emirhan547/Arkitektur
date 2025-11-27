using Arkitektur.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Validators
{
    public class ProjectValidator:AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Resim boş geçilemez");
            RuleFor(x=>x.Item1).NotEmpty().WithMessage("Madde1 boş geçilemez");
            RuleFor(x=>x.Item2).NotEmpty().WithMessage("Madde2 boş geçilemez");
            RuleFor(x=>x.Item3).NotEmpty().WithMessage("Madde3 boş geçilemez");
            RuleFor(x=>x.CategoryId).NotEmpty().WithMessage("Kategori boş geçilemez");
        }
    }
}
