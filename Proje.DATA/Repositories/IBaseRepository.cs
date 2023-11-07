using Proje.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DATA.Repositories
{
    public interface IBaseRepository<T> where T : BaseClass
    {
        T GetById(int id);
        bool Add(T item);
        bool Delete(T item);
        bool DeleteById(int id);
        bool Update(T item);
        List<T> GetAll();
        T GetWhere(Expression<Func<T, bool>> exp);
        List<T> GetWhereAll(Expression<Func<T, bool>> exp);
        int Save();
    }
}
