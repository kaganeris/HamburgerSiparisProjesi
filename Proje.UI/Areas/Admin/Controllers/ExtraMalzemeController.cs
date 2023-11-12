using AutoMapper;
using MessagePack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.DTOs.ExtraMalzemeDTO;
using Proje.BLL.Services.Abstract;
using Proje.BLL.Validations.ExtraMalzeme;
using Proje.DAL.Context;
using Proje.DATA.Entities;

namespace Proje.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExtraMalzemeController : Controller
    {
        private readonly IBaseService<ExtraMalzeme> _service;
        private readonly IMapper _mapper;

        public ExtraMalzemeController(IBaseService<ExtraMalzeme> service, IMapper mapper)
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
        public IActionResult Create(CreateExtraMalzemeDTO createExtraMalzeme)
        {
            CreateExtraMalzemeDTOValidator validator = new();
            var valid = validator.Validate(createExtraMalzeme);
            if (valid.IsValid)
            {
                ExtraMalzeme extraMalzeme = _mapper.Map<ExtraMalzeme>(createExtraMalzeme);
                _service.Add(extraMalzeme);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError("ExtraMalzemeHata", item.ErrorMessage);
                }
                return View();
            }

        }
        public IActionResult Edit(int id)
        {
            UpdateExtraMalzemeDTO updateExtraMalzemeDTO = _mapper.Map<UpdateExtraMalzemeDTO>(_service.GetById(id));
            return View(updateExtraMalzemeDTO);
        }

        [HttpPost]
        public IActionResult Edit(UpdateExtraMalzemeDTO updateExtraMalzemeDTO)
        {
            CreateExtraMalzemeDTOValidator validator = new();
            var valid = validator.Validate(updateExtraMalzemeDTO);
            if (valid.IsValid)
            {
                ExtraMalzeme extraMalzeme = _service.GetById(updateExtraMalzemeDTO.ID);
                extraMalzeme = _mapper.Map(updateExtraMalzemeDTO, extraMalzeme);
                _service.Update(extraMalzeme);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError("ExtraMalzemeHata", item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            _service.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
