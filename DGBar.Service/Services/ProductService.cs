using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using DGBar.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Service.Services
{
    class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _repositoryProduct;

        public ProductService(IProductRepository RepositoryProduct)
            : base(RepositoryProduct)
        {
            _repositoryProduct = RepositoryProduct;
        }
    }
}
