using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace LiteDbExplorer.Controls.Converters
{
    public class ComboBoxItemToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.Print("Converter Convert: " + value.ToString());
            switch (value)
            {
                case null:
                    return null;
                case ComboBoxItem cmbItem:
                    return System.Convert.ToInt32(cmbItem.Content);
                case int theNumber:
                    return new ComboBoxItem() {Content = theNumber};
                default:
                    return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.Print("Converter ConvertBack: " + value.ToString());
            switch (value)
            {
                case null:
                    return null;
                case ComboBoxItem cmbItem:
                    return System.Convert.ToInt32(cmbItem.Content);
                case int theNumber:
                    return new ComboBoxItem() {Content = theNumber};
                default:
                    return value;
            }
        }
    }
}
