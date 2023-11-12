using Proje.BLL.Services.Abstract;
using Proje.DATA.Entities;
using Proje.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Services.Concrete
{
    public class ExtraMalzemelerService : BaseService<ExtraMalzeme> , IExtraMalzemelerService
    {
        private readonly IBaseRepository<ExtraMalzeme> baseRepository;

        public ExtraMalzemelerService(IBaseRepository<ExtraMalzeme> baseRepository) : base(baseRepository)
        {
            this.baseRepository = baseRepository;
        }
    }
}
