using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public class ListeAttente
    {
        [Key]
        public int ListeAttenteID { get; set; }

        public bool IsOuverte { get; set; }


        [Display(Name = "Date d'effectivité")]
        [Required(ErrorMessage ="Veuillez entrer une date d'effectivité pour la liste d'attente")]
        [DataType(DataType.Date)]
        public DateTime DateEffectivite { get; set; }


        [Display(Name = "Heure de fermeture")]
        [Required(ErrorMessage = "Veuillez entrer l'heure d'ouverture de la liste d'attente")]
        [DataType(DataType.Time)]
        public DateTime HeureOuverture { get; set; }


        [Display(Name = "Heure d'ouverture")]
        [Required(ErrorMessage = "Veuillez entrer l'heure de fermeture de la liste d'attente")]
        [DataType(DataType.Time)]
        public DateTime HeureFermeture { get; set; }


        [Display(Name = "Nombre de médecins disponibles")]
        [Required(ErrorMessage="Veillez entrer le nombre de médecins disponibles")]
        public int NbMedecinsDispo { get; set; }




        ////proprietes de naviguation

        //public List<Consultation> Consultations { get; set; }

        //[ForeignKey(Clinique)]
        //public int CliniqueID { get; set; }
        //public Clinique Clinique { get; set; }


    }
}
