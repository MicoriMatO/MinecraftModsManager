using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using MinecraftModsManager.Controls;

namespace MinecraftModsManager.DataApp
{
    public static class AppManager
    {
        public static void LoadUserConfig()
        {
            string[] line = FileOperator.GetConfig();

            UserConfig.ModsDirectoryPath = line[0].Replace("\r", "");
            UserConfig.GameDirectoryPath = line[1].Replace("\r", "");
        }
        public static void SaveUserConfig()
        {
            string list = "";
            list += $"{UserConfig.ModsDirectoryPath}\n";
            list += $"{UserConfig.GameDirectoryPath}\n";

            FileOperator.SaveConfig(list.Split('\n'));
        }
    }
}
