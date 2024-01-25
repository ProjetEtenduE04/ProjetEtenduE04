using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public class Adresse
    {
        [Key]
        public int AdresseID { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Ce champ doit avoir entre 1 et 10 caractères.")]
        [Display(Name = "Numéro")]
        public string? Numero { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Ce champ doit avoir entre 3 et 25 caractères.")]
        [Display(Name = "Rue")]
        public string Rue { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Ce champ doit avoir entre 3 et 25 caractères.")]
        [Display(Name = "Ville")]
        public string Ville { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Ce champ doit avoir entre 3 et 25 caractères.")]
        [Display(Name = "Province")]
        public string? Province { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Ce champ doit avoir entre 3 et 25 caractères.")]
        [Display(Name = "Pays")]
        public string? Pays { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$", ErrorMessage = "Le format du code postal n'est pas valide (Ex: A1A 1A1).")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Ce champ doit avoir exactement 7 caractères.")]
        public string CodePostal { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [ValidateNever]
        public virtual Clinique Clinique { get; set; }
    }
}
