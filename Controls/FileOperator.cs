using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace MinecraftModsManager.Controls
{
    public static class FileOperator
    {
        public static string[] GetConfig()
        {
            try
            {
                using (StreamReader sr = new StreamReader("UserConfig.mmmcfg"))
                {
                    return sr.ReadToEnd().Split('\n');
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

            return null;
        }
        public static void SaveConfig(string[] line)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("UserConfig.mmmcfg", false))
                {
                    foreach (var item in line)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
    }
}
