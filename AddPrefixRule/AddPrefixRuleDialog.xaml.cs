using System;
using System.Collections.Generic;
using System.IO;
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

namespace AddPrefixRule
{
    public partial class AddPrefixRuleDialog : UserControl
    {
        public delegate void ChangeString(String data);
        public event ChangeString Handler;
        public AddPrefixRuleDialog()
        {
            InitializeComponent();
        }
        public AddPrefixRuleDialog(String prefix)
        {
            InitializeComponent();
            PrefixField.Text = prefix;
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (Handler != null)
            {
                String result = PrefixField.Text;
                if (String.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Oh no!! Empty text :((");
                    return;
                }
                if (result.Any(Path.GetInvalidFileNameChars().Contains))
                {
                    MessageBox.Show("Oh no!! Your text contains illegal characters!! :'( ");
                    return;
                }
                Handler(result);
                Window wnd = (Window)this.Parent;
                wnd.Close();
            }
        }
    }
}
