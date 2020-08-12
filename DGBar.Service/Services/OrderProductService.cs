using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using DGBar.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public OrderProduct GetOrderProductByOrderIDAndProductId(int order_id, int product_id)
        {
            return _orderRepository.GetOrderProductByOrderIDAndProductId(order_id, product_id);
        }
        public IEnumerable<OrderProduct> GetOrderProductByOrderId(int order_id)
        {
            return _orderRepository.GetOrderProductByOrderId(order_id);
        }

        public string CheckJuiceLimit(int order_id)
        {
            //Só é permitido 3 sucos por comanda, ID do suco = 3;
            OrderProduct request = _orderRepository.GetOrderProductByOrderIDAndProductId(order_id, 3);

            if (request != null && request.Quantity + 1 > 3)
                return ("Só é permitido 3 sucos por comanda.");

            return null;
        }


    }
}
