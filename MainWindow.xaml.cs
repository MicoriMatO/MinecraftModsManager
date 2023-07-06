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

namespace MinecraftModsManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DirectoryOperator dirOper = new DirectoryOperator();

        //list будет хранить только название мода
        public MainWindow()
        {
            InitializeComponent();

            dirOper.ModDirectory = @"D:\Downloads\клиент";
            PreLoadInfoDirectory();
        }

        private void PreLoadInfoDirectory()
        {
            foreach (var item in dirOper.GetInfoModDirectory())
            {
                LoadMods.Items.Add(item);
            }
        }

        private void ModOn_Click(object sender, RoutedEventArgs e)
        {
            SwitchList(LoadMods, ModsInGame);
            // скопировать из пула модов в игру
                // DirectoriOperator
        }
        private void ModOff_Click(object sender, RoutedEventArgs e)
        {
            SwitchList(ModsInGame, LoadMods);
            //удалить из папки с игрой скопированые файлы
        }

        private void SwitchList(ListBox from, ListBox to)
        {
            to.Items.Add(from.SelectedItem);
            from.Items.Remove(from.SelectedItem);
        }

        
    }
}
