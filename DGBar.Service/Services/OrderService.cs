using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using DGBar.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Service.Services
{
    class OrderService:BaseService<Order>, IOrderService
    {
        private readonly IOrderRepository _repositoryOrder;

        public OrderService(IOrderRepository RepositoryOrder)
            : base(RepositoryOrder)
        {
            _repositoryOrder = RepositoryOrder;
        }
    }
}
