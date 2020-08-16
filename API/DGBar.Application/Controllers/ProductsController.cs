using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces.Services;
using DGBar.Domain.DTO;
using Microsoft.AspNetCore.Authorization;

namespace DGBar.Application.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            return _ProductService.GetAll().ToList();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProduct(int id)
        {
            ProductDTO product = _ProductService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult<ProductDTO> PostProduct([FromBody] ProductDTO product)
        {
            _ProductService.Add(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }
    }
}
