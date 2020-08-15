using Autofac;
using Autofac.Extensions.DependencyInjection;
using DGBar.Application;
using DGBar.Domain.Interfaces;
using DGBar.Domain.Interfaces.Services;
using DGBar.Infrastructure.CrossCutting.IOC;
using DGBar.Infrastructure.Data.Repository;
using DGBar.Service.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DGBar.Tests
{
    public class TestContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;
        public TestContext()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder()
                
                .ConfigureTestServices(services =>
                {
                    services.AddAutofac();
                })
                .ConfigureTestContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new ModuleIOC());
                })
                .UseStartup<Startup>());

            //var hostBuilder = new HostBuilder()
            //    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            //    .ConfigureContainer<ContainerBuilder>(builder =>
            //    {
            //        builder.RegisterModule(new ModuleIOC());
            //    })
            //    .UseConsoleLifetime()
            //    .Build()
            //    .RunAsync();

            //Server = Host.GetTestServer();
            //Client = Host.GetTestClient();

            Client = _server.CreateClient();
        }
    }
}
