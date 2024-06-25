using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Client_Emias.Helpers.Rules
{
    public class OnlyLongInputRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            long oms = 0;
            try
            {
                oms = long.Parse((string)value);
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, $"Invalid characters or {ex.Message}");
                throw;
            }
            if (oms < 0 || oms >= long.MaxValue) return new ValidationResult(false, "Value cannot be less than zero and greater than max accessible value");
            return new ValidationResult(true, null);
        }
    }
}
