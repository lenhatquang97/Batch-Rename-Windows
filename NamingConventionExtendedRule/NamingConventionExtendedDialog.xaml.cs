using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace NamingConventionExtendedRule
{
    /// <summary>
    /// Interaction logic for NamingConventionExtendedDialog.xaml
    /// </summary>
    public partial class NamingConventionExtendedDialog : UserControl
    {
        private List<String> NewRules = new List<String>() { "snake_case", "MACRO_CASE", "camelCase", "dash-case", "UPPERCASE", "First Upper" };
        public delegate void ChangeString(String data);
        public event ChangeString Handler;
        public NamingConventionExtendedDialog()
        {
            InitializeComponent();
            RulesComboBox.ItemsSource = NewRules;
        }
        public NamingConventionExtendedDialog(String value)
        {
            InitializeComponent();
            RulesComboBox.ItemsSource = NewRules;
            RulesComboBox.SelectedItem = value;
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if(RulesComboBox.SelectedIndex != -1)
            {
                if (Handler != null)
                {
                    String result = RulesComboBox.Items[RulesComboBox.SelectedIndex] as String;
                    Handler(result);
                    Window wnd = (Window)this.Parent;
                    wnd.Close();
                }
            }
        }
    }
}
