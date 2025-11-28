using Arkitektur.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Validators
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.Address).NotEmpty().WithMessage("Adress boş bırakılamaz.");
            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Telefon boş bırakılamaz.");
            RuleFor(c => c.MapUrl).NotEmpty().WithMessage("Harita boş bırakılamaz.");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email boş bırakılamaz.")
                .EmailAddress().WithMessage("Email Formatı Geçersiz");
        }
    }
}
  