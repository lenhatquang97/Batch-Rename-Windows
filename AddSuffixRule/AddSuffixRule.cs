using IContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AddSuffixRule
{
    public class AddSuffixRule: IRename
    {
        public string Name => "Add Suffix Rule";

        public string PatternInUI { get; set; }

        public string Flag => "suffix";

        public UserControl GetDefaultControl()
        {
            AddSuffixRuleDialog uc;
            if (PatternInUI == null || PatternInUI.Length == 0)
            {
                uc = new AddSuffixRuleDialog();
            }
            else
            {
                uc = new AddSuffixRuleDialog(PatternInUI);
            }
            uc.Handler += ChangeString;
            return uc;
        }
        private void ChangeString(String data)
        {
            PatternInUI = data;
        }

        public string Rename(string original, string extension, string type, string pattern, int index = 0)
        {
            return original + pattern + extension;
        }
    }
}
