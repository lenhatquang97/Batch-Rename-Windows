using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using IContract;
namespace ReplaceRule
{
    public class ReplaceRule: IRename
    {
        public string Flag => "replace";
        public string Name => "Replace Rule";

        public string PatternInUI { get; set; }

        private void ChangeString(String value)
        {
            PatternInUI = value;
        }
       
        public UserControl GetDefaultControl()
        {
            ReplaceRuleDialog uc;
            if (PatternInUI == null || PatternInUI.Length == 0)
            {
                uc = new ReplaceRuleDialog();
            }
            else
            {
                String[] splitVal = PatternInUI.Split('?');
                uc = new ReplaceRuleDialog(splitVal[0], splitVal[1]);
            }
            uc.Handler += ChangeString;
            return uc;
        }

        public string Rename(string original, string extension, string type, string pattern, int index = 0)
        {
            if (pattern.Length == 0 || pattern == null)
                return original + extension;
            String[] splitVal = pattern.Split('?');
            if(splitVal[0] == "") return original + extension;
            return original.Replace(splitVal[0], splitVal[1]) + extension;
        }
    }
}
