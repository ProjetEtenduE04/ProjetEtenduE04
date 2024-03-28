using Clinique2000_Services.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clinique2000_Services.IServices
{
    public interface IClinique2000Services 
    {

        public IListeAttenteService listeAttente { get; }
        public IPatientService patient { get; }
        public IAuthenGoogleService authenGoogle { get; }
        public IConsultationService consultation { get; }
        public ICliniqueService clinique { get; }
        public IAdresseService adresse { get; }
        public IEmployesCliniqueService employesClinique { get; }
        public IEmailService email { get; }
        public IAdminService admin { get; }
        public IPatientAchargeService patientAcharge { get; }
        public IAPIService api { get; }
    }

}
