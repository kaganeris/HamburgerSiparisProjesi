using Proje.BLL.Services.Abstract;
using Proje.DAL.Context;
using Proje.DAL.Repositories;
using Proje.DATA.Entities;
using Proje.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Services.Concrete
{
    public class SiparisService : BaseService<Siparis> , ISiparisService
    {
        private readonly ISiparisRepository sp;

        public SiparisService(ISiparisRepository sp) : base(sp)
        {
            this.sp = sp;
        }

        public List<Siparis> GetSiparisIncludeMenu(string id)
        {
            return sp.GetUsersSiparisListIncludeSiparisMenuler(id);
        }
    }
}
