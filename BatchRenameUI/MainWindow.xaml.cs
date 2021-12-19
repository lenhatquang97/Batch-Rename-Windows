using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using Fluent;
using Path = System.IO.Path;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Ookii.Dialogs.Wpf;
using IContract;
using System.Reflection;
using System.Diagnostics;
using JsonLogic;
using System.Windows.Threading;

namespace BatchRenameUI
{
    public partial class MainWindow : RibbonWindow
    {
        public ObservableCollection<DataGridShow> Items { get; set; }
        public RenameRuleFactory renameRuleFactory;
        public IBus renameLogic;
        public MainWindow(){
            InitializeComponent();
        }
        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Items = new ObservableCollection<DataGridShow>();
            renameRuleFactory = new RenameRuleFactory();
            renameLogic = new JsonLogic.JsonLogic();
            renameLogic.RenameInterfaces = renameRuleFactory.GetListOfValues();
            GridOfNames.ItemsSource = Items;
            RuleComboBox.ItemsSource = renameLogic.notUsedSlots();
            MyListBox.ItemsSource = renameLogic.usedSlots();
        }
        private void ButtonBrowseFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string path in openFileDialog.FileNames){
                    bool containsItem = Items.Any(item => item.Path == path);
                    if(!containsItem)
                        Items.Add(new DataGridShow {Type="File", NewName = "", OldName = Path.GetFileName(path).ToString(), Path = path});
                }
            }
        }
        private void ButtonBrowseFolders_Click(object sender, RoutedEventArgs e)
        {
            var openFolderDialog = new VistaFolderBrowserDialog();
            openFolderDialog.Multiselect = true;
            openFolderDialog.RootFolder = Environment.SpecialFolder.MyDocuments;
            if(openFolderDialog.ShowDialog() == true)
            {
                foreach(string path in openFolderDialog.SelectedPaths){
                    bool containsItem = Items.Any(item => item.Path == path);
                    if (!containsItem)
                        Items.Add(new DataGridShow {Type="Folder", NewName = "", OldName = Path.GetFileName(path).ToString(), Path = path });
                }
            }
        }
        private void ButtonDrag_Click(object sender, RoutedEventArgs e)
        {
            var dropzoneWindow = new FileDropzone();
            dropzoneWindow.ShowDialog();
            try
            {
                foreach (var obj in dropzoneWindow.Items)
                {
                    bool containsItem = Items.Any(item => item.Path == obj.Path);
                    if (!containsItem)
                        Items.Add(new DataGridShow { Type = "File", NewName = "", OldName = obj.OldName, Path = obj.Path });
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failure");
            }
        }
        private void ButtonPreview_Click(object sender, RoutedEventArgs e){
            try
            {
                renameLogic.PreviewBatch(Items);
            }
            catch
            {
                Debug.WriteLine("Failure");
            }
        }
        private void ButtonRename_Click(object sender, RoutedEventArgs e){
            try
            {
                renameLogic.RenameBatch(Items);
            }
            catch{
                Debug.WriteLine("Failure");
            }
        }
        private void PencilEdit_Click(object sender, RoutedEventArgs e)
        {
            if (MyListBox.SelectedIndex != -1){
                String rule = MyListBox.SelectedItem as String;
                renameLogic.EditARule(rule);
            }
        }
        private void GarbageDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MyListBox.SelectedIndex != -1)
            {
                renameLogic.DeleteRuleAdded(MyListBox.Items[MyListBox.SelectedIndex] as String);
                RefreshState();
            }
            
        }
        private void AddNewRule_Click(object sender, RoutedEventArgs e)
        {
            if (RuleComboBox.SelectedIndex != -1)
            {
                String rule = RuleComboBox.SelectedItem as String;
                renameLogic.AddANewRule(rule);
                RefreshState();
            }
                
        }
        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            Items.RemoveAt(GridOfNames.SelectedIndex);
        }
        private void RefreshState()
        {
            RuleComboBox.ItemsSource = renameLogic.notUsedSlots();
            MyListBox.ItemsSource = renameLogic.usedSlots();
        }
        private async void ButtonRenameAndCreateCopy_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => {
                renameLogic.RenameBatchAndCreateCopy(Items);
            });
            
        }
        private async void ButtonRecursiveAdd_Click(object sender, RoutedEventArgs e)
        {
            var openFolderDialog = new VistaFolderBrowserDialog();
            openFolderDialog.Multiselect = false;
            openFolderDialog.RootFolder = Environment.SpecialFolder.MyDocuments;
            if (openFolderDialog.ShowDialog() == true)
            {
                String path = openFolderDialog.SelectedPath;
                Dispatcher thread = App.Current.Dispatcher;
                await Task.Run(() =>
                {
                    renameLogic.RecursiveAddAllFiles(Items, path, thread);
                });
                
            }
            
        }
    }
}
