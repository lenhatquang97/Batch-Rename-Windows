using IContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChangeExtensionRule
{
    public class ChangeExtensionRule: IRename
    {
        public string Flag => "extension";
        public string Name => "Change Extension Rule";

        public string PatternInUI { get; set; }
        private void ChangeString(String data)
        {
            PatternInUI = data;
        }


        public UserControl GetDefaultControl()
        {
            ChangeExtensionRuleDialog uc;
            if (PatternInUI == null || PatternInUI.Length == 0)
            {
                uc = new ChangeExtensionRuleDialog();
            }
            else
            {
                uc = new ChangeExtensionRuleDialog(PatternInUI);
            }
            uc.Handler += ChangeString;
            return uc;
        }
        public string Rename(string original, string extension, string type, string pattern, int index = 0)
        {
            if (type == "Folder")
                return original + extension;
            if(pattern == ""){
                return original;
            }
            return original + "." + pattern;
        }
    }
}
