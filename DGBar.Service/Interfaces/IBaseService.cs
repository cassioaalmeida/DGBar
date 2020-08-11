using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Service.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

    }
}
