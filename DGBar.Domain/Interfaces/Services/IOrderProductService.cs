using DGBar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.Interfaces.Services
{
    public interface IOrderProductService
    {
        void Add(OrderProduct obj);

        OrderProduct GetById(int id);

        IEnumerable<OrderProduct> GetAll();

        void Edit(OrderProduct obj);

        void Delete(OrderProduct obj);
    }
}
