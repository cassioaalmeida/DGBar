using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using DGBar.Domain.Enums;
using DGBar.Infrastructure.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Infrastructure.CrossCutting.Adapter.Map
{
    public class MapperOrderProduct : IMapperOrderProduct
    {
        public MapperOrder MapperOrder { get; set; }
        public MapperProduct MapperProduct { get; set; }

        public OrderProduct MapperToEntity(OrderProductDTO orderProductDTO)
        {
            OrderProduct orderProduct = new OrderProduct
            {
                OrderID = orderProductDTO.OrderID,
                ProductID = orderProductDTO.ProductID,
                Order = MapperOrder.MapperToEntity(orderProductDTO.Order),
                Product = MapperProduct.MapperToEntity(orderProductDTO.Product)
            };

            return orderProduct;
        }

        public OrderProductDTO MapperToDTO(OrderProduct orderProduct)
        {
            OrderProductDTO orderProductDTO = new OrderProductDTO
            {
                OrderID = orderProduct.OrderID,
                ProductID = orderProduct.ProductID,
                Order = MapperOrder.MapperToDTO(orderProduct.Order),
                Product = MapperProduct.MapperToDTO(orderProduct.Product)
            };

            return orderProductDTO;
        }
        public IEnumerable<OrderProductDTO> MapperListOrderProducts(IEnumerable<OrderProduct> orderProducts)
        {
            List<OrderProductDTO> orderProductDTOs = new List<OrderProductDTO>();

            foreach (OrderProduct item in orderProducts)
            {
                OrderProductDTO orderProductDTO = new OrderProductDTO
                {
                    OrderID = item.OrderID,
                    ProductID = item.ProductID,
                    Order = MapperOrder.MapperToDTO(item.Order),
                    Product = MapperProduct.MapperToDTO(item.Product)
                };

                orderProductDTOs.Add(orderProductDTO);
            }

            return orderProductDTOs;
        }
    }
}
