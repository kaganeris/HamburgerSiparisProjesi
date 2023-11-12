

using Proje.BLL.Services.Abstract;
using Proje.DAL.Context;
using Proje.DAL.Repositories;
using Proje.DATA.Entities;
using Proje.DATA.Repositories;

namespace Proje.BLL.Services.Concrete
{
	public class SepetService : SepetRepository, ISepetService
    {
		private readonly AppDbContext context;

		public SepetService(AppDbContext context) : base(context)
		{

		}

	}
}
