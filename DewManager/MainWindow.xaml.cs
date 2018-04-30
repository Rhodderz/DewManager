using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using DewManager.Configs;
using DewManager.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Ookii.Dialogs.Wpf;

namespace DewManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private ObjectLocations _objectLocations;
        private Maps _maps;
        private ConfigLoader _configLoader;

        public MainWindow()
        { 
            Debug.WriteLine("Application Started");
        }

        private void FileMenu_Quit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void FileMenu_Open_Click(object sender, RoutedEventArgs e)
        {
            string path = getEDDir();

            while (Directory.GetFiles(path, "eldorado.exe").Length == 0)
            {
                MessageBox.Show(
                    "This doesnt look like the ED root folder!",
                    "Please make sure you select the root folder of Eldewrito!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                path = getEDDir();
            }
            
            _objectLocations = new ObjectLocations(path);
            
            Debug.WriteLine("Eldewrito location: " + _objectLocations.getRootDir_Path());
            
            LoadFiles();
            _configLoader = new ConfigLoader(_objectLocations);

            ConfigCount.Text = "Configs: " + _configLoader.getConfigList().Count;

            int index = 0;
            foreach (DewritoConfig dewritoConfig in _configLoader.getConfigList())
            {
                TabItem ti = new TabItem
                {
                    Header = dewritoConfig.getServerName(),
                    Content = new ConfigView(_configLoader.getConfigBundle(index))
                };
                
                ConfigTabs.Items.Add(ti);

                index++;
            }

            ConfigTabs.SelectedIndex = 0;
            
        }

        private void FileMenu_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadFiles()
        {
            _maps = new Maps(_objectLocations);
        }

        private string getEDDir()
        {
            VistaFolderBrowserDialog dialog =
                new VistaFolderBrowserDialog
                {
                    Description = "Select the root Halo Online folder for your server",
                    UseDescriptionForTitle = true
                };
            dialog.ShowDialog(this);

            return dialog.SelectedPath;
        }
    }
}
