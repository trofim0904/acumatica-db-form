namespace DTDatabaseEntry.Services
{
    public interface IDTDatabase
    {
        /// <summary>
        /// Retrieves the type of database being used by the Acumatica instance.
        /// </summary>
        /// <returns>A string representing the database type.</returns>
        string GetDBType();
    }
}