using Proje.BLL.Services.Abstract;
using Proje.DATA.Entities;
using Proje.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Services.Concrete
{
    public class BaseService<T> : IBaseService<T> where T : BaseClass
    {
        private readonly IBaseRepository<T> baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public bool Add(T item)
        {
            if(item == null)
                return false;
            else
                return baseRepository.Add(item);
        }

        public bool Delete(T item)
        {
            if (item == null)
                return false;
            else
                return baseRepository.Delete(item);
        }

        public bool DeleteById(int id)
        {
            if (id < 1)
                return false;
            else
                return baseRepository.DeleteById(id);
        }

        public List<T> GetAll()
        {
            return baseRepository.GetAll();
        }

        public T GetById(int id)
        {
            if (id < 1)
                return default;
            else
                return baseRepository.GetById(id);
        }

        public T GetWhere(Expression<Func<T, bool>> exp)
        {
            return baseRepository.GetWhere(exp);
        }

        public List<T> GetWhereAll(Expression<Func<T, bool>> exp)
        {
            return baseRepository.GetWhereAll(exp);
        }

        public bool Update(T item)
        {
            if (item == null)
                return false;
            else
                return baseRepository.Update(item);
        }
    }
}
