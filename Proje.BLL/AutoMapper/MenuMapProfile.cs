using AutoMapper;
using Proje.BLL.Models.DTOs.MenuDTOs;
using Proje.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.AutoMapper
{
    public class MenuMapProfile:Profile
    {
        public MenuMapProfile()
        {
            CreateMap<CreateMenuDTO,Menu>().ReverseMap();
            CreateMap<UpdateMenuDTO,Menu>().ReverseMap();
        }
    }
}
