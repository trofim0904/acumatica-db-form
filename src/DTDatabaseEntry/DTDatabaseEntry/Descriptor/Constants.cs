using System;
using System.Collections.Generic;
using PX.Data;
using PX.MySql;

namespace DTDatabaseEntry.Descriptor
{
    public static class Constants
    {
        public const string Unknown = "Unknown";

        public static readonly Dictionary<Type, string> SupportedProviders = new Dictionary<Type, string>
        {
            {
                typeof(MySqlDatabaseProvider), "MySql"
            },
            {
                typeof(MsSqlDatabaseProvider), "MS SQL"
            }
        };
    }
}