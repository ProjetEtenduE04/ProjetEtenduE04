using Microsoft.Extensions.Options;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class BackgroundJobsSetupService : IConfigureOptions<QuartzOptions>
    {
        /// <summary>
        /// Configure les options Quartz pour la configuration des tâches d'arrière-plan.
        /// </summary>
        /// <param name="options">Les options Quartz à configurer.</param>
        public void Configure(QuartzOptions options)
        {
            var emailJobKey = JobKey.Create(nameof(EmailService));
            options
                    .AddJob<EmailBackgroundJobService>(jobBuilder => jobBuilder.WithIdentity(emailJobKey))
                    .AddTrigger(trigger =>
                        trigger
                            .ForJob(emailJobKey)
                            .WithSimpleSchedule(schedule =>
                            schedule.WithIntervalInMinutes(60).RepeatForever()));

            // Configuration de la tâche de sauvegarde
            var backupJobKey = JobKey.Create(nameof(BackupService));
            options
                    .AddJob<BackUpBackgroundJobService>(jobBuilder => jobBuilder.WithIdentity(backupJobKey))
                    .AddTrigger(trigger =>
                        trigger
                            .ForJob(backupJobKey)
                            .WithSimpleSchedule(schedule =>
                            schedule.WithIntervalInHours(24).RepeatForever()));
        }
    }
}
