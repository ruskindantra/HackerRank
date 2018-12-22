using Autofac;
using Common;

namespace Implementation
{
    public class ImplementationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BonAppetit>().Keyed<ISolveable>(Keys.BonAppetit);
            builder.RegisterType<SockMerchant>().Keyed<ISolveable>(Keys.SockMerchant);
        }
    }
}