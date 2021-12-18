using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace AddCounterRule
{
    /// <summary>
    /// Interaction logic for AddCounterRuleDialog.xaml
    /// </summary>
    public partial class AddCounterRuleDialog : UserControl
    {
        public delegate void ChangeString(String data);
        public event ChangeString Handler;

        public AddCounterRuleDialog()
        {
            InitializeComponent();
        }
        public AddCounterRuleDialog(String start, String step)
        {
            InitializeComponent();
            StartField.Text = start;
            StepField.Text = step;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (Handler != null)
            {
                if (String.IsNullOrEmpty(StartField.Text)|| String.IsNullOrEmpty(StepField.Text) || StartField.Text.Contains(" ") || StepField.Text.Contains(" "))
                {
                    MessageBox.Show("Oh no!! Empty text :((");
                    return;
                }
                String result = StartField.Text + "?" + StepField.Text;
                Handler(result);
                Window wnd = (Window)this.Parent;
                wnd.Close();
                
            }
        }

        private void Field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
