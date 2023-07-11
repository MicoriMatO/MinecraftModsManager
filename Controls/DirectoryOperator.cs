using Microsoft.Win32;
using MinecraftModsManager.DataApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinecraftModsManager.Controls
{
    public static class DirectoryOperator
    {
        public enum WayGetInfo
        {
            All = 0,
            InGame = 1
        }

        public static List<string> GetInfoDirectory(WayGetInfo turns)
        {
            List<string> inDirectory = new List<string>();
            List<string> listInfo = new List<string>();

            if (turns == WayGetInfo.All)
            {
                listInfo = GetDirectoryesInfo(UserConfig.ModsDirectoryPath);
            }
            if (turns == WayGetInfo.InGame)
            {
                listInfo = GetDirectoryesInfo(UserConfig.GameDirectoryPath);
            }
            
            foreach (var item in listInfo)
            {
                string temp = item.Replace(UserConfig.ModsDirectoryPath + @"\", "");
                temp = temp.Replace(UserConfig.GameDirectoryPath + @"\", "");
                temp = temp.Replace(".jar", "");
                inDirectory.Add(temp);
            }

            return inDirectory;
        }

        private static List<string> GetDirectoryesInfo(string directory)
        {
            List<string> inDirectory = new List<string>();
            try
            {
                string[] directoryes = Directory.GetFiles(directory, "*.jar");
                foreach (string dir in directoryes)
                {
                    inDirectory.Add(dir);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            
            return inDirectory;
        }
        public static void InstallMod(string modName)
        {
            string modNameFrom = $@"{UserConfig.ModsDirectoryPath}\{modName}.jar";
            string modNameTo = $@"{UserConfig.GameDirectoryPath}\{modName}.jar";

            try
            {
                File.Copy(modNameFrom, modNameTo, true);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        public static void UnstallMod(string modName)
        {
            string modNameInGame = $@"{UserConfig.GameDirectoryPath}\{modName}.jar";

            try
            {
                File.Delete(modNameInGame);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
    }  
}
