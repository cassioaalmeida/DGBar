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
    public class TestOrder
    {
        private TestOrderConfig _testOrder;

        public TestOrder()
        {
            _testOrder = new TestOrderConfig();
        }
        [Fact]
        public void CreateOrder()
        {
            OrderDTO order = new OrderDTO();

            var actionResult = _testOrder.OrderController.PostOrder(order);

            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<OrderDTO>>(actionResult);
        }
        [Fact]
        public void GetOrders()
        {
            OrderDTO order = new OrderDTO();


            var actionResult = _testOrder.OrderController.PostOrder(order);

            var result = _testOrder.OrderController.GetOrders();

            Assert.NotNull(result);
            Assert.IsType<ActionResult<IEnumerable<OrderDTO>>>(result);
            

            result.Value.ToList().Should().HaveCountGreaterOrEqualTo(1);
        }
        [Fact]
        public void GetOrderByWrongID()
        {
            OrderDTO order = new OrderDTO();


            var actionResult = _testOrder.OrderController.PostOrder(order);

            var result = _testOrder.OrderController.GetOrder(10);

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


            var actionResult = _testOrder.OrderController.PostOrder(order);

            var result = _testOrder.OrderController.GetOrder(1);

            order.Id = 1;
            order.Status = "Open";

            Assert.NotNull(result);
            Assert.IsType<ActionResult<OrderDTO>>(result);
            result.Value.Should().BeEquivalentTo(order);
        }
    }
}
