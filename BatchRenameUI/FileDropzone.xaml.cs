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
using System.Windows.Shapes;
using Path = System.IO.Path;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using IContract;

namespace BatchRenameUI
{
    /// <summary>
    /// Interaction logic for FileDropzone.xaml
    /// </summary>
    public partial class FileDropzone : Window
    {
        public ObservableCollection<DataGridShow> Items { get; set; } = new ObservableCollection<DataGridShow>();
        public FileDropzone()
        {
            InitializeComponent();
            FileListBox.ItemsSource = Items;
        }

        private void FilePanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)){
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                {
                    bool containsItem = Items.Any(item => item.Path == file);
                    if (!containsItem)
                    {
                        Items.Add(new DataGridShow { Type = "File", OldName = Path.GetFileName(file), NewName = "", Path = file });
                    }
                }
            }

        }

        private void Chip_DeleteClick(object sender, RoutedEventArgs e)
        {
            var currentChip = (Chip)sender;
            var path = (String)currentChip.Uid;
            var item = Items.SingleOrDefault(x => x.Path == path);
            if(item != null)
            {
                Items.Remove(item);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
