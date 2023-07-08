using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinecraftModsManager.Controls
{
    public class DirectoryOperator
    {
        public string ModDirectory { get; set; }
        public string GameDirectory { get; set; }
        public enum WayGetInfo
        {
            All = 0,
            InGame = 1
        }

        public List<string> GetInfoDirectory(WayGetInfo turns)
        {
            List<string> inDirectory = new List<string>();
            List<string> listInfo = new List<string>();

            if (turns == WayGetInfo.All)
            {
                listInfo = GetDirectoryesInfo(ModDirectory);
            }
            if (turns == WayGetInfo.InGame)
            {
                listInfo = GetDirectoryesInfo(GameDirectory);
            }
            
            foreach (var item in listInfo)
            {
                string temp = item.Replace(ModDirectory + @"\", "");
                temp = temp.Replace(GameDirectory + @"\", "");
                temp = temp.Replace(".jar", "");
                inDirectory.Add(temp);
            }

            return inDirectory;
        }

        private List<string> GetDirectoryesInfo(string directory)
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
        public void InstallMod(string modName)
        {
            string modNameFrom = $@"{ModDirectory}\{modName}.jar";
            string modNameTo = $@"{GameDirectory}\{modName}.jar";

            try
            {
                File.Copy(modNameFrom, modNameTo, true);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        public void UnstallMod(string modName)
        {
            string modNameInGame = $@"{GameDirectory}\{modName}.jar";

            try
            {
                File.Delete(modNameInGame);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
    }  
}
