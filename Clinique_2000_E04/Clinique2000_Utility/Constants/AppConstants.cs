
namespace Clinique2000_Utility.Constants
{
    public static class AppConstants
    {
        /// <summary>
        /// Âge minimal requis pour s'inscrire dans le système
        /// </summary>
        public const int AgeMajorite = 14;

        public static string CsvFilePath =
            //@"D:\Clinique2000\Clinique_2000\Clinique_2000_E04\Clinique2000_Utility\CodesPostauxQuebec\QuebecPostalCodes202312.csv";
         @"D:\Clinique2000\Clinique_2000\Clinique_2000_E04\Clinique2000_Utility\CodesPostauxQuebec\QuebecPostalCodes202312.csv";

        //Rôles
        public const string SuperAdminRole = "SuperAdmin";
        public const string AAdminCliniqueRole = "AdminClinique";
        public const string MedicinRole = "Medecin";
        public const string PacientRole = "Pacient";

    }
}

