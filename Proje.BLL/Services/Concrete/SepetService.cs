

using Proje.BLL.Services.Abstract;
using Proje.DATA.Entities;
using Proje.DATA.Repositories;

namespace Proje.BLL.Services.Concrete
{
	public class SepetService : BaseService<DATA.Entities.Sepet>, ISepetService
    {
		private readonly IBaseRepository<DATA.Entities.Sepet> _baseRepository;

		public SepetService(IBaseRepository<DATA.Entities.Sepet> baseRepository) : base(baseRepository)
		{
			_baseRepository = baseRepository;

		}

	}
}
