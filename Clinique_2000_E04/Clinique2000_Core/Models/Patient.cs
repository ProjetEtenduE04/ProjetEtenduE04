using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public class Patient:Personne
    {
        
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [MaxLength(225, ErrorMessage = "Ce champ ne peut pas dépasser 12 caractères.")]
        public string NAM { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [MaxLength(225, ErrorMessage = "Ce champ ne peut pas dépasser 7 caractères.")]

        public string CodePostal { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [MaxLength(225, ErrorMessage = "Ce champ ne peut pas dépasser 8 caractères.")]

        public string MotDePasse { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [MaxLength(225, ErrorMessage = "Ce champ ne peut pas dépasser  caractères.")]

        public string MotDePasseConfirmation { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Date)]
        public DateTime DateDeNaissance { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public int Age { get; set; } 

        public virtual List<PatientACharge>? PatientsACharge { get; set; }

        [ForeignKey("Consultation")]
        public int ConsultationId { get; set; }

        public virtual Consultation? consultation { get; set; }
    }

}

