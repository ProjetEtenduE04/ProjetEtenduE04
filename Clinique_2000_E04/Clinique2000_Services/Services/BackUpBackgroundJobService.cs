using Clinique2000_Services.IServices;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    [DisallowConcurrentExecution]
    public class BackUpBackgroundJobService : IJob
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IBackupService _backUpService;

        public BackUpBackgroundJobService(
            ILogger<EmailService> logger,
            IBackupService backUpService
            )
        {
            _logger = logger;
            _backUpService = backUpService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                await _backUpService.BackupDatabaseAsync();
                _logger.LogInformation($"{DateTime.Now}  -> Backup effectué avec succès");
            }
            catch(Exception ex)
            {
                _logger.LogInformation( $"{DateTime.Now}  -> Erreur lors de la sauvegarde de la base de données", ex.Message);
            }
        }
    }
}
