using Autofac;
using DTDatabaseEntry.Services;

namespace DTDatabaseEntry
{
    public class DTDatabaseEntryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<DTDatabase>().As<IDTDatabase>();
        }
    }
}