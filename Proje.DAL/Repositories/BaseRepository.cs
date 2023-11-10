using Proje.DAL.Context;
using Proje.DATA.Entities;
using Proje.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseClass
    {
        private readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public bool Add(T item)
        {
            try
            {
                item.AktifMi = true;
                item.OlusturmaZamani = DateTime.Now;
                context.Set<T>().Add(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public virtual bool Delete(T item)
        {
            try
            {
                item.AktifMi = false;
                item.SilinmeZamani = DateTime.Now;
                context.Set<T>().Update(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            T item = GetById(id);
            if(item == null)
            {
                return false;
            }
            else
            {
                try
                {
                    item.AktifMi = false;
                    item.SilinmeZamani = DateTime.Now;
                    context.Set<T>().Update(item);
                    return Save() > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Where(x => x.ID == id).FirstOrDefault();
        }

        public T GetWhere(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).FirstOrDefault();
        }

        public List<T> GetWhereAll(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).ToList();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public bool Update(T item)
        {
            try
            {
                item.AktifMi = true;
                item.GuncellemeZamani = DateTime.Now;
                context.Set<T>().Update(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
