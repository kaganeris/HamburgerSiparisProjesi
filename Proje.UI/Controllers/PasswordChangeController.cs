using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Proje.BLL.Models.DTOs;
using Proje.BLL.Models.VMs;
using Proje.BLL.Validations;
using Proje.DATA.Entities;

namespace Proje.UI.Controllers
{
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPasswordVM)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(forgetPasswordVM.Mail);
                if (user == null)
                {
                    ViewBag.Uyarı = "Kayıtlı E-mail bulunamadı!";
                    return View();
                }
                string passwordResetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
                {
                    userId = user.Id,
                    token = passwordResetToken
                }, HttpContext.Request.Scheme);

                SendEmail(forgetPasswordVM.Mail, passwordResetTokenLink);
                ViewBag.Tamamlandı = "Şifre yenileme bağlantısı başarıyla iletildi!";
                return View();
            }
            ViewBag.Uyarı = "Kayıtlı E-mail bulunamadı!";
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userID,string token)
        {
            TempData["userID"] = userID;
            TempData["token"] = token;
            return View();
        }

        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            var userID = TempData["userID"];
            var token = TempData["token"];

            if(userID == null || token == null)
            {
                ViewBag.Uyarı = "Hata!";
                return View();
            }

            ResetPasswordVMValidator validator = new ResetPasswordVMValidator();
            var valid = validator.Validate(resetPasswordVM);
            if(valid.IsValid)
            {
                var user = await userManager.FindByIdAsync(userID.ToString());

                var result = await userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordVM.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "User");
                }
            }
            foreach (var item in valid.Errors)
            {
                ModelState.AddModelError("Hata", item.ErrorMessage);
            }
            return View();
        }

        public void SendEmail(string email, string passwordResetTokenLink)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HamburgerProjesi Admin", "projemaka@gmail.com");
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", email);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"<div>Şifrenizi yenilemek için <a href=""{passwordResetTokenLink}"">buraya tıklayınız.</a></div>";
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Şifre Değişiklik Talebi Hk.";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("projemaka@gmail.com", "wvgdopwbgegdlgcl");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}
