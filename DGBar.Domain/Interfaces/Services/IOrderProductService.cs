using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.Interfaces.Services
{
    public interface IOrderProductService
    {
        void Add(OrderProductDTO obj);

        OrderProductDTO GetById(int id);

        IEnumerable<OrderProductDTO> GetAll();

        void Edit(OrderProductDTO obj);

        void Delete(OrderProductDTO obj);

        string CheckJuiceLimit(int order_id);

        OrderProductDTO GetOrderProductByOrderIDAndProductId(int order_id, int product_id);
        IEnumerable<OrderProductDTO> GetOrderProductByOrderId(int order_id);
        IEnumerable<OrderProductDTO> GetAllWithChilds();
        IEnumerable<OrderProductDTO> GetAllWithChildsByOrderId(int order_id);
    }
}
