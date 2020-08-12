using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        void Add(OrderDTO obj);

        OrderDTO GetById(int id);

        IEnumerable<OrderDTO> GetAll();

        void Edit(OrderDTO obj);

        void Delete(OrderDTO obj);
    }
}
