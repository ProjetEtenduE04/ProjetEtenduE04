using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Utility.Enum
{
    public enum StatutConsultation
    {
        Termine,//lorsque medecin appuie sur bouton pour signaler que Consultation est fini
        EnCours, // le patient est dns la salle avec le médecin, le medecin a signalé le debut de la consultation
        EnAttente, //Le patient attend de voir le medecin   
        EnRetard, // le patient est en retard
        Annulle, // le patient a annullé son rdv
        Refuse,//il n'y avait pas de plageHoraireDispo lorsque le client a tenté de reserver une consultation
        DisponiblePourReservation, //la consultation est disponible pour reservation

    }
    public enum EmployeCliniquePosition
    {
        Medecin,
        Receptionniste,
        AdminClinique,
        Autre,

    }

    public enum NotificationTime
    {
        UnJourAvant = 24, // 24 heures avant
        DouzeHeuresAvant = 12, // 12 heures avant
        SixHeuresAvant = 6, // 6 heures avant
        UneHeureAvant = 1 // 1 heure avant
    }

}
