using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Services.Abstract
{
    public interface IAraTabloService<T>
    {
        bool Add(T item);
        bool Delete(T item);
        bool Update(T item);
        List<T> GetAll();
        T GetWhere(Expression<Func<T, bool>> exp);
        List<T> GetWhereAll(Expression<Func<T, bool>> exp);
    }
}
