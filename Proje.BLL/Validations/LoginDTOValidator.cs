using FluentValidation;
using Proje.BLL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Validations
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı girmelisiniz!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez!").MinimumLength(8).WithMessage("Şifre en az 8 karakterden oluşmalıdır!").Matches(@"[A-Z]+").WithMessage("Şifre en az 1 büyük harf içermelidir!").Matches(@"[a-z]+").WithMessage("Şifre en az 1 küçük harf içermelidir!");
        }
    }
}
