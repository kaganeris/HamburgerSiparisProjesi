using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.DTOs.MenuDTOs;
using Proje.BLL.Services.Abstract;
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
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateMenuDTO createMenu)
        {
            Menu menu=_mapper.Map<Menu>(createMenu);
            _service.Add(menu);
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdateMenuDTO updatedMenuDto)
        {
            Menu updatedMenu = _service.GetById(updatedMenuDto.ID);
            updatedMenu = _mapper.Map(updatedMenuDto, updatedMenu);
            _service.Update(updatedMenu);
            return View();
        }
        public IActionResult Delete(int id)
        {
            return View(_service.GetById(id));
        }
        [HttpPost]
        public IActionResult Delete(Menu menu)
        {
            _service.Delete(menu);
            return RedirectToAction("Index");
        }
    }
}
