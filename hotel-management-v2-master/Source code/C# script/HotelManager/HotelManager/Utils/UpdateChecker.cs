using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using System.IO.Compression;
using System.Runtime.Remoting.Lifetime;
namespace HotelManager.Utils
{
    public class UpdateChecker
    {
        private const string LatestReleaseUrl = "https://api.github.com/repos/khattaksaad/TheMandarinInnRepo/releases/latest";
        private const string GitHubToken = "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"; // Replace with your token
        private const string DownloadPath = "C:\\Users\\skhan\\Downloads\\New folder\\TheMandarinInn.zip";
        private const string ExtractPath = "C:\\Application\\The Mandarin Inn\\";
        public static async Task CheckForUpdates()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "request");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GitHubToken);
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", GitHubToken);

                    HttpResponseMessage response = await client.GetAsync(LatestReleaseUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var release = JsonConvert.DeserializeObject<GitHubRelease>(json);

                        string remoteVersion = release.tag_name;
                        string localVersion = Application.ProductVersion;

                        if (remoteVersion != localVersion)
                        {
                            DialogResult result = MessageBox.Show("A new version is available. Do you want to download it?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result == DialogResult.Yes)
                            {
                                //System.Diagnostics.Process.Start(release.assets[0].browser_download_url);
                                DownloadAndInstallUpdate(release.assets[0].browser_download_url);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error checking for updates: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking for updates: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private static async Task DownloadAndInstallUpdate(string downloadUrl)
        {
            try
            {
                //download it to the downloads folder
                //System.Diagnostics.Process.Start(downloadUrl);


                if (Directory.Exists(ExtractPath))
                {
                    // Clear the directory contents without deleting the directory itself
                    DirectoryHelper.ClearDirectory(ExtractPath);
                }
                else
                {
                    // Create the directory if it doesn't exist
                    Directory.CreateDirectory(ExtractPath);
                }

                //                ZipArchive
                ZipFile.ExtractToDirectory(DownloadPath, ExtractPath);

                // Copy extracted files to the application directory (ensure you handle file overwrites safely)
                string sourceDirectory = Path.Combine(Directory.GetCurrentDirectory(), ExtractPath);
                string targetDirectory = Directory.GetCurrentDirectory();

                DirectoryHelper.CopyDirectory(sourceDirectory, targetDirectory);

                MessageBox.Show("Update completed. Please restart the application.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error installing updates: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private class GitHubRelease
        {
            public string tag_name { get; set; }
            public GitHubAsset[] assets { get; set; }
        }

        private class GitHubAsset
        {
            public string browser_download_url { get; set; }
        }
    }
}
