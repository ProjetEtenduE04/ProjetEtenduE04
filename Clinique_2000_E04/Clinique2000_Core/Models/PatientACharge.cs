using Clinique2000_Utility.CustomAttributesValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinique2000_Core.Models
{
    public class PatientACharge
    {
        [Key]
        public int PatientAChargeId { get; set; }


        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 25 caractères.")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\-]+$", ErrorMessage = "Ce champ ne peut contenir que des lettres, des caractères avec accent diacritic ou le tiret (-).")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 25 caractères.")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\-]+$", ErrorMessage = "Ce champ ne peut contenir que des lettres, des caractères avec accent diacritic ou le tiret (-).")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public string? Genre { get; set; }


        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [RegularExpression(@"^[A-Z]{4} \d{4} \d{4}$", ErrorMessage = "Le format NAM n'est pas valide.(Ex:ABCD 1234 5678)")]
        [StringLength(14, ErrorMessage = "Ce champ doit avoir au maximum 12 caractères.")]
        public string NAM { get; set; }


        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateDeNaissance { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public int Age { get; set; }

        [ForeignKey("PatientId")]
        [ValidateNever]
        public int PatientId { get; set; }

        [ValidateNever]
        public virtual Patient Patient { get; set; }

        [ValidateNever]
        public virtual List<Consultation>? ConsultationsPAC { get; set; }




    }
}
