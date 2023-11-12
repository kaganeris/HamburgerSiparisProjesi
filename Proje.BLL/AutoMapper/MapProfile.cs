using AutoMapper;
using Proje.BLL.Models.DTOs.ExtraMalzemeDTO;
using Proje.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateExtraMalzemeDTO, ExtraMalzeme>().ReverseMap();
            CreateMap<UpdateExtraMalzemeDTO, ExtraMalzeme>().ReverseMap();
        }
    }
}
