using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGBar.Domain.DTO;
using DGBar.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGBar.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IOrderProductService _OrderProductService;
        private readonly IOrderService _OrderService;
        private readonly IProductService _ProductService;

        public InvoiceController(IOrderProductService OrderProductService,
                                 IOrderService OrderService,
                                 IProductService ProductService)
        {
            _OrderProductService = OrderProductService;
            _OrderService = OrderService;
            _ProductService = ProductService;
        }

        [HttpPost]
        public ActionResult<InvoiceDTO> GenerateInvoice(InvoiceParm invoiceParm)
        {
            OrderDTO order = null;

            ErrorDTO error = _OrderService.CheckOrderStatus(invoiceParm.orderId, ref order);

            if (error != null)
                return StatusCode(error.Code, error.Message);

            InvoiceDTO invoice = CreateInvoiceObject(order);

            CalculateInvoicePrice(invoice);

            order.Status = "Closed";

            _OrderService.Edit(order);


            return invoice;
        }
        [HttpGet]
        public ActionResult<InvoiceDTO> PreviewInvoice(int orderId)
        {
            OrderDTO order = _OrderService.GetById(orderId);

            InvoiceDTO invoice = CreateInvoiceObject(order);

            CalculateInvoicePrice(invoice);

            return invoice;
        }

        private void CalculateInvoicePrice(InvoiceDTO invoice)
        {
            int beer, brandy, juice, water;

            beer = brandy = juice = water = 0;

            foreach (InvoiceProductDTO item in invoice.Products)
            {
                invoice.Price += item.Price * item.Quantity;

                switch (item.Name.ToUpper())
                {
                    case "CERVEJA":
                        beer+= item.Quantity;
                        break;
                    case "CONHAQUE":
                        brandy += item.Quantity;
                        break;
                    case "SUCO":
                        juice += item.Quantity;
                        break;
                    case "AGUA":
                        water += item.Quantity;
                        break;
                    default:
                        break;
                }
            }

            invoice.Discount = CalculateInvoiceDiscount(beer, brandy, juice, water);
        }

        private double CalculateInvoiceDiscount(int beer, int brandy, int juice, int water)
        {
            double discount = 0;
            int brandyFactor = 0;
            int beerFactor = 0;
            int waterFactor = 0;

            if (beer > juice)
                discount += juice * 2;

            if (juice >= beer)
                discount += beer * 2;

            brandyFactor = Convert.ToInt32(Math.Truncate(brandy / 3.0));
            beerFactor = Convert.ToInt32(Math.Truncate(beer / 2.0));

            if (beerFactor > brandyFactor)
                waterFactor = brandyFactor;
            else
                waterFactor = beerFactor;

            if (water >= waterFactor)
                discount += waterFactor * 70;
            else
                discount += water * 70;

            return discount;
        }

        private InvoiceDTO CreateInvoiceObject(OrderDTO order)
        {
            InvoiceDTO invoice = new InvoiceDTO();
            invoice.Products = new List<InvoiceProductDTO>();

            if (order != null)
            {
                invoice.OrderId = (int)order.Id;

                List<OrderProductDTO> requests = _OrderProductService.GetAllWithChildsByOrderId(invoice.OrderId).ToList();

                foreach (OrderProductDTO item in requests)
                {
                    InvoiceProductDTO product = new InvoiceProductDTO();

                    product.ProductId = item.ProductID;
                    product.Name = item.Product.Name;
                    product.Price = item.Product.Price;
                    product.Quantity = item.Quantity;

                    invoice.Products.Add(product);
                }
            }

            return invoice;
        }
    }

    public class InvoiceParm
    {
        public int orderId { get; set; }
    }
}