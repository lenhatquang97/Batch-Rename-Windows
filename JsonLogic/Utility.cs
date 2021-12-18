using IContract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JsonLogic
{
    static class Utility
    {
        private const int MAX_LENGTH = 200;
        public static List<String> parseFileName(String result)
        {
            int lastIndex = result.LastIndexOf('.');
            String name = lastIndex <= 0 ? result : result.Substring(0, lastIndex);
            String extension = lastIndex <= 0 ? "" : "." + result.Substring(lastIndex + 1);
            return new List<String>() {name, extension};
        }
        public static Boolean CheckTooLong(String result)
        {
            if (result.Length >= MAX_LENGTH)
            {
                MessageBox.Show("Oh no!!! Your filename or foldername is too long");
                return true;
            }
            return false;
        }
        public static void CheckConflict(DataGridShow dgs, String newName, int index)
        {
            //Trung giua ten file moi va cac file xung quanh
            if (dgs.Type == "File")
            {
                String[] files = Directory.GetFiles(Path.GetDirectoryName(dgs.Path));
                bool isDuplicateInPath = files.Any(filename => Path.GetFileName(filename) == newName);
                if (isDuplicateInPath)
                {
                    String temp = Guid.NewGuid().ToString().Substring(0, 5);
                    List<String> tmpList = Utility.parseFileName(newName);
                    dgs.NewName = tmpList[0] + temp + tmpList[1];
                }
            }
            else
            {
                String[] folders = Directory.GetDirectories(Path.GetDirectoryName(dgs.Path));
                bool isDuplicateInPath = folders.Any(folderName =>new DirectoryInfo(folderName).Name == newName);
                if (isDuplicateInPath)
                {
                    String temp = Guid.NewGuid().ToString().Substring(0, 5);
                    dgs.NewName = dgs.NewName + temp;
                }
            }
        }
    }
}
