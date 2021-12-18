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

namespace ReplaceRule
{
    /// <summary>
    /// Interaction logic for ReplaceRuleDialog.xaml
    /// </summary>
    public partial class ReplaceRuleDialog : UserControl
    {
        public delegate void ChangeString(String data);
        public event ChangeString Handler;
        public ReplaceRuleDialog()
        {
            InitializeComponent();
        }
        public ReplaceRuleDialog(String needle, String replacer)
        {
            InitializeComponent();
            NeedleField.Text = needle;
            ReplacerField.Text = replacer;
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (Handler != null)
            {
                if (String.IsNullOrEmpty(NeedleField.Text))
                {
                    MessageBox.Show("Oh no!! Empty text :((");
                    return;
                }
                if (NeedleField.Text.Any(Path.GetInvalidFileNameChars().Contains) || ReplacerField.Text.Any(Path.GetInvalidFileNameChars().Contains))
                {
                    MessageBox.Show("Oh no!! Your text contains illegal characters!! :'( ");
                    return;
                }
                String result = NeedleField.Text + "?" + ReplacerField.Text;
                Handler(result);
                Window wnd = (Window)this.Parent;
                wnd.Close();

            }
        }
    }
}
