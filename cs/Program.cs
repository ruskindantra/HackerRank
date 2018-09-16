using System;
using Autofac;
using cs.Algorithms;
using cs.Common;

namespace cs
{
    class Solutions
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<BonAppetit>().SingleInstance();
            containerBuilder.RegisterType<ConsoleReader>().SingleInstance();

            var container = containerBuilder.Build();

            var bonAppetit = container.Resolve<BonAppetit>();
            bonAppetit.Solve();
        }
    }
}
