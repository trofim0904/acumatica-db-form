using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DTDatabaseEntry.Descriptor;
using DTDatabaseEntry.Models;
using MySqlConnector;
using PX.Common;
using PX.Data;

namespace DTDatabaseEntry.Services
{
    public class DTDatabase : IDTDatabase
    {
        public string GetDBType()
        {
            var provider = PXDatabase.Provider;
            if (DTConstants.SupportedProvidersName.TryGetValue(provider.GetType(), out var supportedProvider))
            {
                return supportedProvider;
            }
            return DTConstants.Unknown;
        }

        public string ExecuteString(string type, string sql)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                var provider = PXDatabase.Provider;
                foreach (var script in sql.Split(';'))
                {
                    if (script.IsNullOrWhiteSpace())
                    {
                        continue;
                    }
                    builder.AppendLine(ExecuteScript(type, script, provider).ToString());
                    builder.AppendLine();
                }
            }
            catch (Exception e)
            {
                builder.AppendLine(e.Message);
                builder.AppendLine(e.StackTrace);
            }
            return builder.ToString();
        }

        private DTScriptResult ExecuteScript(string type, string sql, PXDatabaseProvider provider)
        {
            DTScriptResult result = new DTScriptResult();
            using (var connection = GetConnection(type, provider.GetConnectionString()))
            {
                using (var command = GetCommand(connection, sql))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        var fieldCount = reader.FieldCount;
                        if (fieldCount == 0)
                        {
                            result.RecordsAffected = reader.RecordsAffected;
                            return result;
                        }
                        result.Headers = new List<string>(GetHeaders(reader));
                        if (reader.HasRows)
                        {
                            result.Rows = new List<DTScriptRow>();
                            while (reader.Read())
                            {
                                result.Rows.Add(new DTScriptRow
                                    {
                                        Values = new List<object>(GetValues(reader))
                                    }
                                );
                            }
                        }
                    }
                }
            }
            return result;
        }

        private static IEnumerable<object> GetValues(DbDataReader reader)
        {
            return Enumerable.Range(0, reader.FieldCount).Select(reader.GetValue);
        }

        private static IEnumerable<string> GetHeaders(DbDataReader reader)
        {
            return Enumerable.Range(0, reader.FieldCount).Select(reader.GetName);
        }

        private DbConnection GetConnection(string type, string connectionString)
        {
            switch (type)
            {
                case DTConstants.MSSQL:
                    return new SqlConnection(connectionString);
                case DTConstants.MySQL:
                    return new MySqlConnection(connectionString);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }

        private DbCommand GetCommand(DbConnection connection, string sql)
        {
            switch (connection)
            {
                case SqlConnection sqlConnection:
                    return new SqlCommand(sql, sqlConnection);
                case MySqlConnection mySqlConnection:
                    return new MySqlCommand(sql, mySqlConnection);
                default:
                    throw new ArgumentOutOfRangeException(nameof(connection));
            }
        }
    }
}