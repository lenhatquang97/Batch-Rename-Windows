using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IContract
{
    public interface IRename
    {
        String PatternInUI { get; set; }
        string Name { get; }
        string Flag { get; }
        string Rename(string original, string extension, String type, String pattern, int index=0);
        UserControl GetDefaultControl();
    
    }
}
