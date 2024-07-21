using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Utils
{
    public class DirectoryHelper
    {
        public static void ClearDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                // Delete all files in the directory
                foreach (var file in Directory.GetFiles(directoryPath))
                {
                    File.Delete(file);
                }

                // Delete all subdirectories and their contents
                foreach (var directory in Directory.GetDirectories(directoryPath))
                {
                    Directory.Delete(directory, true); // true = recursive delete
                }
            }
            else
            {
                throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");
            }
        }
        // Copies files and directories from source to destination recursively
        public static void CopyDirectory(string sourceDir, string destDir)
        {
            // Ensure the destination directory exists
            Directory.CreateDirectory(destDir);

            // Copy all files from source to destination
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destDir, fileName);
                File.Copy(file, destFile, true); // true = overwrite if exists
            }

            // Recursively copy all subdirectories
            foreach (var subDir in Directory.GetDirectories(sourceDir))
            {
                string subDirName = Path.GetFileName(subDir);
                string destSubDir = Path.Combine(destDir, subDirName);
                CopyDirectory(subDir, destSubDir);
            }
        }
    }
}
