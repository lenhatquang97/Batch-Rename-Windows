using IContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToLowerCaseAndRemoveSpaceRule
{
    public class ToLowerCaseAndRemoveSpaceRule: IRename
    {
        public String Name => "To lowercase and remove space rule";
        public String Flag => "toLowerCaseAndRemoveSpace";

        public String PatternInUI { get; set; }
        private void ChangeString(String data)
        {
            PatternInUI = data;
        }

        public UserControl GetDefaultControl()
        {
            ToLowerCaseAndRemoveSpaceRuleDialog uc;
            if (PatternInUI == null || PatternInUI.Length == 0)
            {
                uc = new ToLowerCaseAndRemoveSpaceRuleDialog();
            }
            else
            {
                uc = new ToLowerCaseAndRemoveSpaceRuleDialog(PatternInUI);
            }
            uc.Handler += ChangeString;
            return uc;
        }
        public string Rename(string original, string extension, string type, string pattern, int index = 0)
        {
            if (pattern == "True")
            {
                return original.ToLower().Replace(" ", "") + extension;
            }
            return original + extension;
        }
    }
}
