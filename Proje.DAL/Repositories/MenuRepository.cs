using Microsoft.EntityFrameworkCore;
using Proje.DAL.Context;
using Proje.DATA.Entities;
using Proje.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        private readonly AppDbContext context;

        public MenuRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public Menu GetMenuInludeSiparisler()
        {
            return context.Menuler.Include(x => x.SiparislerMenuler).FirstOrDefault();
        }

        public List<Menu> GetMenusASCByPrice()
        {
            return context.Menuler.OrderBy(x => x.Fiyat).ToList();
        }

        public List<Menu> GetMenusCheaperPriceThan(int price)
        {
            return context.Menuler.Where(x => x.Fiyat < price).ToList();
        }

        public List<Menu> GetMenusDESCByPrice()
        {
            return context.Menuler.OrderByDescending(x => x.Fiyat).ToList();
        }

        public List<Menu> GetMenusExpensivePriceThan(int price)
        {
            return context.Menuler.Where(x => x.Fiyat > price).ToList();
        }

        public List<Menu> GetMenusInludeSiparisler()
        {
            return context.Menuler.Include(x => x.SiparislerMenuler).ToList();
        }
    }
}
