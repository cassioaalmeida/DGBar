using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.Interfaces.Services
{
    public interface IProductService
    {
        void Add(ProductDTO obj);

        ProductDTO GetById(int id);

        IEnumerable<ProductDTO> GetAll();

        void Edit(ProductDTO obj);

        void Delete(ProductDTO obj);
    }
}
