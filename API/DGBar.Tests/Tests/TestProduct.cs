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
    public class TestProduct
    {
        private TestProductConfig _testProduct;

        public TestProduct()
        {
            ContextConfig contextConfig = new ContextConfig();
            _testProduct = new TestProductConfig(Util.Util.RandomString(10), contextConfig);
            Util.Util.LoadProducts(_testProduct);
        }
        [Fact]
        public void CreateProducts()
        {

            var result = _testProduct.ProductController.GetProducts();

            Assert.NotNull(result);
            Assert.IsType<ActionResult<IEnumerable<ProductDTO>>>(result);


            result.Value.ToList().Should().HaveCount(4);
        }
        [Fact]
        public void GetProductByWrongID()
        {
            var result = _testProduct.ProductController.GetProduct(10);

            Assert.NotNull(result);
            Assert.IsType<ActionResult<ProductDTO>>(result);
            result.Value.Should().BeNull();
        }
        [Fact]
        public void GetProductByID()
        {
            ProductDTO product = new ProductDTO()
            {
                Id = 1,
                Name = "Cerveja",
                Price = 5
            };

            var result = _testProduct.ProductController.GetProduct(1);

            Assert.NotNull(result);
            Assert.IsType<ActionResult<ProductDTO>>(result);
            result.Value.Should().BeEquivalentTo(product);
        }
    }
}
