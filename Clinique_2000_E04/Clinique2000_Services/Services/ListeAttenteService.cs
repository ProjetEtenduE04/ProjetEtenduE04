using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Core.Models;
namespace Clinique2000_Services.Services
{
    public class ListeAttenteService : ServiceBaseAsync<ListeAttente>, IListeAttenteService
    {
        private IList<string> medecins = new List<string>();

        private TimeSpan HeureFinClinique;
        private TimeSpan HeureDebutClinique;

        public ListeAttenteService(CliniqueDbContext dbContext) : base(dbContext)
        {
            HeureDebutClinique = new TimeSpan(8, 30, 0);//8:00 am 
            HeureFinClinique = new TimeSpan(17, 45, 0);//5:45 pm 
            int plageHoraireMinutes = (int)(HeureFinClinique - HeureDebutClinique).TotalMinutes;
        }


        /// <summary>
        /// Creation d'une class medecin provissoire avec creation des certains medecins 
        /// </summary>
        private class Medecin
        {

            public bool Disponible { get; set; }
            public string Nom { get; set; }
            public TimeSpan HeureDebut { get; set; }
            public TimeSpan HeureDeFin { get; set; }
            
           

        }


        List<Medecin> medecinsDispo = new List<Medecin>
        {
            new Medecin { Nom = "Médico 1", Disponible = true, HeureDebut= new TimeSpan (8,0,0), HeureDeFin = new TimeSpan(12,0,0) },
            new Medecin { Nom = "Médico 2", Disponible = true, HeureDebut= new TimeSpan (8,0,0), HeureDeFin = new TimeSpan(12,0,0)  },
            new Medecin { Nom = "Médico 3", Disponible = true, HeureDebut = new TimeSpan(8, 0, 0), HeureDeFin = new TimeSpan(12, 0, 0) },
            new Medecin { Nom = "Médico 4", Disponible = true, HeureDebut= new TimeSpan(8,0,0), HeureDeFin = new TimeSpan(12,0,0) },

            new Medecin { Nom = "Médico 5", Disponible = true, HeureDebut = new TimeSpan(8, 0, 0), HeureDeFin = new TimeSpan(12, 0, 0)  },
            new Medecin { Nom = "Médico 6", Disponible = true, HeureDebut = new TimeSpan(8, 0, 0), HeureDeFin = new TimeSpan(12, 0, 0) },
            new Medecin { Nom = "Médico 7", Disponible = true, HeureDebut = new TimeSpan(8, 0, 0), HeureDeFin = new TimeSpan(12, 0, 0) },
            new Medecin { Nom = "Médico 8", Disponible = true, HeureDebut = new TimeSpan(8, 0, 0), HeureDeFin = new TimeSpan(12, 0, 0) }

        };


        int dureeMoyenneConsulteMinutes = 30;
        int numeroPacientesEsperados = 10;

        private class Calendrier
        {
            public int ID { get; set; }
            public DateTime Date { get; set; }
            public string Descripcion { get; set; }
        }

        private class PlagesHoraires
        {
            public int ID { get; set; }
            public int IDMedico { get; set; } // Clave foránea para relacionar con la tabla de Médicos
            public string JourDeLaSemaine { get; set; }
            public TimeSpan HoraInicio { get; set; }
            public TimeSpan HoraFin { get; set; }
        }



        //public List<Medecin> MedecinsDispoJournéeDeListeEffective()
        //{
        //    foreach (var medecin in medecinsDispo)
        //    { if (medecin.Journee< HeureDebutClinique && medecin.HeureDeFin )
            
        //        }
        //    return medecinsDispo;
        
        //}


        //public static async Task<IReadOnlyList<Medecin>> GetMedecinsDispo( int dureeMoyenneParPatient, )
        //{
            
           

        //    // Calcula el horario de la clínica en función de la duración promedio de consulta y el número de pacientes esperados
        //    var minutesParPatient = dureeMoyenneConsulteMinutes;
        //    var minutesTotales = numeroPacientesEsperados * minutosPorPaciente;

        //    // Supongamos que la clínica abre a las 8:00 AM
        //    var horaAperturaClinica = new TimeSpan(8, 0, 0);

        //    foreach (var medico in medecinsDispo)
        //    {
        //        // Establece el horario del médico para el día siguiente
        //        medico.HoraInicio = horaAperturaClinica;
        //        medico.HoraFin = horaAperturaClinica.Add(TimeSpan.FromMinutes(minutosTotales));
        //    }

        //    return medecinsDispo;
        //}


    }
}
