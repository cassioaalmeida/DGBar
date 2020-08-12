using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using DGBar.Domain.Interfaces.Services;
using DGBar.Infrastructure.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DGBar.Service.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderRepository;
        private readonly IMapperOrderProduct _mapperOrder;

        public OrderProductService(IOrderProductRepository OrderRepository,
                                      IMapperOrderProduct MapperOrder)
        {
            _orderRepository = OrderRepository;
            _mapperOrder = MapperOrder;
        }

        public void Add(OrderProductDTO obj)
        {
            var objOrderProduct = _mapperOrder.MapperToEntity(obj);
            _orderRepository.Add(objOrderProduct);
        }
    
        public IEnumerable<OrderProductDTO> GetAll()
        {
            return _mapperOrder.MapperListOrderProducts(_orderRepository.GetAll());
        }
        public IEnumerable<OrderProductDTO> GetAllWithChilds()
        {
            return _mapperOrder.MapperListOrderProducts(_orderRepository.GetAllWithChilds());
        }

        public IEnumerable<OrderProductDTO> GetAllWithChildsByOrderId(int order_id)
        {
            return _mapperOrder.MapperListOrderProducts(_orderRepository.GetAllWithChildsByOrderId(order_id));
        }
        public OrderProductDTO GetById(int id)
        {
            return _mapperOrder.MapperToDTO(_orderRepository.GetById(id));
        }

        public void Delete(OrderProductDTO obj)
        {
            _orderRepository.Delete(_mapperOrder.MapperToEntity(obj));
        }

        public void Edit(OrderProductDTO obj)
        {
            _orderRepository.Edit(_mapperOrder.MapperToEntity(obj));
        }
        public OrderProductDTO GetOrderProductByOrderIDAndProductId(int order_id, int product_id)
        {
            return _mapperOrder.MapperToDTO(_orderRepository.GetOrderProductByOrderIDAndProductId(order_id, product_id));
        }
        public IEnumerable<OrderProductDTO> GetOrderProductByOrderId(int order_id)
        {
            return _mapperOrder.MapperListOrderProducts(_orderRepository.GetOrderProductByOrderId(order_id));
        }

        public string CheckJuiceLimit(int order_id)
        {
            //Só é permitido 3 sucos por comanda, ID do suco = 3;
            OrderProductDTO request = _mapperOrder.MapperToDTO(_orderRepository.GetOrderProductByOrderIDAndProductId(order_id, 3));

            if (request != null && request.Quantity + 1 > 3)
                return ("Só é permitido 3 sucos por comanda.");

            return null;
        }

    }
}
