using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace IContract
{
    public interface IBus
    {
        //Interface or field
        string Description { get; }
        IDao Dao { get; set; }
        List<IRename> RenameInterfaces { get; set; }
        List<String> TemporaryPreview { get; set; }

        //Logic from View to BusinessLogic
        //Logic from DAO to BusinessLogic
        //Logic from IRename to BusinessLogic
        List<String> notUsedSlots();
        List<String> usedSlots();
        void PreviewBatch(ObservableCollection<DataGridShow> ls);
        void RenameBatch(ObservableCollection<DataGridShow> ls);
        void RenameBatchAndCreateCopy(ObservableCollection<DataGridShow> ls);
        void DeleteRuleAdded(String title);
        void AddANewRule(String rule);
        void EditARule(String rule);
        void RecursiveAddAllFiles(ObservableCollection<DataGridShow> ls, String path, Dispatcher thread);
    }
}
