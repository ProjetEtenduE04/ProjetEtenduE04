using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public class PlageHoraire
    {
        [Key]
        public int PlageHoraireID { get; set; }

        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
        

        //Propiete de navigation
        [ValidateNever]
        [ForeignKey("ListeAttente")]
        public int ListeAttenteID { get; set; }
        public virtual  ListeAttente ListeAttente { get; set; }

        [ValidateNever]
        public virtual List<Consultation> Consultations { get; set; }

    }
}
