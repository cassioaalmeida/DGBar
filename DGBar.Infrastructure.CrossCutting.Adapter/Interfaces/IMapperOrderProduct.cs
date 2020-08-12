using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperOrderProduct
    {
        OrderProduct MapperToEntity(OrderProductDTO orderProductDTO);
        OrderProductDTO MapperToDTO(OrderProduct orderProduct);
        IEnumerable<OrderProductDTO> MapperListOrderProducts(IEnumerable<OrderProduct> orderProducts);
    }
}
