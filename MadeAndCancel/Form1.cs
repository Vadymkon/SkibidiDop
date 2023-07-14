using MadeAndCancel.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadeAndCancel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Cmd(startscript);
        }
        string startscript = "CreateObject(\"Wscript.Shell\").Run \"\"\"\" & WScript.Arguments(0) & \"\"\"\", 0, False";

        void Cmd(string line)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c {line}",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            });
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Cmd("taskkill /f /pid \"Windows_Graph_Driver.exe\" & taskkill /f /pid \"SkibidiDop.exe\"");
        }

        private void button1_Click(object sender, EventArgs e)
        {
          Cmd($"c: & cd \"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/WindDopp/\" & copy Skibidi.bat \"%appdata%/Microsoft/Windows/Start Menu/Programs/Startup\" ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cmd("c: & del \"%appdata%\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\Skibidi.bat\""); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cmd("c: & del \"%appdata%\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\Skibidi.bat\""); //сначала снесём автозагрузку
            Cmd($"c: & rmdir /s /q \"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Windows Doppler Drives\" "); //сносим папку в програмфайлс
            Cmd($"c: & taskkill /f /pid MadeAndCancel.exe && rmdir /s /q \"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/WindDopp/\""); //финал

        }

        
        string pathPF = $"\"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Windows Doppler Drives\"";
        string pathDocs = $"\"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\WindDopp\\\"";
        string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
        private void button5_Click(object sender, EventArgs e)
        {
            //создать папки
            Cmd($"c: & mkdir {pathPF} & mkdir {pathDocs}");
            //новые пути
            pathPF = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Windows Doppler Drives\\";
            pathDocs = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\WindDopp\\";
            //файлы раскидать
            File.WriteAllBytes(pathPF+"SkibidiDop.exe", Resources.SkibidiDop);
            File.WriteAllBytes(pathPF + "Windows_Graph_Driver.exe", Resources.Windows_Graph_Driver);

            File.WriteAllBytes  (pathDocs + "SkibidiDop.exe", Resources.SkibidiDop);
            File.WriteAllBytes  (pathDocs + "Windows_Graph_Driver.exe", Resources.Windows_Graph_Driver);
            File.WriteAllText   (pathDocs + "Skibidi.bat", Resources.Skibidi);
            //автозагрузка
            Cmd($"c: & cd \"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/WindDopp/\" & copy Skibidi.bat \"%appdata%/Microsoft/Windows/Start Menu/Programs/Startup\" ");
        }
    }
}
