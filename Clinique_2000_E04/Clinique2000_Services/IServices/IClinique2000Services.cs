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
        public ICliniqueService clinique { get; }
        public IAdresseService adresse { get; }
    }
    
}
