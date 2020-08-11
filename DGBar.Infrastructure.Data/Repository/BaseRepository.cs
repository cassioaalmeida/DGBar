using DGBar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DGBar.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DGBar.Infrastructure.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public Context.Context context;

        private readonly Context.Context _context;

        public BaseRepository(Context.Context Context)
        {
            _context = Context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Edit(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
