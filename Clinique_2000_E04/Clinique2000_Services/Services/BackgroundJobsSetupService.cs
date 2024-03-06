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
            var jobKey = JobKey.Create(nameof(EmailService));
            options
                    .AddJob<EmailBackgroundJobService>(jobBuilder => jobBuilder.WithIdentity(jobKey))
                    .AddTrigger(trigger =>
                        trigger
                            .ForJob(jobKey)
                            .WithSimpleSchedule(schedule =>
                            schedule.WithIntervalInMinutes(1).RepeatForever()));
        }
    }
}
