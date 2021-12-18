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

namespace ToLowerCaseAndRemoveSpaceRule
{
    /// <summary>
    /// Interaction logic for ToLowerCaseAndRemoveSpaceRuleDialog.xaml
    /// </summary>
    public partial class ToLowerCaseAndRemoveSpaceRuleDialog : UserControl
    {
        public delegate void ChangeString(String data);
        public event ChangeString Handler;
        public ToLowerCaseAndRemoveSpaceRuleDialog()
        {
            InitializeComponent();
        }
        public ToLowerCaseAndRemoveSpaceRuleDialog(String value)
        {
            InitializeComponent();
            LowercaseNoSpaceSwitch.IsChecked = value == "True";
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (Handler != null)
            {
                String result = (bool)LowercaseNoSpaceSwitch.IsChecked ? "True" : "False";
                Handler(result);
                Window wnd = (Window)this.Parent;
                wnd.Close();
            }
        }
    }
}
