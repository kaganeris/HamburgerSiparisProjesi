using AutoMapper;
using Proje.BLL.Models.DTOs;
using Proje.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, AppUser>();
            CreateMap<UpdateUserDTO, AppUser>().ReverseMap().ForMember(x => x.UserId, opt => opt.MapFrom(x => x.Id));
        }
    }
}
