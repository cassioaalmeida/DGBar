using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperProduct
    {
        Product MapperToEntity(ProductDTO productDTO);
        ProductDTO MapperToDTO(Product product);
        IEnumerable<ProductDTO> MapperListProducts(IEnumerable<Product> products);
        IEnumerable<Product> MapperListProductsToEntity(IEnumerable<ProductDTO> productDTOs);
    }
}
