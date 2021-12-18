using IContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NoSpaceRule
{
    public class NoSpaceRule:IRename
    {
        public string Flag => "noSpace";
        public string Name => "No space rule";

        public string PatternInUI { get; set; }
        private void ChangeString(String data)
        {
            PatternInUI = data;
        }
        public UserControl GetDefaultControl()
        {
            NoSpaceRuleDialog uc;
            if (PatternInUI == null || PatternInUI.Length == 0)
            {
                uc = new NoSpaceRuleDialog();
            }
            else
            {
                uc = new NoSpaceRuleDialog(PatternInUI);
            }
            uc.Handler += ChangeString;
            return uc;
        }
        public string Rename(string original, string extension, string type, string pattern, int index = 0)
        {
            if(pattern == "True"){
                return original.Replace(" ", "") + extension;
            }
            return original + extension;
        }
    }
}
