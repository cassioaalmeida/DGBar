using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGBar.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IOrderProductService _OrderProductService;
        private readonly IOrderService _OrderService;
        private readonly IProductService _ProductService;

        public RequestController(IOrderProductService OrderProductService,
                                 IOrderService _OrderService,
                                 IProductService _ProductService)
        {
            _OrderProductService = OrderProductService;
            _OrderService = _OrderService;
            _ProductService = _ProductService;
        }

        // POST: api/Requests
        [HttpPost]
        public ActionResult<OrderProduct> RequestProductForOrder(int orderId, int productId)
        {
            Order order = _OrderService.GetById(orderId);

            Product product = _ProductService.GetById(productId);

            if (order == null || product == null)
                return NotFound();

            OrderProduct request = new OrderProduct();

            request.Order = order;
            request.OrderID = orderId;
            request.Product = product;
            request.ProductID = productId;

            _OrderProductService.Add(request);

            return CreatedAtAction("GetRequest", new { orderId = request.OrderID, productId = request.ProductID }, request);
        }
    }
}