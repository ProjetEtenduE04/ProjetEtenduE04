using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class BackupService : IBackupService
    {

        private readonly CliniqueDbContext _cliniqueDbContext;

        public BackupService(CliniqueDbContext cliniqueDbContext)
        {
            _cliniqueDbContext = cliniqueDbContext;
        }

        /// <summary>
        /// Obtenir le nom du fichier de sauvegarde
        /// </summary>
        /// <returns> retourne le nom du fichier de sauvegarde</returns>
        private string GetBackupFileName()
        {
            return $"C:\\backup\\Clinique2000_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
        }

        /// <summary>
        ///  Définir la requête de sauvegarde à l'aide d'une instruction paramétrée
        ///  
        /// </summary>
        /// <returns> retourne la requête de sauvegarde</returns>
        private string GetBackUpQuery()
        {
            return $@"
                    USE E04;
                    DECLARE @backupFileName NVARCHAR(MAX) = @fileName;
                    BACKUP DATABASE [E04] TO DISK = @backupFileName;";
        }

        /// <summary>
        /// Générer une BackUp de la base de données
        /// </summary>
        public async Task BackupDatabaseAsync()
        {

            // Obtenir la connexion à partir de DbContext
            var connection = _cliniqueDbContext.Database.GetDbConnection();

            // S'assurer que la connexion est ouverte
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            // Créer un objet de commande avec la requête paramétrée
            using (var command = connection.CreateCommand())
            {
                command.CommandText = GetBackUpQuery();

                // Ajouter le paramètre pour le nom du fichier de sauvegarde
                var parameter = command.CreateParameter();
                parameter.ParameterName = "@fileName";
                parameter.Value = GetBackupFileName();
                command.Parameters.Add(parameter);

                // Exécuter la commande de BackUp
                await command.ExecuteNonQueryAsync();

            }
            
        }
    }
}
