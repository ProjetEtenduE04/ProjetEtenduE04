using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.ViewModels
{
    /// <summary>
    /// Contient la liste des objets à approuver
    /// </summary>
    public class ApprobationVM
    {
        // Défini quel type d'objets seront manipulés
        public string Param { get; set; }

        // Liste des cliniques à approuver
        public ApprobationCliniquesVM ApprobationCliniquesVM { get; set; }

        // Liste des utilisateurs à approuver
        public ApprobationUtilisateursVM ApprobationUtilisateursVM { get; set; }
    }
}
