using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class BaseTest
    {
        protected IContainer container = null;

        public BaseTest()
        {
            var builder = new ContainerBuilder();
            var business = Assembly.Load("Invoicer.Business");
            builder.RegisterAssemblyTypes(business).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            container = builder.Build();
        }
    }
}
