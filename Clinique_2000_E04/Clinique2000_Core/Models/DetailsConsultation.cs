using Clinique2000_Utility.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public class DetailsConsultation
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Motif du rendez-vous médical")]
        public MotifRendezVousMedical? MotifRendezVous { get; set; }

        [StringLength(500)]
        [Display(Name = "Symptômes")]
        public string? Symptomes { get; set; }

        [StringLength(500)]
        [Display (Name = "Diagnostic")]
        public string? Diagnostic { get; set; }

        [StringLength(500)]
        [Display(Name = "Medicaments Prescrits")]
        public string? MedicamentsPrescrits { get; set; }

        [StringLength(500)]
        [Display(Name = "Notes")]
        public string? Notes { get; set; }

        [Display(Name = "Est Allergique")]
        public bool EstAlergique { get; set; } = false;

    }
}
