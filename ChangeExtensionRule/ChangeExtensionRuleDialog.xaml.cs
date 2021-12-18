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

namespace ChangeExtensionRule
{
    /// <summary>
    /// Interaction logic for ChangeExtensionRuleDialog.xaml
    /// </summary>
    public partial class ChangeExtensionRuleDialog : UserControl
    {
        public delegate void ChangeString(String data);
        public event ChangeString Handler;
        public ChangeExtensionRuleDialog()
        {
            InitializeComponent();
        }
        public ChangeExtensionRuleDialog(String extension)
        {
            InitializeComponent();
            ExtensionField.Text = extension;
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (Handler != null)
            {
                String result = ExtensionField.Text;
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
