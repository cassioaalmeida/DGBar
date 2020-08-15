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

namespace DGBar.Tests.Tests
{
    public class TestRequest
    {
        private TestRequestConfig _testRequest;
        private TestOrderConfig _testOrder;
        private TestProductConfig _testProduct;

        public TestRequest()
        {
            _testRequest = new TestRequestConfig();
            _testOrder = new TestOrderConfig();
            _testProduct = new TestProductConfig();
        }
        [Fact]
        public void CreateRequest()
        {
            OrderDTO order = new OrderDTO();

            var orderResult = _testOrder.OrderController.PostOrder(order);

            ProductDTO product = new ProductDTO()
            {
                Name = "Cerveja",
                Price = 5
            };

            var productResult = _testProduct.ProductController.PostProduct(product);

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

            ProductDTO product = new ProductDTO()
            {
                Name = "Cerveja",
                Price = 5
            };

            var productResult = _testProduct.ProductController.PostProduct(product);

            var actionResult = _testRequest.RequestController
                .RequestProductForOrder(new RequestParms() { OrderId = 1, ProductId = 1 });

            var result = _testRequest.RequestController.GetRequests();

            Assert.NotNull(result);
            Assert.IsType<ActionResult<IEnumerable<OrderProductDTO>>>(result);
            

            result.Value.ToList().Should().HaveCountGreaterOrEqualTo(1);
        }
        [Fact]
        public void GetOrderByWrongID()
        {
            OrderDTO order = new OrderDTO();


            var actionResult = _testRequest.OrderController.PostOrder(order);

            var result = _testRequest.OrderController.GetOrder(10);

            order.Id = 1;
            order.Status = "Open";

            Assert.NotNull(result);
            Assert.IsType<ActionResult<OrderDTO>>(result);
            result.Value.Should().BeNull();
        }
        [Fact]
        public void GetOrderByID()
        {
            OrderDTO order = new OrderDTO();


            var actionResult = _testRequest.OrderController.PostOrder(order);

            var result = _testRequest.OrderController.GetOrder(1);

            order.Id = 1;
            order.Status = "Open";

            Assert.NotNull(result);
            Assert.IsType<ActionResult<OrderDTO>>(result);
            result.Value.Should().BeEquivalentTo(order);
        }
    }
}
