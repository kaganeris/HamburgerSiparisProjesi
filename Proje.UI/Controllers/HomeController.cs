using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Proje.BLL.Models.DTOs;
using Proje.BLL.Validations;
using Proje.DATA.Entities;
using Proje.UI.Models;
using System.Diagnostics;

namespace Proje.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactUsDTO contactUsDTO)
        {
            ContactUsDTOValidator validator = new();
            var valid = validator.Validate(contactUsDTO);
            if (valid.IsValid)
            {
                SendEmail(contactUsDTO);
                return RedirectToAction("Index","Home");
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError("ContactUsHata", item.ErrorMessage);
                }
                return View();
            }
        }

        public void SendEmail(ContactUsDTO contactUsDTO)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HamburgerProjesi Admin", "projemaka@gmail.com"); // Mailin kimden gideceği!
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", "burgermaka4@gmail.com");

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"<ul>
	<li>
	<h3><span style=""font-family:Georgia,serif""><strong>Adı: &nbsp;</strong>{contactUsDTO.Name}</span></h3>
	</li>
	<li>
	<h3><span style=""font-family:Georgia,serif""><strong>Email: </strong>{contactUsDTO.Email}</span></h3>
	</li>
	<li>
	<h3><span style=""font-family:Georgia,serif""><strong>Konu: </strong>{contactUsDTO.Subject}</span></h3>
	</li>
	<li>
	<h3><span style=""font-family:Georgia,serif""><strong>Mesaj: </strong>{contactUsDTO.Message}</span></h3>
	</li>
</ul>";
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = contactUsDTO.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("projemaka@gmail.com", "wvgdopwbgegdlgcl");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}