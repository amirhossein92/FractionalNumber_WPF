using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Editors;

namespace FractionalNumber.FractionUserControl
{
    /// <summary>
    /// Interaction logic for FractionUserControl.xaml
    /// </summary>
    public partial class FractionUserControl : UserControl
    {
        public FractionUserControl()
        {
            InitializeComponent();
            this.MySpinEdit.Mask += "##0.00 m";
            this.MySpinEdit.NullText = "Empty";
            this.MySpinEdit.MaskUseAsDisplayFormat = true;
            this.MySpinEdit.ShowEditorButtons = true;
            this.MySpinEdit.AllowNullInput = true;
            this.MySpinEdit.MinValue = 0;
            //MySimpleButton.Glyph = new BitmapImage(GetUriFromResource("Icon", "fraction.png"));
        }

        public static readonly DependencyProperty EditValueProperty = DependencyProperty.Register(
            "EditValue", typeof(double), typeof(FractionUserControl), 
            new FrameworkPropertyMetadata(default(double)));

        public double EditValue
        {
            get
            {
                return (double)GetValue(EditValueProperty);
            }
            set
            {
                SetValue(EditValueProperty, value);
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var spinEditVisible = MySpinEdit.Visibility;
            if (spinEditVisible == Visibility.Visible)
            {
                MyFractionalTextEdit.Visibility = Visibility.Visible;
                //MySimpleButton.Glyph = new BitmapImage(GetUriFromResource("Icon", "decimal.png"));
                MySimpleButton.Content = ".००";
                MySpinEdit.Visibility = Visibility.Hidden;
            }
            else
            {
                MyFractionalTextEdit.Visibility = Visibility.Hidden;
                //MySimpleButton.Glyph = new BitmapImage(GetUriFromResource("Icon", "fraction.png"));
                MySimpleButton.Content = "⅔";
                MySpinEdit.Visibility = Visibility.Visible;
            }
        }

        private Uri GetUriFromResource(string folder, string resourceFilename)
        {
            return new Uri($@"pack://application:,,,/{folder}/{resourceFilename}");
        }
    }
}