using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Quartz.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clinique2000_Services.Services
{
    public class BackupService : IBackupService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<BackupService> _logger;

        public BackupService(IWebHostEnvironment environment, ILogger<BackupService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public string GenerateDatabaseBackupScript()
        {
            // Set a server-side path to store the backup file
            string backupDirectory = Path.Combine(_environment.ContentRootPath, "App_Data");

            // Ensure the directory exists
            if (!Directory.Exists(backupDirectory))
            {
                Directory.CreateDirectory(backupDirectory);
            }

            string backupFileName = $"backup_{DateTime.Now:yyyyMMddHHmmss}.sql";
            string fullPath = Path.Combine(backupDirectory, backupFileName);

            // Set your database connection details
            string sqlCommand = $"sqlcmd -S .\\SQLEXPRESS -d E04 -E -Q \"EXEC sp_backupDatabase @BackupPath='{fullPath}'\"";

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c {sqlCommand}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true, // Add this line to redirect standard error
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    // Read both standard output and standard error
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd(); // Now you can read from standard error without error

                    process.WaitForExit();

                    // Handle the output and error strings
                    Console.WriteLine($"Output: {output}");
                    if (!string.IsNullOrEmpty(error))
                    {
                        Console.WriteLine($"Error: {error}");
                    }
                }

                // Verify the backup file is created
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
                else
                {
                    // Handle the error or throw an exception
                    throw new FileNotFoundException($"Backup file was not created at the expected location: {fullPath}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception and handle it
                // Depending on your logging framework, log the exception here
                throw; // Rethrow the exception to be handled elsewhere or log it as needed
            }
        }


        private string serverName = ".\\SQLEXPRESS"; // Update with your actual server name
        private string databaseName = "YourDatabaseName"; // Update with your actual database name
        private string trustedConnection = "-T"; // Use "-U username -P password" for SQL authentication if necessary


        // Generates a BCP command for exporting data from a table to a CSV file
        public string GenerateExportCommand(string tableName, string exportFilePath)
        {
            return $"bcp {databaseName}.dbo.{tableName} out \"{exportFilePath}\" -c -t, {trustedConnection} -S {serverName}";
        }


        public void ExecuteBcpCommand(string command)
        {
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true, // Enable redirection of standard error
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (System.Diagnostics.Process proc = new System.Diagnostics.Process { StartInfo = procStartInfo })
            {
                try
                {
                    proc.Start();

                    // Asynchronously read the standard output and standard error
                    var outputTask = proc.StandardOutput.ReadToEndAsync();
                    var errorTask = proc.StandardError.ReadToEndAsync();

                    // Wait for the BCP command to complete execution
                    proc.WaitForExit();

                    // Await the asynchronous tasks for output and error
                    string output = outputTask.Result;
                    string error = errorTask.Result;

                    if (!string.IsNullOrEmpty(output))
                    {
                        _logger.LogInformation($"BCP Command Output: {output}");
                    }

                    if (!string.IsNullOrEmpty(error))
                    {
                        _logger.LogError($"BCP Command Error: {error}");
                    }

                    // Optionally, check the exit code to determine if the command was successful
                    if (proc.ExitCode != 0)
                    {
                        _logger.LogError($"BCP command exited with code {proc.ExitCode}");
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception if starting the process fails
                    _logger.LogError(ex, "Failed to execute BCP command.");
                }
            }
        }
    

    } 
}
