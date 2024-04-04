using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Clinique2000_Core.Models;
using Clinique2000_Core.DTO;
using Clinique2000_DataAccess.Data;
using Clinique2000_MVC.Areas.Identity.Pages.Account;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using NuGet.Protocol.Core.Types;
using Clinique2000_Services.Services;
using Clinique2000_Utility.Enum;

namespace Clinique2000_MVC.Controllers
{


    //[Route("api/[controller]/[action]")]
    [ApiController]
    public class APIController : ControllerBase
    {

        private readonly UserManager<IdentityUser> _userManager;
        private IClinique2000Services _services { get; set; }
        private readonly SignInManager<IdentityUser> _signInManager;

        public APIController(
            IClinique2000Services service,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _services = service;
            _userManager = userManager;
            _signInManager = signInManager;
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, true, false);
                if (result.Succeeded)
                {
                    return Ok();
                }
                return NotFound(new { Error = "L'utilisateur est introuvable ou le mot de passe de concorde pas" });
            }
            catch (Exception e)
            {
                return NotFound(new { Error = "L'utilisateur est introuvable ou le mot de passe de concorde pas" });
            }
            
        }

        [HttpPost("transfert")]
        public async Task<IActionResult> Import()
        {

            return Ok();
        }

        [HttpGet("{NAM}")]
        public async Task<IActionResult> ObtenirPatientSelonNAM(string NAM)
        {
            if (_services == null || _services.patient == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { Message = "Nous ne trouvons aucun patient dans le BD" });
            }

            var patient = await _services.patient.ObtenirPatientParNAMAsync(NAM);


            if (patient == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { Message = "Nous avons essayé de récupérer le patient mais une erreur s'est produite." });
            }

            return Ok(patient);
        }

        // GET: api/patient/majorPatients
        [HttpGet("obtenirPatientsMajeur")]
        public async Task<IActionResult> GetMajorPatients()
        {
            try
            {
                var majorPatients = await _services.patient.ObtenirPatientsMajeurAsync();

                if (majorPatients == null || majorPatients.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { Message = "Aucun patient n'a été trouvé qui était plus âgé ou égal à l'âge de la majorité." });
                }

                return Ok(majorPatients);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { Message = $"Une erreur s'est produite : {ex.Message}" });
            }
        }

        /// <summary>
        /// Ajoute des patients à la base de données.
        /// </summary>
        /// <param name="patients"></param>
        /// <returns></returns>
        [HttpPost("ListPatients")]
        public async Task<IActionResult> PostListPatients([FromBody] List<Patient> patients)
        {
            var userName = User.Identity.Name;

            if (userName == null)
            {
                return Unauthorized();
            }

            if (await _services.api.UserPossedeUneCleAPI(userName) == true)
            {

                List<Patient> patientsSaved = new List<Patient>();
                List<string> errors = new List<string>();

                foreach (var patient in patients)
                {
                    try
                    {
                        var user = await _userManager.FindByEmailAsync(patient.Courriel);

                        if (user != null && !await _services.patient.PatientExisteSelonLeCourrielAsync(patient.Courriel))
                        {
                            patient.UserId = user.Id;
                        }
                        var savedPatient = await _services.patient.EnregistrerOuModifierPatient(patient);
                        patientsSaved.Add(savedPatient);

                        if (patient.preferenceNotification != PreferenceNotification.SMS)
                            await _services.email.SendNotificationPatienImportAsync(patient);
                        else
                            ;
                            //await _services.sms.SendConfirmationSMS(patient); RESTE A IMPLEMENTER
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"Erreur dans l'enregistrement des patients auprès de la NAM {patient.NAM}: {ex.Message}");
                    }
                }

                if (errors.Any())
                {
                    return BadRequest(errors);
                }
                return Ok(patientsSaved);

            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
