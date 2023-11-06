using Proje.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DATA.Repositories
{
    public interface IMenuRepository : IBaseRepository<Menu>
    {
        List<Menu> GetMenusASCByPrice();
        List<Menu> GetMenusDESCByPrice();
        List<Menu> GetMenusExpensivePriceThan(int price);
        List<Menu> GetMenusCheaperPriceThan(int price);
        Menu GetMenuInludeSiparisler();
        List<Menu> GetMenusInludeSiparisler();
    }
}
