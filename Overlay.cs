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
using static Overlay.CheckHotkeys;

namespace vamo_a_intentar_mandar_midi_a_traves_de_una_tecla_asheiii
{
    public partial class Overlay : Form
    {
        public NotifyIcon n = new NotifyIcon();
        int sus = -1;
        string stateOfSus;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                ToggleSus(sus * -1);
                MessageBox.Show("");
            }
            base.WndProc(ref m);
        }

        public Overlay()
        {
            InitializeComponent();
            BackColor = Color.Gray;
            TransparencyKey = Color.Gray;
            n.Text = "Sustain Key";
            n.Icon = Icon.ExtractAssociatedIcon("clave-de-sol.ico");
            n.Click += N_Click;
            n.Visible = true;
            KeyHandler handler = new KeyHandler(0x0000, Keys.ControlKey, this);
            handler.Register();
        }
        void ToggleSus(int a)
        {
            if (a == 1) stateOfSus = "Estado: Activado";
            else if (a == -1) stateOfSus = "Estado: Desactivado";
            ExecuteCommand("sendmidi dev Sustain on 1 1", Directory.GetCurrentDirectory() + @"\");
            sus *= -1;
        }

        void ExecuteCommand(string command, string dir)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", $"/c" + command);
            processInfo.WorkingDirectory = dir;
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }

        private void N_Click(object? sender, EventArgs e)
        {
            n.Visible = false;
            Form1 f = new Form1();
            f.Show();
            f.WindowState = FormWindowState.Normal;
        }
    }
}