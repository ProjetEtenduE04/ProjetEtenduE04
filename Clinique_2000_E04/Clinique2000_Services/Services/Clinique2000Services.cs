using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Clinique2000_Services.IServices;
using Google.Apis.Logging;
using Microsoft.Extensions.Configuration;

namespace Clinique2000_Services.Services
{
    public class Clinique2000Services : IClinique2000Services
    {
        public IServices.IListeAttenteService listeAttente { get; private set; }
        public IPatientService patient { get; private set; }
        public IAuthenGoogleService authenGoogle { get; private set; }
        public ICliniqueService clinique { get; private set; }
        public IAdresseService adresse { get; private set; }
        public IConsultationService consultation { get; private set; }
        public IEmployesCliniqueService employesClinique { get; private set; }


        public Clinique2000Services(
            IListeAttenteService listeAttenteService,
            IPatientService patientService,
            IAuthenGoogleService authenGoogleService,
            ICliniqueService cliniqueService,
            IAdresseService adresseService,
            IConsultationService consultationService,
            IEmployesCliniqueService employesCliniqueService
            )
        {
            listeAttente = listeAttenteService;
            patient = patientService;
            authenGoogle = authenGoogleService;
            consultation = consultationService;
            
            clinique = cliniqueService;
            adresse = adresseService;
            employesClinique = employesCliniqueService;
        }
    }
}
