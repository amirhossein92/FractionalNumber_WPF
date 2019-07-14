using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using DevExpress.Xpf.Editors;
using Rationals;

namespace FractionalNumber.Base
{
    public class SdsFractionalTextEdit : TextEdit
    {
        public SdsFractionalTextEdit()
        {
            MaskType = MaskType.RegEx;
            Mask = @"\d+( \d+/\d+)?";
            //EditValueChanged += OnEditValueChanged;
            Loaded += OnLoaded;

        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var editValuePropertyBindingExpression = GetBindingExpression(EditValueProperty);
            if (editValuePropertyBindingExpression != null)
                SetBinding(EditValueProperty, new Binding
                {
                    Path = editValuePropertyBindingExpression.ParentBinding.Path,
                    Converter = new FractionalConverter()
                });
        }

        private void OnEditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            var newValue = (string)e.NewValue;
            if (newValue != null)
            {
                var splittedWithSpace = newValue.Split(' ');
                MainNumber = int.Parse(splittedWithSpace[0]);

                if (splittedWithSpace.Length > 1)
                {
                    var splittedWithSlash = splittedWithSpace[splittedWithSpace.Length - 1].Split('/');
                    Numerator = int.Parse(splittedWithSlash[0]);
                    Denominator = int.Parse(splittedWithSlash[1]);
                }
                else
                {
                    Numerator = 0;
                    Denominator = 1;
                }

                var fraction = new Rational(Numerator, Denominator);
                DoubleValue = (double)fraction + MainNumber;
            }
        }

        public int MainNumber { get; set; }
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public static readonly DependencyProperty DoubleValueProperty = DependencyProperty.Register(
            "DoubleValue", typeof(double), typeof(SdsFractionalTextEdit), new PropertyMetadata(default(double)));

        public double DoubleValue
        {
            get { return (double)GetValue(DoubleValueProperty); }
            set
            {

                var fraction = Rational.Approximate(value, tolerance: 0.001);

                SetValue(DoubleValueProperty, value);
            }
        }
    }
}
