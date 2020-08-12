using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperOrder
    {
        Order MapperToEntity(OrderDTO orderDTO);
        OrderDTO MapperToDTO(Order order);
        IEnumerable<OrderDTO> MapperListOrders(IEnumerable<Order> orders);
        IEnumerable<Order> MapperListOrdersToEntity(IEnumerable<OrderDTO> orderDTOs);
    }
}
