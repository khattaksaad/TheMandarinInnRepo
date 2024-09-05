using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using HotelManager.DAO;
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
            // Call the function to find the .mdf and .ldf files
            //var databaseFiles = FindDatabaseFiles(currentDirectory);

            //Output the result
            


            // Search for .mdf and .ldf files in the directory
            //string[] databaseFiles = Directory.GetFiles(directoryPath, "*.mdf")
            //                        .Concat(Directory.GetFiles(directoryPath, "*.ldf"))
            //                        .ToArray();

            //foreach (string filePath in backuppath)
            //{
                UploadFile(service, backuppath);
            //}
        }

        static void UploadFile(DriveService service, string filePath)
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
                MessageBox.Show($"Uploaded successfully");
            }
            int i = 0;
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
            // Connection string to your SQL Server instance
            string connectionString = DataProvider.GetConnectionStringFromFile();
            // Regular expression to capture the value of initial catalog
            string pattern = @"initial catalog\s*=\s*""([^""]+)""";

            // Find the match using Regex
            Match match = Regex.Match(connectionString, pattern, RegexOptions.IgnoreCase);
            string dbName = match.Groups[1].Value;

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss"); // Format date and time
            string backupFilePath = Path.Combine("C:\\Backup\\", $"TheMandarinInnDB_Backup_{timestamp}.bak");
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
                MessageBox.Show($"Database backed up successfully");
            }
            return backupFilePath;
        }
    }
}
