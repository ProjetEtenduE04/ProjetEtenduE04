using Microsoft.AspNetCore.Identity;
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
    public class ApplicationUser:IdentityUser
    {
        [ValidateNever]
        public virtual Patient? Patient { get; set; }

        [ValidateNever]
        public virtual List<Clinique>? Clinique { get; set; }
    }
}
