using Proje.BLL.Services.Abstract;
using Proje.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Services.Concrete
{
    public class AraTabloService<T> : IAraTabloService<T> where T : class
    {
        private readonly IAraTabloRepository<T> araTabloRepository;

        public AraTabloService(IAraTabloRepository<T> araTabloRepository)
        {
            this.araTabloRepository = araTabloRepository;
        }
        public bool Add(T item)
        {
            if (item == null)
                return false;
            else
                return araTabloRepository.Add(item);
        }

        public bool Delete(T item)
        {
            if (item == null)
                return false;
            else
                return araTabloRepository.Delete(item);
        }

        public List<T> GetAll()
        {
            return araTabloRepository.GetAll();
        }

        public T GetWhere(Expression<Func<T, bool>> exp)
        {
            return araTabloRepository.GetWhere(exp);
        }

        public List<T> GetWhereAll(Expression<Func<T, bool>> exp)
        {
            return araTabloRepository.GetWhereAll(exp);
        }

        public bool Update(T item)
        {
            if (item == null)
                return false;
            else
                return araTabloRepository.Update(item);
        }
    }
}
