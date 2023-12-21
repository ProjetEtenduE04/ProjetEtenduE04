using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public  class Clinique
    {
        [Key]
        public int CliniqueID { get; set; }

        [Display(Name = "Temps Moyen de Consultation")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        
        public  int TempsMoyenConsultation { get; set; }

        [ValidateNever]
        public virtual List<ListeAttente>? ListeAttente { get; set; }
    }
}
