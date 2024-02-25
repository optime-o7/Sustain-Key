using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Core;
using System.IO.Ports;

namespace vamo_a_intentar_mandar_midi_a_traves_de_una_tecla_asheiii
{
    public partial class Sustain_Key : Form
    {
        SerialPort pedalPort;
        OutputDevice lmao;
        NotifyIcon n = new NotifyIcon();
        int pressState = -1;
        bool binding = false;
        string key = "", port = "";

        public Sustain_Key()
        {
            InitializeComponent();
            LoadSettings();

            int w = Screen.PrimaryScreen.WorkingArea.Width, h = Screen.PrimaryScreen.WorkingArea.Size.Height;
            Location = new Point(w - w / 6, h / 25);
            key = Settings.Default.Key;

            RefreshKey();
            RefreshDevices();
            RefreshPorts();

            try { if (Settings.Default.OutputDevice != "" && OutputDevice.GetByName(Settings.Default.OutputDevice) != null) midiOutComboBox.SelectedItem = Settings.Default.OutputDevice; }
            catch (ArgumentException) { }
        }

        private async void LoadSettings()
        {
            try
            {
                if (Settings.Default.OutputDevice != "" && OutputDevice.GetByName(Settings.Default.OutputDevice) != null) lmao = OutputDevice.GetByName(Settings.Default.OutputDevice);
                if (Settings.Default.pedalPort != "" && SerialPort.GetPortNames().Contains(Settings.Default.pedalPort))
                {
                    port = Settings.Default.pedalPort;
                    var availablePorts = SerialPort.GetPortNames();

                    for (int i = 0; i < availablePorts.Length; i++)
                    {
                        if (availablePorts[i] == port)
                        {
                            serialPortsDrop.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void RefreshDevices()
        {
            midiOutComboBox.Items.Clear();
            int ashei = 0;
            while (ashei < OutputDevice.GetDevicesCount())
            {
                midiOutComboBox.Items.Add(OutputDevice.GetByIndex(ashei).Name);
                ashei++;
            }
        }

        private async void RefreshPorts()
        {
            await Task.Run(() =>
            {
                try
                {
                    Invoke(() =>
                    {
                        serialPortsDrop.Items.Clear();
                        serialPortsDrop.Enabled = false;
                        refreshBtn.Enabled = false;
                        pedalCheck.Enabled = false;
                    });
                }
                catch (Exception)
                {
                    serialPortsDrop.Items.Clear();
                    serialPortsDrop.Enabled = false;
                    refreshBtn.Enabled = false;
                    pedalCheck.Enabled = false;
                }

                foreach (var p in SerialPort.GetPortNames())
                {
                    try
                    {
                        var s = new SerialPort(p, 9600);

                        s.Open();
                        s.Close();

                        Invoke(() => serialPortsDrop.Items.Add(p));
                    }
                    catch (Exception) { }
                }

                Invoke(() =>
                {
                    serialPortsDrop.Enabled = true;
                    refreshBtn.Enabled = true;
                    pedalCheck.Enabled = true;

                    if (port != "") serialPortsDrop.SelectedItem = port;
                });
            });

            if (Settings.Default.pedalOn == true && port == Settings.Default.pedalPort && lmao != null)
            {
                pedalCheck.Checked = true;
                StartPedalListening();
            }
        }

        private void ToggleSus(int a)
        {
            NoteOnEvent ojo;
            if (a == 1)
            {
                Invoke(() => stateOfSus.Text = "Estado: Activado");
                ojo = new((Melanchall.DryWetMidi.Common.SevenBitNumber)1, (Melanchall.DryWetMidi.Common.SevenBitNumber)2);
            }
            else
            {
                Invoke(() => stateOfSus.Text = "Estado: Desactivado");
                ojo = new((Melanchall.DryWetMidi.Common.SevenBitNumber)1, (Melanchall.DryWetMidi.Common.SevenBitNumber)1);
            }
            lmao.SendEvent(ojo);
            pressState = a;
        }

        private void button1_Click(object sender, EventArgs e) => binding = true;

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (binding)
            {
                key = e.KeyCode.ToString();
                RefreshKey();
                Settings.Default.Key = key;
                Settings.Default.Save();

                binding = false;
            }
            else if (lmao != null && e.KeyCode.ToString() == key) ToggleSus(pressState * -1);
        }

        private void RefreshKey()
        {
            switch (key)
            {
                case "": keyBinded.Text = "No hay ninguna tecla configurada"; break;
                case "Capital": keyBinded.Text = "Tecla configurada: Bloq Mayús"; break;
                default: keyBinded.Text = $"Tecla configurada: {key}"; break;
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

        private void midiOutComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.OutputDevice = midiOutComboBox.SelectedItem.ToString();
            Settings.Default.Save();
            lmao = OutputDevice.GetByName(Settings.Default.OutputDevice);
            button1.Focus();
        }

        private void Sustain_Key_MouseDown(object sender, MouseEventArgs e) => button1.Focus();

        private void midiOutComboBox_DropDown(object sender, EventArgs e) => RefreshDevices();

        private async void refreshBtn_Click(object sender, EventArgs e)
        {
            button1.Focus();
            RefreshPorts();
        }

        private void serialPortsDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pedalCheck.Checked) pedalCheck.Checked = false;

            port = serialPortsDrop.SelectedItem.ToString();
            Settings.Default.pedalPort = port;
            Settings.Default.Save();
        }

        private Task PedalListen()
        {
            try
            {
                pedalPort.Open();

                while (pedalCheck.Checked && pedalPort.IsOpen)
                {
                    bool on = ToBool(pedalPort.ReadLine().ReplaceLineEndings(""));

                    if (on)
                    {
                        ToggleSus(1);

                        while (true)
                        {
                            on = ToBool(pedalPort.ReadLine().ReplaceLineEndings(""));

                            if (!on)
                            {
                                ToggleSus(-1);
                                break;
                            }
                        }
                    }
                }

                if (pedalPort.IsOpen) pedalPort.Close();
            } catch (OperationCanceledException) {}

            return new Task(() => { });
        }

        private bool ToBool(string str)
        {
            switch (str)
            {
                case "off": return false;
                case "on": return true;
            }

            return false;
        }

        private async void StartPedalListening()
        {
            if (pedalPort == null || port != "")
            {
                if (pedalPort != null && pedalPort.IsOpen) pedalPort.Close();
                pedalPort = new(port, 9600);

                await Task.Run(PedalListen);
            }
        }

        private void Sustain_Key_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pedalPort != null && pedalPort.IsOpen) pedalPort.Close();
        }

        private void pedalCheck_Click(object sender, EventArgs e)
        {
            button1.Focus();

            bool save = false;

            if (pedalCheck.Checked && port != "" && lmao != null)
            {
                StartPedalListening();
                save = true;
            }
            else if (pedalCheck.Checked) pedalCheck.Checked = false;

            if (!pedalCheck.Checked || (pedalCheck.Checked && save))
            {
                Settings.Default.pedalOn = pedalCheck.Checked;
                Settings.Default.Save();
            }
        }

        private void DropDownClosed(object sender, EventArgs e) => button1.Focus();
    }
}