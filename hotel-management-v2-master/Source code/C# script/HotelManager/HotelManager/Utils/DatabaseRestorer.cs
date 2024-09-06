using HotelManager.Utils;
using System;
using System.Data.SqlClient;

public class DatabaseRestorer
{
    public static void RestoreDatabase(string connectionString, string backupFilePath, string databaseName)
    {
        AppLogger.Instance.LogInformation($"Trying to restore database on <{DateTime.Now}>");
        try
        {
            var query = $@"
            RESTORE DATABASE [{databaseName}] 
            FROM DISK = '{backupFilePath}' 
            WITH REPLACE;
        ";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    AppLogger.Instance.LogInformation($"Database restored successfully on <{DateTime.Now}>");
                }
            }
        }
        catch (Exception ex) {
            AppLogger.Instance.LogError($"Following error occurred while trying to restore database <{ex.Message}>");
        }
    }
}