using Arkitektur.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Validators
{
    public class TestimonialValidator:AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(x=>x.NameSurname).NotEmpty().WithMessage("Ad Soyad boş bırakılamaz")
                .MaximumLength(100).WithMessage("Ad Soyad 100 karakteri geçemez");

            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum boş bırakılamaz");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Unvan boş bırakılamaz")
               .MaximumLength(150).WithMessage("Unvan 150 karakteri geçemez");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Url'si boş bırakılamaz");

        }
    }
}
