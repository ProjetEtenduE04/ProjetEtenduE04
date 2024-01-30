using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clinique2000_Core.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_Utility;

using Clinique2000_Utility.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace Clinique2000_Core.Models
{
    public class Consultation
    {
        [Key]
        public int ConsultationID { get; set; }

        //[Display(Name = "Date et heure prévue")]
        //[Required(ErrorMessage = "Ce champ est obligatoire.")]
        //public DateTime HeureDateDebutPrevue { get; set; }

        //[Display(Name = "Date et heure de fin prévue ")]
        //[Required(ErrorMessage = "Ce champ est obligatoire.")]
        //public DateTime HeureDateFinPrevue { get; set; }                                  


        public DateTime? HeureDateDebutReele { get; set; }

        public DateTime? HeureDateFinReele { get; set; }


        public StatutConsultation StatutConsultation { get; set; } = StatutConsultation.DisponiblePourReservation; 


        //proprietes de navigation
        [ValidateNever]
        [ForeignKey("PlageHoraire")]
        public int? PlageHoraireID { get; set; }
        public virtual PlageHoraire  PlageHorarie { get; set; }

        [ValidateNever]
        [ForeignKey("Patient")]
        public int? PatientID { get; set; }
        public virtual Patient? Patient { get; set; }


        //FK MEDECINID
        //PUBLIC MEDECIN MEDECIN


        //FK PATIENTACHARGEID
        //PUBLIC PATIENTACHARGE PATIENTACHARGE                                                    


    }
}
