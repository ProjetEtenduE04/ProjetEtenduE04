using Clinique2000_Utility.CustomAttributesValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinique2000_Core.Models
{
    public class PatientACharge
    {
        [Key]
        public int PatientAChargeId { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 25 caractères.")]
        [RegularExpression(@"^[A-Za-z]{2}[A-Za-z]*$", ErrorMessage = "Ce champ ne peut contenir que des lettres.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 25 caractères.")]
        [RegularExpression(@"^[A-Za-z]{2}[A-Za-z]*$", ErrorMessage = "Ce champ ne peut contenir que des lettres.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [MaxLength(12, ErrorMessage = "Ce champ ne peut pas dépasser 12 caractères.")]
        public string NAM { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [ValiderDateDeNaissance(ErrorMessage = "{0} field validation failed.")]
        public DateTime DateDeNaissance { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public int Age { get; set; }

        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

    }
}
