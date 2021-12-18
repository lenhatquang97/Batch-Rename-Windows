using IContract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToPascalCaseRule
{
    public class ToPascalCaseRule: IRename
    {
        public string Flag => "toPascalCase";
        public string Name => "To PascalCase rule";

        public string PatternInUI { get; set; }
        private void ChangeString(String data)
        {
            PatternInUI = data;
        }


        public UserControl GetDefaultControl()
        {
            ToPascalCaseRuleDialog uc;
            if (PatternInUI == null || PatternInUI.Length == 0)
            {
                uc = new ToPascalCaseRuleDialog();
            }
            else
            {
                uc = new ToPascalCaseRuleDialog(PatternInUI);
            }
            uc.Handler += ChangeString;
            return uc;
        }


        public string Rename(string original, string extension, string type, string pattern, int index = 0)
        {
            if(pattern == "True")
            {
                TextInfo info = CultureInfo.CurrentCulture.TextInfo;
                return info.ToTitleCase(original).Replace(" ", string.Empty)+extension;
            }
            return original + extension;
        }
    }
}
