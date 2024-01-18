using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public class Clinique
    {
        [Key]
        public int CliniqueID { get; set; }

        [Display(Name = "Nom de la Clinique")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 25 caractères.")]
        public string NomClinique { get; set; }

        [Display(Name = "Courriel")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [EmailAddress(ErrorMessage = "Le format du courriel n'est pas valide.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 50 caractères.")]
        public string? Courriel { get; set; }

        [Display(Name = "Heure d'ouverture")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Time)]
        public TimeSpan? HeureOuverture { get; set; }

        [Display(Name = "Heure de fermeture")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Time)]
        public TimeSpan? HeureFermeture { get; set; }

        [Display(Name = "Temps Moyen de Consultation")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public  int TempsMoyenConsultation { get; set; }

        [Display(Name = "Est Active")]
        public bool EstActive { get; set; } = false;

        [ValidateNever]
        public virtual List<ListeAttente>? ListeAttente { get; set; }


        [Display(Name = "Adresse")]
        public int AdresseID { get; set; }

        [ValidateNever]
        public virtual Adresse? Adresse { get; set; }
    }
}
