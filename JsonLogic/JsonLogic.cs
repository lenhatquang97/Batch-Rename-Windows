using IContract;
using JsonDao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace JsonLogic
{
    public class JsonLogic: IBus
    {
        public string Description => "Read Preset and Handle with JSON";
        public IDao Dao { get; set; }
        public List<IRename> RenameInterfaces { get; set; }
        public List<String> TemporaryPreview { get; set; }
        public Stack<DataGridShow> StackRecur;
        public JsonLogic()
        {
            Dao = new JsonDao.JsonDao();
            RenameInterfaces = new List<IRename>();
            TemporaryPreview = new List<String>();
            StackRecur = new Stack<DataGridShow>();
        }
        public void RenameBatch(ObservableCollection<DataGridShow> ls)
        {
            if(ls.Count > 0 && (String.IsNullOrEmpty(ls[0].NewName))){
                PreviewBatch(ls);
            }
            for(int i = 0; i < TemporaryPreview.Count; i++)
            {
                if (Utility.CheckTooLong(TemporaryPreview[i])){
                    return;
                }
                if (ls[i].Type == "Folder"){
                    Directory.Move(ls[i].Path, Path.GetDirectoryName(ls[i].Path) + "\\" + ls[i].NewName);
                }
                else{
                    File.Move(ls[i].Path, Path.GetDirectoryName(ls[i].Path) + "\\" + ls[i].NewName);
                }
                ls[i].Path = Path.GetDirectoryName(ls[i].Path) + "\\" + ls[i].NewName;
                ls[i].OldName = TemporaryPreview[i];
                ls[i].NewName = "";
            }
        }
        public List<String> notUsedSlots()
        {
            List<String> res = new List<String>();
            foreach (var rule in RenameInterfaces)
            {
                if (!Dao.Contains(rule.Flag))
                {
                    res.Add(rule.Name);
                }
            }
            return res;
        }

        public List<String> usedSlots()
        {
            List<String> ls = Dao.GetKeys();
            List<String> res = new List<String>();
            foreach(var temp in ls)
            {
                bool has = RenameInterfaces.Any(rne => rne.Flag == temp);
                if (has)
                {
                    var value = RenameInterfaces.Single(s => s.Flag == temp);
                    res.Add(value.Name);
                }
            }
            return res;
        } 

        public void PreviewBatch(ObservableCollection<DataGridShow> ls)
        {
            int count = 0;
            String result, name, ext;
            result = name = ext = "";
            TemporaryPreview.Clear();
            foreach (var item in ls){
                if(item.Type == "Folder"){
                    name = item.OldName;
                    ext = "";
                }
                else
                {
                    List<String> tmp = Utility.parseFileName(item.OldName);
                    name = tmp[0];
                    ext = tmp[1];
                }
                foreach (var rule in RenameInterfaces)
                {
                    if (Dao.Contains(rule.Flag))
                    {
                        result = rule.Rename(name, ext, item.Type, Dao.Read(rule.Flag), count);
                        if (item.Type == "Folder"){
                            name = result;
                        }
                        else
                        {
                            List<String> tmp = Utility.parseFileName(result);
                            name = tmp[0];
                            ext = tmp[1];
                        }         
                    }
                    else continue;
                }
                item.NewName = result;
                Utility.CheckConflict(item, result, count);
                if (Utility.CheckTooLong(item.NewName)){
                    return;
                }
                TemporaryPreview.Add(item.NewName);
                count++;
            }
        }
        public void DeleteRuleAdded(String title)
        {
            foreach(var it in RenameInterfaces){
                if(it.Name == title){
                    Dao.Delete(it.Flag);
                    it.PatternInUI = null;
                    return;
                }
            }
        }

        public void AddANewRule(String rule)
        { 
            var value = RenameInterfaces.Single(s => s.Name == rule);
            Window window = new Window
            {
                Title = value.Name,
                Content = value.GetDefaultControl(),
                Height = 300,
                Width = 300
            };
            window.ShowDialog();
            if (value.PatternInUI != null){
                Dao.Create(value.Flag, value.PatternInUI);
            }
        }
        public void EditARule(String rule)
        {
            var value = RenameInterfaces.Single(s => s.Name == rule);
            if (Dao.Contains(value.Flag))
                value.PatternInUI = Dao.Read(value.Flag);
            Window window = new Window
            {
                Title = value.Name,
                Content = value.GetDefaultControl(),
                Height = 300,
                Width = 300
            };
            window.ShowDialog();
            if (value.PatternInUI != null)
                Dao.Update(value.Flag, value.PatternInUI);
        }
        public async void RenameBatchAndCreateCopy(ObservableCollection<DataGridShow> ls){
            String tempFolder = Directory.GetCurrentDirectory()+"\\"+ Guid.NewGuid().ToString();
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }
            ObservableCollection<DataGridShow> res = new ObservableCollection<DataGridShow>();
            foreach (var item in ls)
            {
                if(item.Type == "File")
                {
                    File.Copy(item.Path, tempFolder + "\\" + item.OldName, true);
                    res.Add(new DataGridShow() { Type = "File", Path = tempFolder + "\\" + item.OldName, OldName = item.OldName, NewName = item.NewName });
                }
                else
                {
                    await Task.Run(() =>
                    {
                        DirectoryCopyExample.DirectoryCopy(item.Path, tempFolder + "\\" + item.OldName, true);
                    });
                    res.Add(new DataGridShow() { Type = "Folder", Path = tempFolder + "\\" + item.OldName, OldName = item.OldName, NewName = item.NewName });
                }
            }
            try
            {
                RenameBatch(res);
                Process.Start("explorer", tempFolder);
            }
            catch
            {
                Debug.WriteLine("Failure");
            }
            

        }

        public void RecursiveAddAllFiles(ObservableCollection<DataGridShow> ls, string path, Dispatcher thread)
        {
            String result = path;
            do
            {
                DirectoryInfo dir = new DirectoryInfo(result);
                DirectoryInfo[] dirs = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();
                foreach (var file in files)
                {
                    bool containsItem = ls.Any(item => item.Path == file.ToString());
                    if (!containsItem)
                    {
                        thread.Invoke((Action)delegate {
                            ls.Add(new DataGridShow { Type = "File", NewName = "", OldName = file.Name, Path = file.ToString() });
                        });             
                    }
                }
                foreach (var dire in dirs)
                {
                    StackRecur.Push(new DataGridShow { Type = "Folder", NewName = "", OldName = dire.Name, Path = dire.FullName });
                }
                if (StackRecur.Count() != 0)
                    result = StackRecur.Pop().Path;
                else{
                    result = "";
                }
            } while (result != "" || StackRecur.Count() != 0);
        }
    }
}
