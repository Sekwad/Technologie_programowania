using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Zad_4_Kasyno.ViewModels
{
    class Validator : ValidationRule
    {
        public double Min { get; set; }
        public double Max { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string checkingValue = value.ToString();

            if (Min != 0 && checkingValue.Length == 0)
            {
                return new ValidationResult(false, "Pole nie może być puste!");
            }
            else if (checkingValue.Length > Max)
            {
                return new ValidationResult(false, "Zakres do " + Max + " zn.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
