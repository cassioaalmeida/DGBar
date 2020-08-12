using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using DGBar.Domain.Enums;
using DGBar.Infrastructure.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Infrastructure.CrossCutting.Adapter.Map
{
    public class MapperOrder : IMapperOrder
    {

        public Order MapperToEntity(OrderDTO orderDTO)
        {
            Order order = new Order
            {
                Id = orderDTO.Id,
                Status = orderDTO.Status == "Open" ? OrderStatus.Open : OrderStatus.Closed
            };

            return order;
        }

        public OrderDTO MapperToDTO(Order order)
        {
            OrderDTO orderDTO = new OrderDTO
            {
                Id = order.Id,
                Status = order.Status == OrderStatus.Open?"Open":"Closed"
            };

            return orderDTO;
        }
        public IEnumerable<OrderDTO> MapperListOrders(IEnumerable<Order> orders)
        {
            List<OrderDTO> orderDTOs = new List<OrderDTO>();

            foreach (Order item in orders)
            {
                OrderDTO orderDTO = new OrderDTO
                {
                    Id = item.Id,
                    Status = item.Status == OrderStatus.Open ? "Open" : "Closed"
                };

                orderDTOs.Add(orderDTO);
            }

            return orderDTOs;
        }

        public IEnumerable<Order> MapperListOrdersToEntity(IEnumerable<OrderDTO> orderDTOs)
        {
            List<Order> orders = new List<Order>();

            foreach (OrderDTO item in orderDTOs)
            {
                Order order = new Order
                {
                    Id = item.Id,
                    Status = item.Status == "Open" ? OrderStatus.Open : OrderStatus.Closed
                };

                orders.Add(order);
            }

            return orders;
        }
    }
}
