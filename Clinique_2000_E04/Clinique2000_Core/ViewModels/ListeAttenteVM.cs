using Clinique2000_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.ViewModels
{
    public class ListeAttenteVM
    {
        public ListeAttente ListeAttente { get; set; }
        public List<PlageHoraire>? PlagesHoraires { get; set; }
    }


}
