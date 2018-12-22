using Autofac;

namespace Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ConsoleWriter>().AsImplementedInterfaces();
            builder.RegisterType<ConsoleReader>().AsImplementedInterfaces();
        }
    }
}