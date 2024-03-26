using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.IServices
{
    public interface IBackupService
    {
        /// <summary>
        /// Génère un script pour la sauvegarde de la base de données.
        /// </summary>
        /// <returns>Le chemin vers le fichier de script de sauvegarde généré.</returns>
        string GenerateDatabaseBackupScript();

        /// <summary>
        /// Génère une chaîne de commande BCP pour exporter les données d'une table spécifique.
        /// </summary>
        /// <param name="tableName">Le nom de la table à partir de laquelle exporter les données.</param>
        /// <param name="exportFilePath">Le chemin de fichier où les données exportées doivent être sauvegardées.</param>
        /// <returns>La commande BCP générée pour exporter les données.</returns>
        string GenerateExportCommand(string tableName, string exportFilePath);

        /// <summary>
        /// Exécute une commande BCP spécifiée.
        /// </summary>
        /// <param name="command">La commande BCP à exécuter.</param>
        void ExecuteBcpCommand(string command);



    }
}
