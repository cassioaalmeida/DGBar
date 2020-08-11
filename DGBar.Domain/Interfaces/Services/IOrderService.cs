using DGBar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        void Add(Order obj);

        Order GetById(int id);

        IEnumerable<Order> GetAll();

        void Edit(Order obj);

        void Delete(Order obj);
    }
}
