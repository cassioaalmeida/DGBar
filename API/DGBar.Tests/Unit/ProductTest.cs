using System;
using Xunit;
using DGBar.Application;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Net;
using DGBar.Infrastructure.CrossCutting.IOC;
using DGBar.Tests.Config;
using DGBar.Service.Services;
using DGBar.Domain.Interfaces.Services;
using DGBar.Domain.DTO;

namespace DGBar.Tests.Unit
{
    public class ProductTest: IoCSupportedTest<ServiceRegisterationModule>
    {
        private readonly TestContext _testContext;
        public ProductTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async void GetAllProducts()
        {
            var response = await _testContext.Client.GetAsync("/Products");

            Assert.IsType<ProductDTO>(response);
        }
    }
}
