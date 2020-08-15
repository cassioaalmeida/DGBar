using Autofac;
using DGBar.Domain.Interfaces;
using DGBar.Domain.Interfaces.Services;
using DGBar.Infrastructure.CrossCutting.Adapter.Interfaces;
using DGBar.Infrastructure.CrossCutting.Adapter.Map;
using DGBar.Infrastructure.Data.Repository;
using DGBar.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Tests.Config
{
    public class ServiceRegisterationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<OrderProductService>().As<IOrderProductService>();


            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<OrderProductRepository>().As<IOrderProductRepository>();

            builder.RegisterType<MapperOrder>().As<IMapperOrder>();
            builder.RegisterType<MapperOrderProduct>().As<IMapperOrderProduct>();
            builder.RegisterType<MapperProduct>().As<IMapperProduct>();
        }
    }
}
