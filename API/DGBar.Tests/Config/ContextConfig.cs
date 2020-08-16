using DGBar.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Tests.Config
{
    public class ContextConfig
    {
        public Context MyContext { get; set; }
        public Context getContext(string dbname)
        {
            if(MyContext == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<Context>();
                optionsBuilder.UseInMemoryDatabase(databaseName: dbname)
                    .EnableSensitiveDataLogging()
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                MyContext = new Context(optionsBuilder.Options);
            }
            return MyContext;
        }
    }
}
