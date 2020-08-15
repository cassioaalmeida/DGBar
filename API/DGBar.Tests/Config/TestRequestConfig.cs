using DGBar.Application.Controllers;
using DGBar.Infrastructure.CrossCutting.Adapter.Map;
using DGBar.Infrastructure.Data.Context;
using DGBar.Infrastructure.Data.Repository;
using DGBar.Service.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Tests.Config
{
    public class TestRequestConfig
    {
        public RequestController RequestController;
        public TestRequestConfig()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "TestsDB")
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            RequestController = new RequestController(
                new OrderProductService(
                    new OrderProductRepository(
                        new Context(optionsBuilder.Options)),
                    new MapperOrderProduct()),
                new OrderService(
                    new OrderRepository(
                        new Context(optionsBuilder.Options)),
                    new MapperOrder()),
                new ProductService(
                    new ProductRepository(
                        new Context(optionsBuilder.Options)),
                    new MapperProduct())
                );
        }
    }
}
