namespace DTDatabaseEntry.Services
{
    public interface IDTDatabase
    {
        /// <summary>
        /// Retrieves the type of database being used by the Acumatica instance.
        /// </summary>
        /// <returns>A string representing the database type.</returns>
        string GetDBType();

        /// <summary>
        /// Executes the given SQL script and returns the result as a string.
        /// </summary>
        /// <param name="type">The type of script execution context.</param>
        /// <param name="sql">The SQL query to be executed.</param>
        /// <returns>The result of the SQL execution as a string.</returns>
        string ExecuteString(string type, string sql);
    }
}