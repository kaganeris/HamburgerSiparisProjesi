using FluentValidation;
using Proje.BLL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Validations
{
    public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserDTOValidator()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage("İsim boş geçilemez!");
            RuleFor(x => x.Soyad).NotEmpty().WithMessage("Soyad boş geçilemez!");
            RuleFor(x => x.Cinsiyet).NotNull().WithMessage("Cinsiyet boş geçilemez!");
            RuleFor(x => x.DogumTarihi).NotNull().WithMessage("Doğum tarihi boş geçilemez!");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası boş geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir e-mail adresi giriniz");
        }
    }
}
