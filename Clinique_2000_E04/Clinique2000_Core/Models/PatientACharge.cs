using System.ComponentModel.DataAnnotations;

namespace Clinique2000_Core.Models
{
    public class PatientACharge : Personne
    {

        public int PatientAChargeId { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [MaxLength(12, ErrorMessage = "Ce champ ne peut pas dépasser 12 caractères.")]
        public string NAM { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public DateTime DateDeNaissance { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public int Age { get; set; }

    }
}
