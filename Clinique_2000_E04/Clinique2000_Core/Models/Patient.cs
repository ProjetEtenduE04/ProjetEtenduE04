using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Clinique2000_Core;
using Clinique2000_Utility.CustomAttributesValidation;


namespace Clinique2000_Core.Models
{

    [MetadataType(typeof(Patient))]
    public partial class PatientMeta
    {
    }

    public class Patient : Personne
    {
        
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [RegularExpression(@"^[A-Z]{4}\d{8}$", ErrorMessage = "Le format NAM n'est pas valide.(Ex:ABCD12345678)")]
        [StringLength(12, ErrorMessage = "Ce champ doit avoir au maximum 12 caractères.")]
        public string NAM { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$", ErrorMessage = "Le format du code postal n'est pas valide (Ex: A1A 1A1).")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Ce champ doit avoir exactement 7 caractères.")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [MaxLength(225, ErrorMessage = "Ce champ ne peut pas dépasser 8 caractères.")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)[A-Za-z\d]{8,225}$", ErrorMessage = "Ce champ doit contenir au moins une lettre, un chiffre et doit avoir entre 8 et 225 caractères.")]
        public string MotDePasse { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [MaxLength(225, ErrorMessage = "Ce champ ne peut pas dépasser  caractères.")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)[A-Za-z\d]{8,225}$", ErrorMessage = "Ce champ doit contenir au moins une lettre, un chiffre et doit avoir entre 8 et 225 caractères.")]
        public string MotDePasseConfirmation { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [ValiderDateDeNaissance(ErrorMessage = "{0} field validation failed.")]
        public DateTime DateDeNaissance { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public int Age { get; set; }

        [ValidateNever]
        public virtual List<PatientACharge>? PatientsACharge { get; set; }
    }
}

