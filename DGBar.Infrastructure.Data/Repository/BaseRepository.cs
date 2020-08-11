using DGBar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DGBar.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DGBar.Infrastructure.Data.Repository
{
    class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public Context.Context context;

        public IEnumerable<T> GetAll()
        {
            using (context = new Context.Context())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetById(int id)
        {
            using (context = new Context.Context())
            {
                return context.Set<T>().Find(id);
            }
        }

        public void Add(T entity)
        {
            using (context = new Context.Context())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Edit(T entity)
        {
            using (context = new Context.Context())
            {
                context.Entry<T>(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (context = new Context.Context())
            {
                context.Set<T>().Attach(entity);
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
