using DGBar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.Interfaces.Services
{
    public interface IProductService
    {
        void Add(Product obj);

        Product GetById(int id);

        IEnumerable<Product> GetAll();

        void Edit(Product obj);

        void Delete(Product obj);
    }
}
