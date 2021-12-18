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

namespace AddSuffixRule
{
    /// <summary>
    /// Interaction logic for AddSuffixRuleDialog.xaml
    /// </summary>
    public partial class AddSuffixRuleDialog : UserControl
    {
        public delegate void ChangeString(String data);
        public event ChangeString Handler;
        public AddSuffixRuleDialog()
        {
            InitializeComponent();
        }
        public AddSuffixRuleDialog(String suffix)
        {
            InitializeComponent();
            SuffixField.Text = suffix;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (Handler != null)
            {
                String result = SuffixField.Text;
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
