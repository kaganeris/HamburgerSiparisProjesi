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
    public class SiparisRepository : BaseRepository<Siparis>, ISiparisRepository
    {
        private readonly AppDbContext context;

        public SiparisRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public Siparis GetSiparisIncludeExtraMalzemelerSiparisler()
        {
            return context.Siparisler.Include(x => x.ExtraMalzemelerSiparisler).FirstOrDefault();
        }

        public Siparis GetSiparisIncludeSiparisMenuler()
        {
            return context.Siparisler.Include(x => x.SiparislerMenuler).FirstOrDefault();
        }

        public List<Siparis> GetSiparisListIncludeExtraMalzemelerSiparisler()
        {
            return context.Siparisler.Include(x => x.ExtraMalzemelerSiparisler).ToList();
        }

        public List<Siparis> GetSiparisListIncludeSiparisMenuler()
        {
            return context.Siparisler.Include(x => x.SiparislerMenuler).ToList();
        }

		public List<Siparis> GetSiparisListPiecesGreaterThan(int pieces)
		{
			throw new NotImplementedException();
		}

		public List<Siparis> GetSiparisListPiecesSmallerThan(int pieces)
		{
			throw new NotImplementedException();
		}
	}
}
