using Clinique2000_Utility.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.Models
{
    public class EmployesClinique
    {
       [Key]
       public int EmployeCliniqueID { get; set; }

        [Required]
        public string EmployeCliniqueNom { get; set; }
        [Required]
        public string EmployeCliniquePrenom { get; set; }
        [Required]
        public string EmployeCliniqueCourriel { get; set; }
        [Required]
        public EmployeCliniquePosition EmployeCliniquePosition { get;set; }//place que l'employeur occupe dans la clnique 

        [ForeignKey("User")]
        public  string? UserID { get; set; }

        [ValidateNever]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Clinique")]
        public  int CliniqueID { get; set; }

        [ValidateNever]
        public virtual Clinique Clinique { get; set; }

        
    }
}
