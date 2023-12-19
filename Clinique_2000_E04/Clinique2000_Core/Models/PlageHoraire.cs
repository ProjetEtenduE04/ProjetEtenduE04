using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public class PlageHoraire
    {
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
        

        public PlageHoraire(DateTime debut, DateTime fin)
        {
            HeureDebut = debut;
            HeureFin = fin;
            
        }

    }
}
