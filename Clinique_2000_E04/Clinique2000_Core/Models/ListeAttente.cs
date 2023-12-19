using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public class ListeAttente
    {
        [Key]
        public int ListeAttenteID { get; set; }

        public bool IsDisponible { get; set; }

        public DateTime DateEffectivite { get; set; }

        public DateTime HeureOuverture { get; set; }

        public DateTime HeureFermeture { get; set; }

        public int NbMedecinsDispo { get; set; }

        ////proprietes de naviguation

        //public List<Consultation> Consultations { get; set; }

        //[ForeignKey(Clinique)]
        //public int CliniqueID { get; set; }
        //public Clinique Clinique { get; set; }


    }
}
