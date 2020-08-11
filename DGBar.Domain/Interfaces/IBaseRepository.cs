using System;
using System.Collections.Generic;
using System.Text;
using DGBar.Domain.Entities;

namespace DGBar.Domain.Interfaces
{
    public interface IBaseRepository<T> where T:class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);
    }
}
