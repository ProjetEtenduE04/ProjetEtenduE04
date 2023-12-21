using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace Clinique2000_Core.Models
{
    public class ListeAttente
    {
        [Key]
        public int ListeAttenteID { get; set; }

        public bool IsOuverte { get; set; }


        [Display(Name = "Date d'effectivité")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Date)]
        public DateTime DateEffectivite { get; set; }


        [Display(Name = "Heure de fermeture")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Time)]
        public TimeSpan HeureOuverture { get; set; }


        [Display(Name = "Heure d'ouverture")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Time)]
        public TimeSpan HeureFermeture { get; set; }


        [Display(Name = "Nombre de médecins disponibles")]
        [Required(ErrorMessage= "Ce champ est obligatoire.")]
        public int NbMedecinsDispo { get; set; }


        public int? dureeConsultationMinutes { get; set; }

        [ValidateNever]
        [Display(Name = "Clinique")]
        [ForeignKey("CliniqueID")]
        public int CliniqueID { get; set; }
        public virtual Clinique Clinique { get; set; }

        //Propiete de navigation
        [ValidateNever]
        public virtual List<PlageHoraire> PlagesHoraires { get; set; }

        
        


      


    }
}
