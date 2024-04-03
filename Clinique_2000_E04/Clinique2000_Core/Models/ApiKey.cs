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
    public class ApiKey
    {
      
            [Key]
            public int Id { get; set; }

            [Required]
            public string Key { get; set; } 

            [Required]
            [ForeignKey("ApplicationUser")]
            public string UserId { get; set; }

            public DateTime CreationDate { get; set; }

            [ValidateNever]
            public virtual ApplicationUser ApplicationUser { get; set; }
        
    }
}
