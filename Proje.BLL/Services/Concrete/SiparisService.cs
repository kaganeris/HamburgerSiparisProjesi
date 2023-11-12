using Proje.BLL.Services.Abstract;
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
        private readonly IBaseRepository<Siparis> baseRepository;

        public SiparisService(IBaseRepository<Siparis> baseRepository) : base(baseRepository) 
        {
            this.baseRepository = baseRepository;
        }

        public List<Siparis> GetSiparisIncludeMenu()
        {
            throw new NotImplementedException();
        }
    }
}
