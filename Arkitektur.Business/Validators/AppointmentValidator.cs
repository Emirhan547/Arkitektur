using Arkitektur.Business.DTOs.AppointmentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Validators
{
    public class AppointmentValidator:AbstractValidator<CreateAppointmentDto>
    {
        public AppointmentValidator()
        {
           
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email boş bırakılamaz")
                .EmailAddress().WithMessage("Geçerli bir email giriniz.");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.");

            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Ad Soyad en az 3 karakterli olmalıdır.");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Mesaj en fazla 500 karakterli olmalıdır");

            RuleFor(x => x.ServiceName).NotEmpty().WithMessage("Servis türü boş bırakılamaz.");

            RuleFor(x => x.AppointmentDate).GreaterThan(DateTime.Now).WithMessage("Tarih boş bırakılamaz.");
        }
    }
}
