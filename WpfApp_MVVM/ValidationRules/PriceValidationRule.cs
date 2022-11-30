using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp_MVVM.ValidationRules
{
    public class PriceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(decimal.TryParse(value.ToString(), out var price))
            {
                if(price <= 0)
                {
                    return new ValidationResult(false, "Cena nie może być mniejsza bądź równa 0");
                }
            }
            else
            {
                return new ValidationResult(false, "Niepoprawne dane");
            }

            return new ValidationResult(true, null);
        }
    }
}
