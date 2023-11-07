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
    public class MenuService : BaseService<Menu> , IMenuService
    {
        private readonly IBaseRepository<Menu> baseRepository;

        public MenuService(IBaseRepository<Menu> baseRepository) : base(baseRepository)
        {
            this.baseRepository = baseRepository;
        }
    }
}
