using Microsoft.EntityFrameworkCore;
using Proje.DAL.Context;
using Proje.DATA.Entities;
using Proje.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.Repositories
{
	public class SepetRepository : BaseRepository<Sepet> ,ISepet
	{
		private readonly AppDbContext context;

		public SepetRepository(AppDbContext context) : base(context)
		{
			this.context = context;
		}
        public override bool Delete(Sepet item)
        {
            try
            {
                context.Set<Sepet>().Remove(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Sepet> GetSepetIncludeMenu(string userId)
        {
            return context.Set<Sepet>().Where(x=>x.UserId==userId).Include(x=>x.Menu).ToList();
        }
    }
}
