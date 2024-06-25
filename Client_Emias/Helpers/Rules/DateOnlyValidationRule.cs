using Client_Emias.Helpers.Other;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Client_Emias.Helpers.Rules
{
    public class DateOnlyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateOnly date;
            try
            {
                date = DateOnly.Parse((string)value);
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, $"Invalid characters or {ex.Message}");
                throw;
            }
            if (!CompareCompanion.IsDateEarlier(date, DateOnly.FromDateTime(DateTime.Now)) || CompareCompanion.IsDateEarlier(DateOnly.MaxValue, date)) return new ValidationResult(false, "Value cannot be less than today and greater than max accessible value");
            return new ValidationResult(true, null);
        }
    }
}
