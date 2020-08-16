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
    public class TestOrderConfig
    {
        public OrdersController OrderController;
        public TestOrderConfig(string dbname, ContextConfig contextConfig)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase(databaseName: dbname)
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            OrderController = new OrdersController(
                new OrderService(
                    new OrderRepository(
                        contextConfig.getContext(dbname)),
                    new MapperOrder()));
        }
    }
}
