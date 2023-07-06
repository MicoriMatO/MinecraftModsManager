using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftModsManager.Controls
{
    public class DirectoryOperator
    {
        public string ModDirectory { get; set; }
        public List<string> GetInfoModDirectory()
        {
            List<string> inDirectory = new List<string>();

            foreach (var item in GetDirectoryesInfo(ModDirectory))
            {
                string temp = item.Replace(ModDirectory + @"\", "");
                inDirectory.Add(temp);
            }

            return inDirectory;
        }

        private List<string> GetDirectoryesInfo(string directory)
        {
            List<string> inDirectory = new List<string>();
            try
            {
                string[] directoryes = Directory.GetFiles(directory);
                foreach (string dir in directoryes)
                {
                    inDirectory.Add(dir);
                }
            }
            catch (Exception) { }
            
            return inDirectory;
        }
    }  
}
