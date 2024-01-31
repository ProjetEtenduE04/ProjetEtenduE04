
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
        // @"M:\Projet\Clone\Clinique_2000\Clinique_2000_E04\Clinique2000_Utility\CodesPostauxQuebec\QuebecPostalCodes202312.csv";
        //@"C:\Users\misle\OneDrive\Bureau\final\Clinique_2000\Clinique_2000_E04\Clinique2000_Utility\CodesPostauxQuebec\QuebecPostalCodes202312.csv";
        @"C:\Users\1495397\Desktop\Clinique_2000\Clinique_2000_E04\Clinique2000_Utility\CodesPostauxQuebec\QuebecPostalCodes202312.csv";
        //@"C:\Ecole\Aut 2023\Projet final\Clinique_2000\Clinique_2000_E04\Clinique2000_Utility\CodesPostauxQuebec\QuebecPostalCodes202312.csv";
        @"C:\Users\6216948\Desktop\Clinique_2000\Clinique_2000_E04\Clinique2000_Utility\CodesPostauxQuebec\QuebecPostalCodes202312.csv";
       
        
       
        /// <summary>
        /// Toastr Messages  
        /// </summary> 
        public const string Success = "Success";
        public const string Error = "Error";
        public const string Info = "Info";
        public const string Warning = "Warning";

        //Rôles
        public const string SuperAdminRole = "SuperAdmin";
        public const string AdminCliniqueRole = "AdminClinique";
        public const string MedicinRole = "Medecin";
        public const string PatientRole = "Patient";

    }
}

