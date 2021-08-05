using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ArkScribeFrontEnd
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            CreateFile();
            Window mainWindow = new MainWindow();
            mainWindow.Show();
        }
        public void CreateFile()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filepath = Path.Combine(folder, "ArkScribe\\");
            Directory.CreateDirectory(filepath);
            FileInfo file = new FileInfo(filepath + "DinoFile.xml");
            if (!file.Exists)
            {
                var writer = file.CreateText();
                using (var sw = writer)
                {
                    sw.WriteLine("<projects></projects>");
                    sw.Close();
                }
            }

            else
            {
                Console.WriteLine("File Found");
            }
        }
    }
}
