using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using DGBar.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productService;

        public ProductService(IProductRepository OrderService)
        {
            _productService = OrderService;
        }

        public void Add(Product obj)
        {
            _productService.Add(obj);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productService.GetAll();
        }

        public Product GetById(int id)
        {
            return _productService.GetById(id);
        }

        public void Delete(Product obj)
        {
            _productService.Delete(obj);
        }

        public void Edit(Product obj)
        {
            _productService.Edit(obj);
        }
    }
}
