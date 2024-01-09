using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public abstract class Personne
    {
        [Key]
        public int PersonneId { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 25 caractères.")]
        public string Nom { get;set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Ce champ doit avoir entre 2 et 25 caractères.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [MinLength(7, ErrorMessage = "Ce champ doit avoir au moins 7 caractères.")]
        public string Courriel { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "Ce champ doit avoir entre 0 et 25 caractères.")]


        public string Genre { get; set; }

    }
}
