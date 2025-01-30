using System;
using System.Collections.Generic;
using PX.Data;
using PX.MySql;

namespace DTDatabaseEntry.Descriptor
{
    public static class DTConstants
    {
        public const string Unknown = "Unknown";
        public const string MySQL = "MySQL";
        public const string MSSQL = "MS SQL";

        public static readonly Dictionary<Type, string> SupportedProvidersName = new Dictionary<Type, string>
        {
            {
                typeof(MySqlDatabaseProvider), MySQL
            },
            {
                typeof(MsSqlDatabaseProvider), MSSQL
            }
        };
    }
}