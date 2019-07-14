﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Rationals;

namespace FractionalNumber.Base
{
    public class FractionalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var doubleValue = System.Convert.ToDouble(value);
                var rational = Rational.Approximate(doubleValue, tolerance: 0.001);
                var text = rational.ToString("W");
                text = text.Replace(" + ", " ");
                return text;
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var textValue = (string)value;
            if (textValue != null)
            {
                var splittedWithSpace = textValue.Split(' ');
                int mainNumber = int.Parse(splittedWithSpace[0]);
                int numerator = 0;
                int denominator = 1;

                if (splittedWithSpace.Length > 1)
                {
                    var splittedWithSlash = splittedWithSpace[splittedWithSpace.Length - 1].Split('/');
                    numerator = int.Parse(splittedWithSlash[0]);
                    denominator = int.Parse(splittedWithSlash[1]);
                }

                var fraction = new Rational(numerator, denominator);
                double result = (double)fraction + mainNumber;
                return result;
            }

            return 0;
        }
    }
}
