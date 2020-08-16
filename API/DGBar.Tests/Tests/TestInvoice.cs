using Autofac;
using Autofac.Extensions.DependencyInjection;
using DGBar.Application;
using DGBar.Application.Controllers;
using DGBar.Domain.DTO;
using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using DGBar.Domain.Interfaces.Services;
using DGBar.Infrastructure.CrossCutting.Adapter.Map;
using DGBar.Infrastructure.CrossCutting.IOC;
using DGBar.Infrastructure.Data.Context;
using DGBar.Infrastructure.Data.Repository;
using DGBar.Service.Services;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using DGBar.Tests.Config;
using System.Net;
using DGBar.Tests.Util;

namespace DGBar.Tests.Tests
{
    public class TestInvoice
    {
        private TestRequestConfig _testRequest;
        private TestOrderConfig _testOrder;
        private TestProductConfig _testProduct;
        private TestInvoiceConfig _testInvoice;
        OrderDTO order = new OrderDTO();
        ContextConfig contextConfig = new ContextConfig();

        public TestInvoice()
        {
            string var = Util.Util.RandomString(10);
            _testRequest = new TestRequestConfig(var, contextConfig);
            _testOrder = new TestOrderConfig(var, contextConfig);
            _testProduct = new TestProductConfig(var, contextConfig);
            _testInvoice = new TestInvoiceConfig(var, contextConfig);
            Util.Util.LoadProducts(_testProduct);

            var orderResult = _testOrder.OrderController.PostOrder(order);
        }
        [Fact]
        public void CreateRequestWithoutDiscount()
        {
            var dummy = _testRequest.RequestController.ResetRequest(new InvoiceParm() { orderId=1 });

            var actionResult = _testRequest.RequestController
                .RequestProductForOrder(new RequestParms() { OrderId = 1, ProductId = 1, Quantity = 1 });
            actionResult = _testRequest.RequestController
                .RequestProductForOrder(new RequestParms() { OrderId = 1, ProductId = 2, Quantity = 1 });

            var result = _testInvoice.InvoiceController.PreviewInvoice(1);

            //Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<InvoiceDTO>>(result);
            result.Value.Discount.Should().Be(0);
            result.Value.Price.Should().Be(25);
        }
        [Theory]
        [InlineData(1, 2, 105, 2)]
        [InlineData(2, 1, 60, 2)]
        [InlineData(2, 2, 110, 4)]
        public void CreateRequestWithBeerAndJuiceDiscount(int beerQuantity, int juiceQuantity, int price, int discount)
        {
            var dummy = _testRequest.RequestController.ResetRequest(new InvoiceParm() { orderId = 1 });

            var actionResult = _testRequest.RequestController
                .RequestProductForOrder(new RequestParms() { OrderId = 1, ProductId = 1, Quantity = beerQuantity });
            actionResult = _testRequest.RequestController
                .RequestProductForOrder(new RequestParms() { OrderId = 1, ProductId = 3, Quantity = juiceQuantity });

            var result = _testInvoice.InvoiceController.PreviewInvoice(1);

            //Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<InvoiceDTO>>(result);

            result.Value.Discount.Should().Be(discount);
            result.Value.Price.Should().Be(price);
        }

    }
}
