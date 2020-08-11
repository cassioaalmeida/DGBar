using DGBar.Domain.Interfaces;
using DGBar.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Service.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> Repository)
        {
            _repository = Repository;
        }
        public virtual void Add(TEntity obj)
        {
            _repository.Add(obj);
        }
        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
        public virtual void Edit(TEntity obj)
        {
            _repository.Edit(obj);
        }
        public virtual void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }
    }
}
