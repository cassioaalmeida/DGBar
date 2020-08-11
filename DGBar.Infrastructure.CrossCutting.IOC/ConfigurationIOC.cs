using Autofac;
using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using DGBar.Domain.Interfaces.Services;
using DGBar.Infrastructure.Data.Repository;
using DGBar.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<ProductService>().As<IProductService>();


            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();

        }
    }
}
