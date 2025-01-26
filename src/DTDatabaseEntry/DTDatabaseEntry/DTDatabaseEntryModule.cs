using Autofac;
using DTDatabaseEntry.Services;

namespace DTDatabaseEntry
{
    public class DTDatabaseEntryModule : Module
    {
        /// <summary>
        /// Configures dependency injection by registering the <see cref="DTDatabase"/> 
        /// implementation for the <see cref="IDTDatabase"/> interface.
        /// </summary>
        /// <param name="builder">The container builder used to register dependencies.</param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<DTDatabase>().As<IDTDatabase>();
        }
    }
}