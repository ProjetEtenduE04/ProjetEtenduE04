using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Clinique2000_Utility.CustomAttributesValidation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ValiderDateDeNaissance : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime DateDeNaissance)
            {
                // Vérifier si la date de naissance est dans le futur.
                if (DateDeNaissance > DateTime.Now)
                {
                    ErrorMessage = "La date de naissance ne peut pas se situer dans le futur.";
                    return false;
                }

                // Vérifier le nombre de jours dans le mois
                if (DateDeNaissance.Day > DateTime.DaysInMonth(DateDeNaissance.Year, DateDeNaissance.Month))
                {
                    ErrorMessage = "Le mois ne contient pas autant de jours.";
                    return false;
                }

                return true;
            }
            // Si la valeur n'est pas une DateTime
            return false;
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }
}
