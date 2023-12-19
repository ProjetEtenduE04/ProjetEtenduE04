using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public class PatientACharge:Personne
    {
        
        public int PatientAChargeId { get;set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [MaxLength(12, ErrorMessage = "Ce champ ne peut pas dépasser 12 caractères.")]
        public string NAM { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public DateTime DateDeNaissance { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public int Age { get; set; }

    }
}
