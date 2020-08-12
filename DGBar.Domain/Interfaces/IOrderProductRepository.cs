using DGBar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.Interfaces
{
    public interface IOrderProductRepository : IBaseRepository<OrderProduct>
    {
        OrderProduct GetOrderProductByOrderIDAndProductId(int order_id, int product_id);
        IEnumerable<OrderProduct> GetOrderProductByOrderId(int order_id);
    }
}
