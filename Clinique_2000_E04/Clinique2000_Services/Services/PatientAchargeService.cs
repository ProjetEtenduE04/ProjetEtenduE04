using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Enum;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clinique2000_Services.Services.PatientService;

namespace Clinique2000_Services.Services
{
    public class PatientAchargeService : ServiceBaseAsync<PatientACharge>, IPatientAchargeService
    {


        private readonly CliniqueDbContext _context;
        private readonly IPatientService _patientservice;


        public PatientAchargeService(CliniqueDbContext context, IPatientService patientservice) : base(context)
        {
            _context = context;
            _patientservice = patientservice;
        }


        public async Task<PatientACharge> AjouterPatientaCharge(PatientACharge patientACharge)
        {
            // Récupérer le patient connecté

            var userconnecter = await _patientservice.GetUserAuthAsync();
            //verifier si user connecter est patient
            Patient parent = await _patientservice.GetPatientParUserIdAsync(userconnecter.Id);

            //si le parent est nul, cela signifie que l'utilisateur connecté n'est pas un patient
            if (parent == null)
            {
                throw new Exception("Vous devez être enregistré en tant que patient pour ajouter un patient à charge.");
            }
            else //le user connecter est un patient
            {
                // Vérifier l'âge du patient à charge
                Age age = _patientservice.CalculerAge(patientACharge.DateDeNaissance);
                if (_patientservice.EstMajeurAge(age.Annees))
                {
                    throw new Exception("Le patient à charge que vous tentez d'ajouter à 14 ans ou plus. Il doit alors se créer son propre compte dans notre système.");
                }
                else
                {
                    if (await _patientservice.VerifierSiNAMestUnique(patientACharge.NAM) == false)
                    {
                        throw new Exception("Le NAM que vous tentez d'ajouter est déjà utilisé par un autre patient.");
                    }
                    else
                    {
                        // Lier le patient a charge a sa personne responsable, puis ajouter le patient à charge

                        patientACharge.Age = age.Annees;

                        return await CreerAsync(patientACharge);


                    }

                }

            }

        }



        public async Task<PatientACharge> DeletePatientAChargeAsync(PatientACharge patientACharge)
        {
            if (patientACharge.ConsultationsPAC.Any(x => x.StatutConsultation == StatutConsultation.EnAttente))
            {
                throw new Exception("Vous ne pouvez pas supprimer un patient à charge qui a des consultations en attente.");
            }
            else
            {
                _context.PatientACharges.Remove(patientACharge);
                await _context.SaveChangesAsync();
            }
            return null;
        }


        public async Task UpdatePatientAChargeAsync(PatientACharge patientACharge)
        {
            // Get the existing patientACharge object from the database based on the id
            PatientACharge existingPatientACharge = await _context.PatientACharges
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync(p => p.PatientAChargeId == patientACharge.PatientAChargeId);

            Age age = _patientservice.CalculerAge(patientACharge.DateDeNaissance);

            // Check if the NAM has been changed
            if (patientACharge.NAM != existingPatientACharge.NAM)
            {
                // Check if the new NAM value is unique
                if (await _patientservice.VerifierSiNAMestUnique(patientACharge.NAM) == false)
                {
                    throw new Exception("Le NAM que vous tentez d'ajouter est déjà utilisé par un autre patient.");
                }
            }

            if (_patientservice.EstMajeurAge(age.Annees))
            {
                throw new Exception("Le patient à charge que vous tentez d'ajouter à 14 ans ou plus. Il doit alors se créer son propre compte dans notre système.");
            }

            // Update
            patientACharge.Age = age.Annees;
            _context.PatientACharges.Update(patientACharge);
            await _context.SaveChangesAsync();
        }







    }
}
