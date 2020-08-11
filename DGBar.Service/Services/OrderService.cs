using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using DGBar.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderService _orderService;

        public OrderService(IOrderService OrderService)
        {
            _orderService = OrderService;
        }

        public void Add(Order obj)
        {
            _orderService.Add(obj);
        }
    
        public IEnumerable<Order> GetAll()
        {
            return _orderService.GetAll();
        }

        public Order GetById(int id)
        {
            return _orderService.GetById(id);
        }

        public void Delete(Order obj)
        {
            _orderService.Delete(obj);
        }

        public void Edit(Order obj)
        {
            _orderService.Edit(obj);
        }
    }
}
