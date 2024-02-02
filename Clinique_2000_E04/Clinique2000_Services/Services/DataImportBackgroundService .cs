//using Clinique2000_DataAccess.Data;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Clinique2000_Services.Services
//{
//    public class DataImportBackgroundService : BackgroundService
//    {
//        private readonly IServiceProvider _serviceProvider;
//        private readonly string _filePath;

//        public DataImportBackgroundService(IServiceProvider serviceProvider, string filePath)
//        {
//            _serviceProvider = serviceProvider;
//            _filePath = filePath;
//        }

//        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            using (var scope = _serviceProvider.CreateScope())
//            {
//                var dataImportService = scope.ServiceProvider.GetRequiredService<DataImportService>();
//                if (await dataImportService.ShouldImportDataAsync())
//                {
//                    await dataImportService.ImporterDonneesDuFichierCSVasync(_filePath);
//                }
//            }
//        }
//    }
//}
