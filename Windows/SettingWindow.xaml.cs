using Microsoft.Win32;
using MinecraftModsManager.DataApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Button = System.Windows.Controls.Button;

namespace MinecraftModsManager.Windows
{
    /// <summary>
    /// Логика взаимодействия для SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();

            this.ModsDirectoryPathTb.Text = UserConfig.ModsDirectoryPath;
            this.GameDirectoryPathTb.Text = UserConfig.GameDirectoryPath;
        }

        private void FileManager_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();

            Button btn = sender as Button;
            if (btn.Name == "FileManagerGamePath")
            {
                this.GameDirectoryPathTb.Text = fbd.SelectedPath;
                UserConfig.GameDirectoryPath = fbd.SelectedPath;
            }
            if (btn.Name == "FileManagerModsPath")
            {
                this.ModsDirectoryPathTb.Text = fbd.SelectedPath;
                UserConfig.ModsDirectoryPath = fbd.SelectedPath;
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            AppManager.SaveUserConfig();

            this.Close();
        }

        private void AceptBtn_Click(object sender, RoutedEventArgs e)
        {
            AppManager.SaveUserConfig();
        }

        private void CanselBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
