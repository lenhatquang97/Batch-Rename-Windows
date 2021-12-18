using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IContract
{
    public class DataGridShow: INotifyPropertyChanged
    {
        public String Type { get; set; }
        public String OldName { get; set; }
        public String NewName { get; set; }
        public String Path { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
