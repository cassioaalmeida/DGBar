using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Infrastructure.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly Context.Context _context;
        public ProductRepository(Context.Context Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
