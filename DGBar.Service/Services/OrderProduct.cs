using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using DGBar.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Service.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderRepository;

        public OrderProductService(IOrderProductRepository OrderRepository)
        {
            _orderRepository = OrderRepository;
        }

        public void Add(OrderProduct obj)
        {
            _orderRepository.Add(obj);
        }
    
        public IEnumerable<OrderProduct> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public OrderProduct GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public void Delete(OrderProduct obj)
        {
            _orderRepository.Delete(obj);
        }

        public void Edit(OrderProduct obj)
        {
            _orderRepository.Edit(obj);
        }
    }
}
