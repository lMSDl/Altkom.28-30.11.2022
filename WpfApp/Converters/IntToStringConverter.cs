using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfApp.Converters
{
    public class IntToStringConverter : MarkupExtension, IValueConverter
    {
        public int? MaxValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var intValue = (int)value;
            if (MaxValue.HasValue && intValue > MaxValue)
                return MaxValue.Value.ToString();
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var intResult = int.TryParse(value.ToString(), out var result) ? result : 0;
            
            return MaxValue.HasValue && intResult > MaxValue ? MaxValue : intResult;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
