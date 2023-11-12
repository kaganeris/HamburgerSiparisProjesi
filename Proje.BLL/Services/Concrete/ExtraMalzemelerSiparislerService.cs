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
    public class ExtraMalzemelerSiparislerService : AraTabloService<ExtraMalzemelerSiparisler>, IExtraMalzemelerSiparislerService
    {
        private readonly IAraTabloRepository<ExtraMalzemelerSiparisler> araTabloRepository;

        public ExtraMalzemelerSiparislerService(IAraTabloRepository<ExtraMalzemelerSiparisler> araTabloRepository) : base(araTabloRepository)
        {
            this.araTabloRepository = araTabloRepository;
        }
    }
}
