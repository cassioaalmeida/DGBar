using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DGBar.Infrastructure.Data.Repository
{
    public class OrderProductRepository: BaseRepository<OrderProduct>, IOrderProductRepository
    {
        private readonly Context.Context _context;
        public OrderProductRepository(Context.Context Context)
            : base(Context)
        {
            _context = Context;
        }
        public OrderProduct GetOrderProductByOrderIDAndProductId(int order_id, int product_id)
        {
            return _context.OrderProduct.Where(p => p.OrderID == order_id && p.ProductID == product_id).FirstOrDefault();
        }
        public IEnumerable<OrderProduct> GetOrderProductByOrderId(int order_id)
        {
            return _context.OrderProduct.Where(p => p.OrderID == order_id).ToList();
        }
    }
}
