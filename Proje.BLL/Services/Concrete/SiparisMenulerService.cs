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
    public class SiparisMenulerService :AraTabloService<SiparislerMenuler>,ISiparisMenulerService
    {
        private readonly IAraTabloRepository<SiparislerMenuler> araTabloRepository;

        public SiparisMenulerService(IAraTabloRepository<SiparislerMenuler> araTabloRepository) : base(araTabloRepository)
        {
            this.araTabloRepository = araTabloRepository;
        }

    }
}
