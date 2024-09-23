using FluentValidation;
using SignalRDtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.ValidationRules.BookingValidation
{
    public class CreateBookingValidation:AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x=>x.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilemez!");
            RuleFor(x=>x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x=>x.PersonCount).NotEmpty().WithMessage("Kişi sayısı boş geçilemez!");
            RuleFor(x=>x.Date).NotEmpty().WithMessage("Lütfen tarihi seçiniz!");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Minimum 3 karakter olmalı!").MaximumLength(50).WithMessage("Maximum 50 karakter olmalı!");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Maximum 500 karakter olmalı!");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");

         

        }
    }
}
