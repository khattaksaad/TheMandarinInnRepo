using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Google.Apis.Drive.v3.Data;
using Serilog;
using System.Windows.Forms;
namespace HotelManager.Utils
{
    internal class AppLogger
    {
        private static AppLogger _instance;
        private readonly ILogger<AppLogger> _logger;

        // Private constructor to prevent instantiation
        private AppLogger()
        {
            // Configure Serilog
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/app_log.txt", rollingInterval: RollingInterval.Day) // Log to file
                .CreateLogger();
            // Create a LoggerFactory and add Serilog
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddSerilog() // Integrate Serilog with Microsoft.Extensions.Logging
                    .SetMinimumLevel(LogLevel.Debug); // Set minimum log level
            });

            // Create a logger instance
            _logger = loggerFactory.CreateLogger<AppLogger>();

        }

        // Get the singleton instance
        public static AppLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppLogger();
                }
                return _instance;
            }
        }

        // Expose logger methods
        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(string message, Exception ex = null)
        {
            if (ex == null)
            {
                _logger.LogError(message);
            }
            else
            {
                _logger.LogError(ex, message);
            }
        }
    }
}
