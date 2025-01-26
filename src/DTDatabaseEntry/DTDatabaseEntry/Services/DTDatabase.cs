using DTDatabaseEntry.Descriptor;
using PX.Data;

namespace DTDatabaseEntry.Services
{
    public class DTDatabase : IDTDatabase
    {
        private readonly PXGraph _graph;

        public DTDatabase(PXGraph graph)
        {
            _graph = graph;
        }

        public string GetDBType()
        {
            var provider = PXDatabase.Provider;
            if (Constants.SupportedProviders.TryGetValue(provider.GetType(), out var supportedProvider))
            {
                return supportedProvider;
            }
            return Constants.Unknown;
        }
    }
}