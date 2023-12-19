using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public class PlageHoraire
    {
        public int PlageHoraireID { get; set; }

        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
        public int ListeAttenteID { get; set; }

        //Propiete de navigation
        public ListeAttente? ListeAttente { get; set; }

    }
}
