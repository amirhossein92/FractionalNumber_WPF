using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DevExpress.Xpf.Editors;
using Rationals;

namespace FractionalNumber.Base
{
    public class SdsFractionalTextEdit : TextEdit
    {
        public SdsFractionalTextEdit()
        {

            this.MaskType = MaskType.RegEx;
            this.Mask = @"\d+( \d+/\d+)? m";
            this.MaskShowPlaceHolders = true;
            this.MaskIgnoreBlank = true;
            this.HorizontalContentAlignment = HorizontalAlignment.Right;
            this.NullText = " m";
            this.NullText = "Empty";
            this.MaskUseAsDisplayFormat = true;
            this.AllowNullInput = true;
            //Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var editValuePropertyBindingExpression = GetBindingExpression(EditValueProperty);
            if (editValuePropertyBindingExpression != null)
                SetBinding(EditValueProperty, new Binding
                {
                    Path = editValuePropertyBindingExpression.ParentBinding.Path,
                    Converter = new FractionalConverter(),
                    UpdateSourceTrigger = UpdateSourceTrigger.LostFocus
                });
        }
    }
}
