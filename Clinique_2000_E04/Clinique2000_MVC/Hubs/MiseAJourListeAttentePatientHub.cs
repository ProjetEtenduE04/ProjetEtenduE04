using Clinique2000_Core.Models;
using Clinique2000_Services.IServices;

using Microsoft.AspNetCore.SignalR;

namespace Clinique2000_MVC.Hubs
{
    public class MiseAJourListeAttentePatientHub : Hub
    {
        /// <summary>
        /// Hub pour la mise à jour de la liste d'attente des patients
        /// </summary>
        /// <returns></returns>
        public async Task MiseAJourListeAttentePatient()
        {
            await Clients.All.SendAsync("MiseAJourListeSalleDAttentePatient");
        }
    }
}
