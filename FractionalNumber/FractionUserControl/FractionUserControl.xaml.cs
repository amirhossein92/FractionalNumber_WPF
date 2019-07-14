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
        }

        public double AmirValue { get; set; }

        private void SpinEdit_OnEditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            AmirValue = SpinEdit.DoubleValue;
        }
    }
}