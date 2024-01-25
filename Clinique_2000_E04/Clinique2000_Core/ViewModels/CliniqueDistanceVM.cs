﻿using Clinique2000_Core.Models;
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

        [Display(Name ="Consultation disponible dès")]
        [DataType(DataType.Time)]
        public DateTime? HeureProchaineConsultation { get; set; }
    }
}
