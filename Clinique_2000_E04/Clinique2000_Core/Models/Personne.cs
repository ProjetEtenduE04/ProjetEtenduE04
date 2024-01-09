using System.ComponentModel.DataAnnotations;

namespace Clinique2000_Core.Models
{
    public abstract class Personne
    {
        [Key]
        public int PersonneId { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 25 caractères.")]
        [RegularExpression(@"^[A-Za-z]{2}[A-Za-z]*$", ErrorMessage = "Ce champ ne peut contenir que des lettres.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 25 caractères.")]
        [RegularExpression(@"^[A-Za-z]{2}[A-Za-z]*$", ErrorMessage = "Ce champ ne peut contenir que des lettres.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [EmailAddress(ErrorMessage = "Ce champ doit être une adresse email valide.")]
        [MinLength(7, ErrorMessage = "Ce champ doit avoir au moins 7 caractères.")]
        public string Courriel { get; set; }

        public string? Genre { get; set; }

    }
}
