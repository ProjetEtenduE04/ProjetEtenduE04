using Clinique2000_Utility.CustomAttributesValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Clinique2000_Core.Models
{
    //[MetadataType(typeof(Patient))]
    //public partial class PatientMeta
    //{
    //}

    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 25 caractères.")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\-]+$", ErrorMessage = "Ce champ ne peut contenir que des lettres, des caractères avec accent diacritic ou le tiret (-).")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 25 caractères.")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\-]+$", ErrorMessage = "Ce champ ne peut contenir que des lettres, des caractères avec accent diacritic ou le tiret (-).")]
        public string Prenom { get; set; }

        public string? Genre { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [RegularExpression(@"^[A-Z]{4} \d{4} \d{4}$", ErrorMessage = "Le format NAM n'est pas valide.(Ex:ABCD 1234 5678)")]
        [StringLength(14, ErrorMessage = "Ce champ doit avoir au maximum 12 caractères.")]
        public string NAM { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$", ErrorMessage = "Le format du code postal n'est pas valide (Ex: A1A 1A1).")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Ce champ doit avoir exactement 7 caractères.")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [ValiderDateDeNaissance(ErrorMessage = "{0} field validation failed.")]
        public DateTime DateDeNaissance { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public int Age { get; set; }

        //public double Latitude { get; set; }

        //public double Longitude { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public string UserId { get; set; }
       
        [ValidateNever]
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public virtual List<PatientACharge>? PatientsACharge { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public virtual List<Consultation>? Consultations { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public virtual List<Critique>? Critiques { get; set; }



    }
}
