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
    public class TestInvoiceConfig
    {
        public InvoiceController InvoiceController;
        public TestInvoiceConfig(string dbname, ContextConfig contextConfig)
        {
            Context context = contextConfig.getContext(dbname);
            InvoiceController = new InvoiceController(
                new OrderProductService(
                    new OrderProductRepository(
                        context),
                    new MapperOrderProduct()),
                new OrderService(
                    new OrderRepository(
                        context),
                    new MapperOrder()),
                new ProductService(
                    new ProductRepository(
                        context),
                    new MapperProduct())
                );
        }
    }
}
