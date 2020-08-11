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
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
            _orderRepository = OrderRepository;
        }

        public void Add(Order obj)
        {
            _orderRepository.Add(obj);
        }
    
        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public void Delete(Order obj)
        {
            _orderRepository.Delete(obj);
        }

        public void Edit(Order obj)
        {
            _orderRepository.Edit(obj);
        }
    }
}
