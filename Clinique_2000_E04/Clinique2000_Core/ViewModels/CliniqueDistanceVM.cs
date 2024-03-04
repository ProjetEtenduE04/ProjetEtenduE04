using Clinique2000_Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.ViewModels
{
    public class CliniqueDistanceVM
    {

        public Clinique Clinique { get; set; }

        public double Distance { get; set; }

        [Display(Name = "Réservez une consultation dès")]
        [DataType(DataType.Time)]
        public DateTime? HeureProchaineConsultation { get; set; }

        [Display(Name = "Latitude de la clinique")]
        public string CliniqueLatitude { get; set; }

        [Display(Name = "Longitude de la clinique")]
        public string CliniqueLongitude { get; set; }

        [Display(Name = "Latitude du patient")]
        public string PatientLatitude { get; set; }

        [Display(Name = "Longitude du patient")]
        public string PatientLongitude { get; set; }

    }
}
