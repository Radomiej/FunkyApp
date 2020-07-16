using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PluginBase.Tools
{
    public class FileChooser
    {
        private static Dictionary<string, string> filters = new Dictionary<string, string>()
        {
            {"jpeg", "JPEG Files (*.jpeg)|*.jpeg"},
            {"png",  "PNG Files (*.png)|*.png"},
            {"jpg",  "JPG Files (*.jpg)|*.jpg"},
            {"gif",  "GIF Files (*.gif)|*.gif"},
            {"svg",  "SVG Files (*.svg)|*.svg"},
        };

        public static string ChooseFile(params string[] findExtansions)
        {
            string filter = "";
            for (int i = 0; i < findExtansions.Length; i++)
            {
                if (i > 0) filter += "|";
                filter += filters[findExtansions[i]];
            }
            
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
//            dlg.DefaultExt = "*.png";
            dlg.Filter = filter;

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                return filename;
            }
            return null;
        }

        public static string ChooseFile()
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
//            dlg.DefaultExt = "*.png";
//            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                return filename;
            }
            return null;
        }

        public static string ChooseFolder(string rootFolder = null)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (rootFolder != null) dialog.SelectedPath = rootFolder;
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            // Open document 
            string folderName = dialog.SelectedPath;
            return folderName;
        }
        
        public static string SaveFile(string defaultFilename)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            dlg.FileName = defaultFilename;
            // Set filter for file extension and default file extension 
            //dlg.DefaultExt = "*.png";
            // dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                return filename;
            }
            return null;
        }
    }
}
