using System;
using System.Collections.Generic;
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
using MinecraftModsManager.Controls;
using MinecraftModsManager.DataApp;
using MinecraftModsManager.Windows;


namespace MinecraftModsManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //list будет хранить только название мода
        public MainWindow()
        {
            InitializeComponent();
            AppManager.LoadUserConfig();

            PreLoadInfoDirectory();
        }

        private void PreLoadInfoDirectory()
        {
            ModsInGame.Items.Clear();
            LoadMods.Items.Clear();

            foreach (var item in DirectoryOperator.GetInfoDirectory(DirectoryOperator.WayGetInfo.InGame))
            {
                ModsInGame.Items.Add(item);
            }
            foreach (var item in DirectoryOperator.GetInfoDirectory(DirectoryOperator.WayGetInfo.All))
            {
                if (ModsInGame.Items.Contains(item))
                {
                    continue;
                }

                LoadMods.Items.Add(item);
            }
        }

        private void ModOn_Click(object sender, RoutedEventArgs e)
        {
            DirectoryOperator.InstallMod(LoadMods.SelectedItem.ToString());

            PreLoadInfoDirectory();
        }
        private void ModOff_Click(object sender, RoutedEventArgs e)
        {
            DirectoryOperator.UnstallMod(ModsInGame.SelectedItem.ToString());

            PreLoadInfoDirectory();
        }

        private void SwitchList(ListBox from, ListBox to)
        {
            to.Items.Add(from.SelectedItem);
            from.Items.Remove(from.SelectedItem);
        }

        private void Task_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu contextMenu = this.FindResource("TaskContextMenu") as ContextMenu;
            contextMenu.PlacementTarget = sender as Button;
            contextMenu.IsOpen = true;
        }

        private void SettingBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow settingWindow = new SettingWindow();
            settingWindow.ShowDialog();
        }

        private void ClearMods_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in ModsInGame.Items)
            {
                DirectoryOperator.UnstallMod(item.ToString());
            }

            PreLoadInfoDirectory();
        }
        private void SaveAsembliMods_Click(object sender, RoutedEventArgs e)
        {
            string mods = "";

            foreach (var item in ModsInGame.Items)
            {
                mods += $"{item}\n";
            }

            AsembluModsOperator.CreateNewAsemblyMods(mods);
        }
        private void LoadAsembliMods_Click(object sender, RoutedEventArgs e)
        {
            string[] mods = (AsembluModsOperator.LoadAsemblyMods().Replace("\r","")).Split('\n');
            string notConsistMods = "";

            ClearMods_Click(sender, e);

            foreach (var item in mods)
            {
                if (item != "")
                {
                    if (!LoadMods.Items.Contains(item))
                    {
                        notConsistMods += $"{notConsistMods}\n";
                    }

                    LoadMods.SelectedItem = item;
                    ModOn_Click(sender, e);
                }
            }
            if (notConsistMods != "")
            {
                MessageBox.Show($"Нет всех необходимых модов:\n{notConsistMods}");
            } 
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            PreLoadInfoDirectory();
        }
    }
}
