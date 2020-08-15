using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Tests.Config
{
    public class IoCSupportedTest<TModule> where TModule : IModule, new()
    {
        protected IContainer container;

        public IoCSupportedTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new TModule());
            container = builder.Build();
        }

        protected TEntity Resolve<TEntity>()
        {
            return container.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            // Logic when test case class finish it's job
        }
    }
}
