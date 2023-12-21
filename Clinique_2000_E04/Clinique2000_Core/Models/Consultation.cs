using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_Utility;

using Clinique2000_Utility.Enum;


namespace Clinique2000_Core.Models
{
    public class Consultation
    {
        [Key]
        public int ConsultationID { get; set; }

        [Display(Name = "Date et heure prévue")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public DateTime HeureDateDebutPrevue { get; set; }

        [Display(Name = "Date et heure de fin prévue ")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public DateTime HeureDateFinPrevue { get; set; }                                  //


        public DateTime HeureDateDebutReele { get; set; }

        public DateTime HeureDateFinReele { get; set; }


        public StatutConsultation StatutConsultation { get; set; } = StatutConsultation.DisponiblePourReservation; 


        //proprietes de navigation
        [ForeignKey("ListAttente")]
        public int ListeAttenteID { get; set; }

        public virtual ListeAttente ListeAttente { get; set; }


        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }


        //FK MEDECINID
        //PUBLIC MEDECIN MEDECIN


        //FK PATIENTACHARGEID
        //PUBLIC PATIENTACHARGE PATIENTACHARGE                                                      ???????????????????????


    }
}
