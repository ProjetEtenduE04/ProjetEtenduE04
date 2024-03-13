using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Utility.Enum
{

    public enum MotifRendezVousMedical
    {
        [Display(Name = "Examen de routine")]
        ExamenRoutine,

        [Display(Name = "Douleur / Disconfort")]
        DouleurDisconfort,

        [Display(Name = "Problème respiratoire")]
        ProblemeRespiratoire,

        [Display(Name = "Problème digestif")]
        ProblemeDigestif,

        [Display(Name = "Blessure / Traumatisme")]
        BlessureTraumatisme,

        [Display(Name = "Suivi d'une maladie chronique")]
        SuiviMaladieChronique,

        [Display(Name = "Consultation préventive")]
        ConsultationPreventive,

        [Display(Name = "Autre")]
        Autre
    }
    
}
