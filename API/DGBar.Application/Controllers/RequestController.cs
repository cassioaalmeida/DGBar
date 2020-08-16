using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace DGBar.Application.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IOrderProductService _OrderProductService;
        private readonly IOrderService _OrderService;
        private readonly IProductService _ProductService;

        public RequestController(IOrderProductService OrderProductService,
                                 IOrderService OrderService,
                                 IProductService ProductService)
        {
            _OrderProductService = OrderProductService;
            _OrderService = OrderService;
            _ProductService = ProductService;
        }
        // GET: api/Requests
        [HttpGet]
        public ActionResult<IEnumerable<OrderProductDTO>> GetRequests()
        {
            return _OrderProductService.GetAllWithChilds().ToList();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<OrderProductDTO>> GetRequests(int id)
        {
            return _OrderProductService.GetAllWithChildsByOrderId(id).ToList();
        }
        // POST: api/Requests
        [HttpPost]
        public ActionResult<OrderProductDTO> RequestProductForOrder(RequestParms req)
        {
            int orderId = req.OrderId;
            int productId = req.ProductId;

            OrderDTO order = null;

            ErrorDTO error = _OrderService.CheckOrderStatus(orderId,ref order);

            if (error != null)
                return StatusCode(error.Code, error.Message);

            ProductDTO product = _ProductService.GetById(productId);

            if (order == null)
                return StatusCode(404, "Ordem não encontrada");
            if (product == null)
                return StatusCode(404, "Produto não encontrado");

            if (productId == 3)
            {
                error = _OrderProductService.CheckJuiceLimit(orderId, req.Quantity>0?(int)req.Quantity:1);

                if (error != null)
                    return StatusCode(error.Code, error.Message);
            }

            OrderProductDTO request = _OrderProductService.GetOrderProductByOrderIDAndProductId(orderId, productId);

            if(request == null)
            {
                request = new OrderProductDTO();

                //request.Order = order;
                request.OrderID = orderId;
                //request.Product = product;
                request.ProductID = productId;
                if (req.Quantity > 0)
                    request.Quantity = (int)req.Quantity;
                else
                    request.Quantity = 1;

                _OrderProductService.Add(request);
            }
            else
            {
                if (req.Quantity > 0)
                    request.Quantity += (int)req.Quantity;
                else
                    request.Quantity += 1;

                _OrderProductService.Edit(request);
            }

            return CreatedAtAction("GetRequests", new { orderId = request.OrderID, productId = request.ProductID }, request);
        }

        [HttpDelete]
        public ActionResult<OrderProductDTO> ResetRequest(InvoiceParm invoice)
        {
            OrderDTO order = _OrderService.GetById(invoice.orderId);
            if (order != null && order.Status == "Closed")
                return StatusCode(409, new { message = "Comanda já está fechada, não é possivel resetar" });

            List<OrderProductDTO> requests = _OrderProductService.GetOrderProductByOrderId(invoice.orderId).ToList();

            foreach (OrderProductDTO item in requests)
            {
                item.Order = null;
                _OrderProductService.Delete(item);
            }

            return Ok();
        }
    }

    public class RequestParms
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}