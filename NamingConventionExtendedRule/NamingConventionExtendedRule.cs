using IContract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NamingConventionExtendedRule
{
    public class NamingConventionExtendedRule:IRename
    {
        public string Flag => "namingType";
        public string Name => "Naming Convention Extended Rules";

        public string PatternInUI { get; set; }

        private void ChangeString(String value)
        {
            PatternInUI = value;
        }
        public string Rename(string original, string extension, string type, string pattern, int index = 0)
        {
            if (String.IsNullOrEmpty(pattern))
                return original + extension;
            Regex trimmer = new Regex(@"\s\s+");
            String temp = trimmer.Replace(original, " ").Trim();
            switch (pattern)
            {
                case "snake_case":
                    return temp.ToLower().Replace(" ", "_") + extension;
                case "MACRO_CASE":
                    return temp.ToUpper().Replace(" ", "_") + extension;
                case "camelCase":
                    String res = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(temp.ToLower());
                    return Char.ToLowerInvariant(res[0])+res.Substring(1).Replace(" ","") + extension;
                case "dash-case":
                    return temp.ToLower().Replace(" ","-") + extension;
                case "UPPERCASE":
                    return original.ToUpper().Replace(" ", "") + extension;
                case "First Upper":
                    String result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(temp.ToLower());
                    return result + extension;
                default:
                    return original + extension;
            }
        }

        public UserControl GetDefaultControl()
        {
            NamingConventionExtendedDialog uc;
            if (String.IsNullOrEmpty(PatternInUI))
            {
                uc = new NamingConventionExtendedDialog();
            }
            else
            {
                uc = new NamingConventionExtendedDialog(PatternInUI);
            }
            uc.Handler += ChangeString;
            return uc;
        }
    }
}
