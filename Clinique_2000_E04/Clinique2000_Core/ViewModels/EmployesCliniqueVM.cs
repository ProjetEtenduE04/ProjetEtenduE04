using Clinique2000_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.ViewModels
{
    public class EmployesCliniqueVM
    {
        public EmployesClinique EmployesClinique { get; set; }
        public ListeAttente? ListeAttente { get; set; }
        public ListeAttenteVM ?ListeAttenteVM { get; set; }
        public ICollection<Clinique> ?MesCliniques { get; set; }
    }
}
