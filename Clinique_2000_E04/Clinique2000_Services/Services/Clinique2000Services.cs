using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Clinique2000_Services.IServices;
using Microsoft.Extensions.Configuration;

namespace Clinique2000_Services.Services
{
    public class Clinique2000Services : IClinique2000Services
    {
        public IServices.IListeAttenteService listeAttente { get; private set; }


        

    }
}
