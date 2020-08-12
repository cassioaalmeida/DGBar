using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using DGBar.Domain.Enums;
using DGBar.Infrastructure.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Infrastructure.CrossCutting.Adapter.Map
{
    public class MapperProduct : IMapperProduct
    {

        public Product MapperToEntity(ProductDTO productDTO)
        {
            Product product = new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Price = productDTO.Price
            };

            return product;
        }

        public ProductDTO MapperToDTO(Product product)
        {
            ProductDTO productDTO = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            return productDTO;
        }
        public IEnumerable<ProductDTO> MapperListProducts(IEnumerable<Product> products)
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();

            foreach (Product item in products)
            {
                ProductDTO productDTO = new ProductDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price
                };

                productDTOs.Add(productDTO);
            }

            return productDTOs;
        }

        public IEnumerable<Product> MapperListProductsToEntity(IEnumerable<ProductDTO> productDTOs)
        {
            List<Product> products = new List<Product>();

            foreach (ProductDTO item in productDTOs)
            {
                Product product = new Product
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price
                };

                products.Add(product);
            }

            return products;
        }
    }
}
