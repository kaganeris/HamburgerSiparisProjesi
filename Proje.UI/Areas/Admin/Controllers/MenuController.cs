using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.DTOs.MenuDTOs;
using Proje.BLL.Services.Abstract;
using Proje.BLL.Validations.MenuValidate;
using Proje.DATA.Entities;

namespace Proje.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MenuController : Controller
    {
        private readonly BLL.Services.Abstract.IMenuService _service;
        private readonly IMapper _mapper;

        public MenuController(IMenuService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_service.GetWhereAll(x => x.AktifMi == true));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateMenuDTO createMenu)
        {
            CreateMenuDTOValidator validator = new();
            var valid=validator.Validate(createMenu);
            if(valid.IsValid)
            {

                Menu menu = _mapper.Map<Menu>(createMenu);
                _service.Add(menu);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError("MenuHata", item.ErrorMessage);

                }
                return  View();
            }

        }

        public IActionResult Edit(int id)
        {
            UpdateMenuDTO updateMenuDTO=_mapper.Map<UpdateMenuDTO>(_service.GetById(id));
            return View(updateMenuDTO);
        }

        [HttpPost]
        public IActionResult Edit(UpdateMenuDTO updatedMenuDto)
        {
            CreateMenuDTOValidator validator = new();
            var valid = validator.Validate(updatedMenuDto);
            if (valid.IsValid)
            {
                Menu updatedMenu = _service.GetById(updatedMenuDto.ID);
                updatedMenu = _mapper.Map(updatedMenuDto, updatedMenu);
                _service.Update(updatedMenu);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in valid.Errors)
                {
                    ModelState.AddModelError("MenuHata", item.ErrorMessage);
                }
                return View();
            }

           
        }
        public IActionResult Delete(int id)
        {
            return View(_service.GetById(id));
        }
        [HttpPost]
        public IActionResult Delete(Menu menu)
        {
            _service.DeleteById(menu.ID);
            return RedirectToAction("Index");
        }
    }
}
