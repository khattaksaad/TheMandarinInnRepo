using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using HotelManager.DAO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager.Utils
{
    internal static class GDriveUploadHelper

    {
        static string[] Scopes = { DriveService.Scope.DriveFile };
        static string ApplicationName = "Google Drive API .NET Upload";
        public static void DoMagic(string userName)
        {

            // Load the service account credentials from the JSON file
            GoogleCredential credential;
            using (var stream = new FileStream("themandarininndb-50e71ed35ab0.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                               .CreateScoped(DriveService.Scope.DriveFile);
            }

            // Create Google Drive API service
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });


            UploadDatabaseFilesToDrive(service, userName);
        }
        static void UploadDatabaseFilesToDrive(DriveService service, string userName)
        {
            // Get the current directory where the project is running from
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Specify an alternative directory (e.g., TempPath)
            string tempPath = StaticValues.GetPath4User(userName);  // You can customize this to any path
            string backuppath = BackupDatabase();
                UploadFile(service, backuppath);
        }

        static void UploadFile(DriveService service, string filePath)
        {

        AppLogger.Instance.LogInformation("UploadFile called");
            try
            {
                // Define file metadata
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(filePath),
                    Parents = new List<string> { "1-At-XUex1GuHbvXeTvurhGCXSzxaXU_o" } // Replace with the ID of the folder shared with the service account
                };

                // Upload file
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    var request = service.Files.Create(fileMetadata, stream, GetMimeType(filePath));
                    request.Fields = "id";
                    var progress = request.Upload();
                    var file = request.ResponseBody;
                    //Console.WriteLine($"Uploaded {filePath} with File ID: {file.Id}");
                    MessageBox.Show("Information", "Uploaded successfully");
                    AppLogger.Instance.LogInformation("Backup file uploaded successfully");
                }
            }
            catch (Exception ex) {
                AppLogger.Instance.LogError($"Following error occurred while trying to upload database backup to gdrive <{ex.Message}>");

            }
        }
        static string GetMimeType(string fileName)
        {
            string mimeType = "application/octet-stream";
            string extension = Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(extension);
            if (registryKey != null && registryKey.GetValue("Content Type") != null)
                mimeType = registryKey.GetValue("Content Type").ToString();
            return mimeType;
        }
        static string BackupDatabase()
        {
            AppLogger.Instance.LogInformation("Backup database called");
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss"); // Format date and time
            string backupFilePath = Path.Combine("C:\\Backup\\", $"TheMandarinInnDB_Backup_{timestamp}.bak");
            try
            {
                // Connection string to your SQL Server instance
                string connectionString = DataProvider.GetConnectionStringFromFile();
                // Regular expression to capture the value of initial catalog
                string pattern = @"initial catalog\s*=\s*""([^""]+)""";

                // Find the match using Regex
                Match match = Regex.Match(connectionString, pattern, RegexOptions.IgnoreCase);
                string dbName = match.Groups[1].Value;

                // SQL command to backup the database
                string query = $@"
            BACKUP DATABASE [{dbName}] 
            TO DISK = '{backupFilePath}' 
            WITH INIT;
        ";
                //string backUpPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbName);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    AppLogger.Instance.LogInformation("Backup file created successfully");
                    MessageBox.Show("Information","Database backed up successfully");
                }
            }
            catch(Exception ex) {
                AppLogger.Instance.LogError($"Following error occurred while trying to create database backup <{ex.Message}>");

            }
            return backupFilePath;
        }
    }
}
