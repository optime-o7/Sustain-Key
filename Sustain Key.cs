using System.Diagnostics;

namespace vamo_a_intentar_mandar_midi_a_traves_de_una_tecla_asheiii
{
    public partial class Sustain_Key : Form
    {
        NotifyIcon n = new NotifyIcon();
        int sus = -1;
        bool binding = false;
        string key;

        public Sustain_Key()
        {
            InitializeComponent();
            int w = Screen.PrimaryScreen.WorkingArea.Width, h = Screen.PrimaryScreen.WorkingArea.Size.Height;
            Location = new Point(w - w / 6, h / 25);
            key = Settings1.Default.Key;
            RefreshKeyLabel();
        }

        void ToggleSus(int a)
        {
            if (a == 1) stateOfSus.Text = "Estado: Activado";
            else if (a == -1) stateOfSus.Text = "Estado: Desactivado";
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

        private void button1_Click(object sender, EventArgs e)
        {
            binding = true;
        }

        void RefreshKeyLabel()
        {
            switch (key)
            {
                case "": keyBinded.Text = "No hay ninguna tecla configurada"; break;
                case "Capital": keyBinded.Text = "Tecla configurada: Bloq Mayús"; break;
                default: keyBinded.Text = $"Tecla configurada: {key}"; break;
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (binding)
            {
                key = e.KeyCode.ToString();
                binding = false;
                RefreshKeyLabel();
                Settings1.Default.Key = key;
                Settings1.Default.Save();
            }
            else if (e.KeyCode.ToString() == key)
            {
                ToggleSus(sus * -1);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {

                n.Text = "Sustain Key";
                n.Icon = Icon.ExtractAssociatedIcon("clave-de-sol.ico");
                n.Click += N_Click;
                n.Visible = true;
                Hide();
            }
        }

        private void N_Click(object? sender, EventArgs e)
        {
            n.Visible = false;
            Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}