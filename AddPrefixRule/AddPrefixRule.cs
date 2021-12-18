using IContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AddPrefixRule
{
    public class AddPrefixRule : IRename
    {
        public string Name => "Add Prefix Rule";
        public string Flag => "prefix";
        public string PatternInUI { get; set; }
        private void ChangeString(String data){
            PatternInUI = data;
        }
        public UserControl GetDefaultControl()
        {
            AddPrefixRuleDialog uc;
            if (PatternInUI == null || PatternInUI.Length == 0)
            {
                uc = new AddPrefixRuleDialog();
            }
            else{
                uc = new AddPrefixRuleDialog(PatternInUI);
            }
            uc.Handler += ChangeString;
            return uc;
        }

        public string Rename(string original, string extension, string type, string pattern, int index = 0)
        {
            return pattern + original + extension;
        }
    }
}
