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

	}
}
