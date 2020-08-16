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

namespace DGBar.Tests.Tests
{
    public class TestRequest
    {
        private TestRequestConfig _testRequest;
        private TestOrderConfig _testOrder;
        private TestProductConfig _testProduct;

        public TestRequest()
        {
            ContextConfig contextConfig = new ContextConfig();
            string var = Util.Util.RandomString(10);
            _testRequest = new TestRequestConfig(var, contextConfig);
            _testOrder = new TestOrderConfig(var, contextConfig);
            _testProduct = new TestProductConfig(var, contextConfig);
            Util.Util.LoadProducts(_testProduct);
        }
        [Fact]
        public void CreateRequest()
        {
            OrderDTO order = new OrderDTO();

            var orderResult = _testOrder.OrderController.PostOrder(order);

            var actionResult = _testRequest.RequestController
                .RequestProductForOrder(new RequestParms(){ OrderId = 1, ProductId = 1 });


            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<OrderProductDTO>>(actionResult);
        }
        [Fact]
        public void GetRequests()
        {
            OrderDTO order = new OrderDTO();

            var orderResult = _testOrder.OrderController.PostOrder(order);

            var actionResult = _testRequest.RequestController
                .RequestProductForOrder(new RequestParms() { OrderId = 1, ProductId = 1 });

            var result = _testRequest.RequestController.GetRequests();

            Assert.NotNull(result);
            Assert.IsType<ActionResult<IEnumerable<OrderProductDTO>>>(result);
            

            result.Value.ToList().Should().HaveCountGreaterOrEqualTo(1);
        }
        [Fact]
        public void CreateRequestWithInvalidOrder()
        {
            var actionResult = _testRequest.RequestController
                .RequestProductForOrder(new RequestParms() { OrderId = 55, ProductId = 1, Quantity = 1 });

            var result = _testRequest.RequestController.GetRequests(1);

            var dummy = _testRequest.RequestController.ResetRequest(new InvoiceParm() { orderId = 1 });

            Assert.IsType<ActionResult<IEnumerable<OrderProductDTO>>>(result);
            result.Value.ToList().Should().HaveCount(0);
        }
        [Fact]
        public void CreateRequestWithInvalidProduct()
        {
            OrderDTO order = new OrderDTO();

            var orderResult = _testOrder.OrderController.PostOrder(order);

            var actionResult = _testRequest.RequestController
                .RequestProductForOrder(new RequestParms() { OrderId = 1, ProductId = 1, Quantity = 1 });

            var result = _testRequest.RequestController.GetRequests(1);

            Assert.IsType<ActionResult<IEnumerable<OrderProductDTO>>>(result);
            result.Value.ToList().Should().HaveCountGreaterOrEqualTo(1);
        }
        [Fact]
        public void CreateRequestWithMoreThan3Juices()
        {
            OrderDTO order = new OrderDTO();

            var orderResult = _testOrder.OrderController.PostOrder(order);


            Util.Util.LoadProducts(_testProduct);

            var actionResult = _testRequest.RequestController
                .RequestProductForOrder(new RequestParms() { OrderId = 1, ProductId = 3, Quantity = 5 });

            var result = _testRequest.RequestController.GetRequests(1);

            Assert.IsType<ActionResult<IEnumerable<OrderProductDTO>>>(result);
            result.Value.ToList().Should().HaveCount(0);
        }

    }
}
