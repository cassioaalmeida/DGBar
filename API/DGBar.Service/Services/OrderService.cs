using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using DGBar.Domain.Interfaces.Services;
using DGBar.Infrastructure.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapperOrder _mapperOrder;

        public OrderService(IOrderRepository OrderRepository,
                            IMapperOrder MapperOrder)
        {
            _orderRepository = OrderRepository;
            _mapperOrder = MapperOrder;
        }

        public void Add(OrderDTO obj)
        {
            var objOrder = _mapperOrder.MapperToEntity(obj);
            _orderRepository.Add(objOrder);
            obj.Id = objOrder.Id;
        }
    
        public IEnumerable<OrderDTO> GetAll()
        {
            return _mapperOrder.MapperListOrders(_orderRepository.GetAll());
        }

        public OrderDTO GetById(int id)
        {
            return _mapperOrder.MapperToDTO(_orderRepository.GetById(id));
        }

        public void Delete(OrderDTO obj)
        {
            _orderRepository.Delete(_mapperOrder.MapperToEntity(obj));
        }

        public void Edit(OrderDTO obj)
        {
            _orderRepository.Edit(_mapperOrder.MapperToEntity(obj));
        }

        public ErrorDTO CheckOrderStatus(int order_id, ref OrderDTO order)
        {
            order = GetById(order_id);

            if (order != null && order.Status == "Closed")
                return (new ErrorDTO { Code = 409, Message = "Comanda já está fechada, não é possivel adicionar itens" });
            return null;
        }
    }
}
