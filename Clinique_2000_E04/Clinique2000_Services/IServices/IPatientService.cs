using Clinique2000_Core.Models;
using Clinique2000_Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.IServices
{
    public interface IPatientService: IServiceBaseAsync<Patient>
    {
        int CalculerAge(DateTime dateDeNaissance);
        bool EstMajeurAge(int age);
        bool EstMajeurDateDeNaissance(DateTime dateDeNaissance);
        bool VerifierExistencePatientParNAM(string nam);
    }
}
