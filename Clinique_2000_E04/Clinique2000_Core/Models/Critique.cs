using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public class Critique
    {
        [Key]
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "Le titre de l'avis est obligatoire.")]
        public string Titre { get; set; }

        [Required(ErrorMessage = "Le texte de l'avis est obligatoire.")]
        public string Texte { get; set; }

        [Required(ErrorMessage = "La note est obligatoire.")]
        [Range(1, 5, ErrorMessage = "La note doit être comprise entre 1 et 5.")]
        public int Note { get; set; }

        [Required(ErrorMessage = "L'ID du patient est obligatoire.")]
        public string PatientId { get; set; }

        [ForeignKey("Clinique")]
        public int CliniqueId { get; set; }

        [ValidateNever]
        public virtual Clinique Clinique { get; set; }
    }
}
