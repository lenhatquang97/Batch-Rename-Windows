using IContract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AddCounterRule
{
    public class AddCounterRule : IRename
    {
        public String PatternInUI { get; set; }
        public string Name => "Add Counter Rule";
        public string Flag => "counter";

        public string Rename(string original, string extension, string type, String pattern, int index=0)
        {
            String[] ls = pattern.Split('?');
            if(ls[0] == "0" && ls[1]=="0")
                return original + extension;
            int result = int.Parse(ls[0]) + int.Parse(ls[1]) * index;
            return original + result.ToString() + extension;
        }
        private void ChangeString(String data){
            PatternInUI = data;
        }
        public UserControl GetDefaultControl()
        {
            AddCounterRuleDialog uc;
            if (PatternInUI == null || PatternInUI.Length == 0)
            {
                uc = new AddCounterRuleDialog();
            }
            else
            {
                Debug.WriteLine(PatternInUI);
                String[] splitVal = PatternInUI.Split('?');
                uc = new AddCounterRuleDialog(splitVal[0], splitVal[1]);
            }
            uc.Handler += ChangeString;
            return uc;
        }

    }
}
