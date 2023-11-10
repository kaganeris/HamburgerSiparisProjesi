using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.DTOs;
using Proje.BLL.Validations;
using Proje.DATA.Entities;
using System.Security.Claims;

namespace Proje.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public ProfileController(UserManager<AppUser> userManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Settings()
        {
            var userIDClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            string userID = userIDClaim.Value;
            UpdateUserDTO updateUserDTO = new UpdateUserDTO();
            AppUser appUser = await userManager.FindByIdAsync(userID);
            updateUserDTO = mapper.Map(appUser, updateUserDTO);

            return View(updateUserDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(UpdateUserDTO updateUserDTO)
        {
            UpdateUserDTOValidator validationRules = new UpdateUserDTOValidator();
            var valid = validationRules.Validate(updateUserDTO);
            if (valid.IsValid)
            {
                AppUser appUser = await userManager.FindByIdAsync(updateUserDTO.UserId);
                appUser = mapper.Map(updateUserDTO, appUser);
                var result = await userManager.UpdateAsync(appUser);
                if(result.Succeeded)
                {
                    return RedirectToAction("Settings");
                }
            }
            foreach (var item in valid.Errors)
            {
                ModelState.AddModelError("Hata", item.ErrorMessage);
            }
            return View();
        }
    }
}
