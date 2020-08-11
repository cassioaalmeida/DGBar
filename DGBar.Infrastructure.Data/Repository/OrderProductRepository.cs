using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using System;
using System.Collections.Generic;
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
    }
}
