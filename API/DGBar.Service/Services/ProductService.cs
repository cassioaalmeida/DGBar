using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using DGBar.Domain.Interfaces.Services;
using DGBar.Infrastructure.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productService;
        private readonly IMapperProduct _mapperProduct;

        public ProductService(IProductRepository OrderService,
                              IMapperProduct MapperProduct)
        {
            _productService = OrderService;
            _mapperProduct = MapperProduct;
        }

        public void Add(ProductDTO obj)
        {
            var objProduct = _mapperProduct.MapperToEntity(obj);
            _productService.Add(objProduct);
            obj.Id = objProduct.Id;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return _mapperProduct.MapperListProducts(_productService.GetAll());
        }

        public ProductDTO GetById(int id)
        {
            return _mapperProduct.MapperToDTO(_productService.GetById(id));
        }

        public void Delete(ProductDTO obj)
        {
            _productService.Delete(_mapperProduct.MapperToEntity(obj));
        }

        public void Edit(ProductDTO obj)
        {
            _productService.Edit(_mapperProduct.MapperToEntity(obj));
        }
    }
}
