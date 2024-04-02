using Clinique2000_DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.ClickSend.ClickSend.Api;
using IO.ClickSend.Client;
using IO.ClickSend.ClickSend.Model;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Net.Http;
using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_Services.IServices;
using Newtonsoft.Json.Linq;


namespace Clinique2000_Services.Services
{
    public class SMSService:ISMSService
    {

        private readonly CliniqueDbContext _dbcontext;
        private SMSApi smsApi;
        private IPatientService _patientService;


        public SMSService(CliniqueDbContext dbcontext, IPatientService patientService)
        {

            _dbcontext = dbcontext;
            _patientService=patientService;



            Configuration configuration = new Configuration()
            {
                Username = "jordan.couturelafranchise@hotmail.com",
                Password = "24B69660-2B02-4EE8-C1C1-B20BCAA889AA"
            };
            smsApi = new SMSApi(configuration);
         
        }

        public void SendSMS(string phoneNumber)
        {


            var listOfSms = new List<SmsMessage>
          {
             new SmsMessage(to: phoneNumber, body: "test message", source: "sdk",from:"+15142290514",country:"Canada")
          };

            var smsCollection = new SmsMessageCollection(listOfSms);
            var response = smsApi.SmsSendPost(smsCollection);
        }



        public void SendConfirmationSMS(Consultation consultation, string phoneNumber)
        {
            var patient = consultation.Patient;
            var messageBody = $"Bonjour, {patient.Nom} {patient.Prenom}! " +
                              $"Confirmation consultation: {consultation.HeureDateDebutPrevue.ToShortDateString()} " +
                              $"à {consultation.HeureDateFinPrevue.ToShortTimeString()}, " +
                              $"Clinique: {consultation.PlageHoraire.ListeAttente.Clinique.NomClinique}. " +
                              $"Merci, Clinique2000.";

            var listOfSms = new List<SmsMessage>
    {
        new SmsMessage(to: phoneNumber, body: messageBody, source: "sdk", from: "+15142290514")
    };

            var smsCollection = new SmsMessageCollection(listOfSms);
            var response =  smsApi.SmsSendPostAsync(smsCollection);

         
        }

      

    }
}
