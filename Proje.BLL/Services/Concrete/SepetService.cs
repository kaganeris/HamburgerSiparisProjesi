

using Proje.BLL.Services.Abstract;
using Proje.DATA.Entities;
using Proje.DATA.Repositories;

namespace Proje.BLL.Services.Concrete
{
	public class SepetService : BaseService<Sepet>, ISepetService
    {
		private readonly IBaseRepository<Sepet> _baseRepository;

		public SepetService(IBaseRepository<Sepet> baseRepository) : base(baseRepository)
		{
			_baseRepository = baseRepository;

		}

	}
}
