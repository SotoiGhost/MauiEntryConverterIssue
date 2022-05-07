using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace EntryConverterIssue.Converters;

public class NumberToCurrencyConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return decimal.Parse(value.ToString()).ToString("C");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string valueFromString = Regex.Replace(value.ToString(), @"\D", "");

        if (valueFromString.Length <= 0)
            return 0m;

        if (!long.TryParse(valueFromString, out long valueLong))
            return 0m;

        if (valueLong <= 0)
            return 0m;

        return valueLong / 100m;
    }
}
