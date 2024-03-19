using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clinique2000_Core.Models
{
    public class Clinique
    {
        [Key]
        public int CliniqueID { get; set; }

        [Display(Name = "Nom de la Clinique")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 25 caractères.")]
        public string NomClinique { get; set; }

        [Display(Name = "Courriel")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [EmailAddress(ErrorMessage = "Le format du courriel n'est pas valide.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 50 caractères.")]
        public string? Courriel { get; set; }

        [Display(Name = "Heure d'ouverture")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan? HeureOuverture { get; set; }

        [Display(Name = "Heure de fermeture")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan? HeureFermeture { get; set; }

        [Display(Name = "Temps Moyen de Consultation")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        public  int TempsMoyenConsultation { get; set; }

        [Display(Name = "Numéro de Téléphone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Le format du numéro de téléphone n'est pas valide. Utilisez le format (xxx) xxx-xxxx.")]
        public string? NumTelephone { get; set; }

        [Display(Name = "Est Active")]
        public bool EstActive { get; set; } = true;

        [Display(Name = "Date de Création")]
        [DataType(DataType.DateTime)]
        public DateTime? DateCreation { get; set; } = DateTime.Now;

        [Display(Name = "Date de Modification")]
        [DataType(DataType.DateTime)]
        public DateTime? DateModification { get; set; }

        [ValidateNever]
        public virtual List<ListeAttente>? ListeAttente { get; set; }

        [Display(Name = "Adresse")]
        public int AdresseID { get; set; }

        [ValidateNever]
        public virtual Adresse? Adresse { get; set; }

        [ForeignKey("Createur")]
        public string CreateurID { get; set; }

        [ValidateNever]
        public virtual ApplicationUser Createur { get; set; }

       
        [ValidateNever]
        public virtual ICollection<EmployesClinique> EmployesCliniques { get; set; }

        [Display(Name = "Est Approuvée")]
        public bool EstApprouvee { get; set; }

        [ValidateNever]
        public virtual ICollection<Critique> Critique { get; set; }


        [Display(Name = "Heure de début de la pause")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan? HeurePauseDebut { get; set; }

        [Display(Name = "Heure de fin de la pause")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan? HeurePauseFin { get; set; }
    }
}