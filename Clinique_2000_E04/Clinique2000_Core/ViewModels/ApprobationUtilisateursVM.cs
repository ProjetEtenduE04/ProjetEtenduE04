using Clinique2000_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.ViewModels
{
    public class ApprobationUtilisateursVM
    {
        // Défini quel type d'utiilisateurs seront manipulés
        public string Param { get; set; }

        // Liste des utilisateurs à approuver
        public List<ApplicationUser> Utilisateurs { get; set; }
    }
}
