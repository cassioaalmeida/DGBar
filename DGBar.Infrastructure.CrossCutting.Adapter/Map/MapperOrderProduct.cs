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
        public MapperOrder MapperOrder = new MapperOrder();
        public MapperProduct MapperProduct = new MapperProduct();

        public OrderProduct MapperToEntity(OrderProductDTO orderProductDTO)
        {
            if (orderProductDTO == null)
                return null;
            OrderProduct orderProduct = new OrderProduct
            {
                OrderID = orderProductDTO.OrderID,
                ProductID = orderProductDTO.ProductID,
                Order = MapperOrder.MapperToEntity(orderProductDTO.Order),
                Product = MapperProduct.MapperToEntity(orderProductDTO.Product),
                Quantity = orderProductDTO.Quantity
            };

            return orderProduct;
        }

        public OrderProductDTO MapperToDTO(OrderProduct orderProduct)
        {
            if (orderProduct == null)
                return null;
            OrderProductDTO orderProductDTO = new OrderProductDTO
            {
                OrderID = orderProduct.OrderID,
                ProductID = orderProduct.ProductID,
                Order = MapperOrder.MapperToDTO(orderProduct.Order),
                Product = MapperProduct.MapperToDTO(orderProduct.Product),
                Quantity = orderProduct.Quantity
            };

            return orderProductDTO;
        }
        public IEnumerable<OrderProductDTO> MapperListOrderProducts(IEnumerable<OrderProduct> orderProducts)
        {
            List<OrderProductDTO> orderProductDTOs = new List<OrderProductDTO>();

            foreach (OrderProduct item in orderProducts)
            {
                OrderDTO order = MapperOrder.MapperToDTO(item.Order);
                ProductDTO product = MapperProduct.MapperToDTO(item.Product);
                OrderProductDTO orderProductDTO = new OrderProductDTO
                {
                    OrderID = item.OrderID,
                    ProductID = item.ProductID,
                    Order = order,
                    Product = product,
                    Quantity = item.Quantity
                };

                orderProductDTOs.Add(orderProductDTO);
            }

            return orderProductDTOs;
        }
    }
}
