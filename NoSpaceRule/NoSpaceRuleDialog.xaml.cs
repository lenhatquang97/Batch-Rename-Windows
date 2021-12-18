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

namespace NoSpaceRule
{
    /// <summary>
    /// Interaction logic for NoSpaceRuleDialog.xaml
    /// </summary>
    public partial class NoSpaceRuleDialog : UserControl
    {
        public delegate void ChangeString(String data);
        public event ChangeString Handler;
        public NoSpaceRuleDialog()
        {
            InitializeComponent();
        }
        public NoSpaceRuleDialog(String value)
        {
            InitializeComponent();
            NoSpaceSwitch.IsChecked = value == "True";
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (Handler != null)
            {
                String result = (bool)NoSpaceSwitch.IsChecked ? "True" : "False";
                Handler(result);
                Window wnd = (Window)this.Parent;
                wnd.Close();
            }
        }
    }
}
