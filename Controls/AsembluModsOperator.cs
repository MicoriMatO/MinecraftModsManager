using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftModsManager.Controls
{
    public static class AsembluModsOperator
    {
        public static void CreateNewAsemblyMods(string mods)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.ValidateNames = true;
                sfd.DefaultExt = ".mmmam";
                sfd.FileName = "AsemblyMods";
                sfd.RestoreDirectory = true;
                sfd.OverwritePrompt = true;
                sfd.ShowDialog();

                using (StreamWriter sw = new StreamWriter($@"{sfd.FileName}", false))
                {
                    sw.Write(mods);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        public static string LoadAsemblyMods()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ValidateNames = true;
                ofd.DefaultExt = "*.mmmam";
                ofd.ShowDialog();

                using (StreamReader sr = new StreamReader($@"{ofd.FileName}"))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

            return null;
        }
    }
}
