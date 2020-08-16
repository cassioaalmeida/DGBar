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
    public class TestProductConfig
    {
        public ProductsController ProductController;
        public TestProductConfig(string dbname, ContextConfig contextConfig)
        {
            ProductController = new ProductsController(
                new ProductService(
                    new ProductRepository(
                        contextConfig.getContext(dbname)),
                    new MapperProduct()));
        }
    }
}
