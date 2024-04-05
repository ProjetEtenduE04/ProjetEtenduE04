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
        public IEmailService email { get; private set; }
        public IAdminService admin { get; private set; }
        public IPatientAchargeService patientAcharge { get; private set; }
        public IBackupService backup { get; private set; }
        public ISMSService sms { get; private set; }
        public IAPIService api { get; private set; }
        public IAPIKeyService apiKey { get; private set; }
        private IApiKeyAuthenticationService apiKeyAuthenticationService;
        


        public Clinique2000Services(
            IListeAttenteService listeAttenteService,
            IPatientService patientService,
            IAuthenGoogleService authenGoogleService,
            ICliniqueService cliniqueService,
            IAdresseService adresseService,
            IConsultationService consultationService,
            IEmployesCliniqueService employesCliniqueService,
            IEmailService emailService,
            IAdminService adminService,
            IPatientAchargeService patientAchargeService,
            IBackupService backup,
            IAPIService apiService,
            IAPIKeyService apiKeyService,
            IApiKeyAuthenticationService apiKeyAuthenticationService,
            ISMSService sMSService
            )
        {
            listeAttente = listeAttenteService;
            patient = patientService;
            authenGoogle = authenGoogleService;
            consultation = consultationService;
            clinique = cliniqueService;
            adresse = adresseService;
            email = emailService;
            employesClinique = employesCliniqueService;
            admin = adminService;
            patientAcharge = patientAchargeService;
            this.backup = backup;
            api = apiService;
            apiKey = apiKeyService;
            this.apiKeyAuthenticationService = apiKeyAuthenticationService;
            sms = sMSService;
        }
    }
}
