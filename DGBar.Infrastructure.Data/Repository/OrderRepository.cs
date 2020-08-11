using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Infrastructure.Data.Repository
{
    public class OrderRepository: BaseRepository<Order>, IOrderRepository
    {
        private readonly Context.Context _context;
        public OrderRepository(Context.Context Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
