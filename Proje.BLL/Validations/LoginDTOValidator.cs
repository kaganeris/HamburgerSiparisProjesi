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
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez!");
        }
    }
}
