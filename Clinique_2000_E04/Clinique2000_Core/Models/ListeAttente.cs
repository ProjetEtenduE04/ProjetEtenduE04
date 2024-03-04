using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace Clinique2000_Core.Models
{
   
    public class ListeAttente
    {
        [Key]
        public int ListeAttenteID { get; set; }

        public bool IsOuverte { get; set; } = false;


        [Display(Name = "Date d'effectivité")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Date)]
        [MyDate(ErrorMessage = "Date invalide")]

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
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [Range(minimum:1, maximum:int.MaxValue,ErrorMessage ="Veuillez entrer un nombre de medecins valide.")]
        public int NbMedecinsDispo { get; set; }


        //public int? DureeConsultationMinutes { get; set; }



        //Propietes de navigation
   
        [Display(Name = "Clinique")]
        [ValidateNever]
        [ForeignKey("CliniqueID")]
        public int CliniqueID { get; set; }

        [ValidateNever]
        public virtual Clinique? Clinique { get; set; }


        [ValidateNever]
        public virtual List<PlageHoraire>? PlagesHoraires { get; set; }

        [ValidateNever]
        public virtual List<Consultation>? Consultations { get; set; }
    }













    public class MyDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            DateTime d = Convert.ToDateTime(value);
            return d.AddDays(1) >= DateTime.Now; //Dates Greater than or equal to today are valid (true)

        }
    }



}
