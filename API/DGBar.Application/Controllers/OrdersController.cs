using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces.Services;
using DGBar.Domain.Enums;
using DGBar.Domain.DTO;
using Microsoft.AspNetCore.Authorization;

namespace DGBar.Application.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _Orderservice;

        public OrdersController(IOrderService Orderservice)
        {
            _Orderservice = Orderservice;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<OrderDTO>> GetOrders()
        {
            return _Orderservice.GetAll().ToList();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<OrderDTO> GetOrder(int id)
        {
            OrderDTO order = _Orderservice.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: api/Orders
        [HttpPost]
        public ActionResult<OrderDTO> PostOrder([FromBody] OrderDTO orderDTO)
        {
            OrderDTO order = new OrderDTO();
            order.Status = "Open";
            _Orderservice.Add(order);

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }
        private bool OrderExists(int id)
        {
            return _Orderservice.GetById(id)!=null;
        }
    }
}
