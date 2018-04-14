using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MVVMutils.Converters
{
    /// <summary>
    /// Converti un booleen en visibilité 
    /// </summary>
    public class BooleanToVisibilityConverter : TypedConverter<bool, Visibility>
    {
        protected override Visibility Convert(bool value, object parameter, CultureInfo culture)
        {
            return value ? Visibility.Visible : Visibility.Hidden;
        }

        protected override bool ConvertBack(Visibility value, object parameter, CultureInfo culture)
        {
            return value == Visibility.Visible;
        }
    }
}
