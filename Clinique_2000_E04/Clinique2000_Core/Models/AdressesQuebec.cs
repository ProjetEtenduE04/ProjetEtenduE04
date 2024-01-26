using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Core.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AdressesQuebec")] // Replace with your actual table name
    public class AdressesQuebecVM
    {
        [Key]
        public int Id { get; set; } // Primary key, if you have one in your table

        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(3)]
        public string ProvinceAbbr { get; set; }

        public int TimeZone { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        // Other properties and methods...
    }
}
