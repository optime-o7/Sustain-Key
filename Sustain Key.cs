using System.Diagnostics;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Core;
using System.IO.Ports;
using Microsoft.VisualBasic;

namespace vamo_a_intentar_mandar_midi_a_traves_de_una_tecla_asheiii
{
    public partial class Sustain_Key : Form
    {
        SerialPort pedalPort = new("COM7", 9600);
        OutputDevice lmao;
        NotifyIcon n = new NotifyIcon();
        int pressState = -1;
        bool binding = false;
        string key;

        public Sustain_Key()
        {
            InitializeComponent();
            try
            {
                if (Settings.Default.OutputDevice != "" && OutputDevice.GetByName(Settings.Default.OutputDevice) != null) lmao = OutputDevice.GetByName(Settings.Default.OutputDevice);
            }
            catch (ArgumentException) { }
            int w = Screen.PrimaryScreen.WorkingArea.Width, h = Screen.PrimaryScreen.WorkingArea.Size.Height;
            Location = new Point(w - w / 6, h / 25);
            key = Settings.Default.Key;
            RefreshKeyLabel();
            RefreshDevices();
            try
            {
                if (Settings.Default.OutputDevice != "" && OutputDevice.GetByName(Settings.Default.OutputDevice) != null) midiOutComboBox.SelectedItem = Settings.Default.OutputDevice;
            }
            catch (ArgumentException) { }
        }

        void RefreshDevices()
        {
            midiOutComboBox.Items.Clear();
            int ashei = 0;
            while (ashei < OutputDevice.GetDevicesCount())
            {
                midiOutComboBox.Items.Add(OutputDevice.GetByIndex(ashei).Name);
                ashei++;
            }
        }

        void ToggleSus(int a)
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
            if (lmao != null)
            {
                if (binding)
                {
                    key = e.KeyCode.ToString();
                    binding = false;
                    RefreshKeyLabel();
                    Settings.Default.Key = key;
                    Settings.Default.Save();
                }
                else if (e.KeyCode.ToString() == key) ToggleSus(pressState * -1);
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

        private void midiOutComboBox_DropDownClosed(object sender, EventArgs e) => button1.Focus();

        private void midiOutComboBox_DropDown(object sender, EventArgs e) => RefreshDevices();

        private Task PedalListen()
        {
            int check = 0, onesQuantity = 4;
            pedalPort.Open();

            while (pedalCheck.Checked && pedalPort.IsOpen)
            {
                bool state = ToBool(pedalPort.ReadLine().ReplaceLineEndings(""));

                if (state == false) check = 0;
                else check++;

                if (check == onesQuantity)
                {
                    ToggleSus(1);

                    check = 0;
                    int offCheck = 0;
                    bool flagged = false;

                    while (true)
                    {
                        state = ToBool(pedalPort.ReadLine().ReplaceLineEndings(""));

                        if (!state)
                        {
                            offCheck++;
                            flagged = false;
                        }
                        else if (flagged) offCheck = 0;
                        else flagged = true;

                        if (offCheck == 2)
                        {
                            ToggleSus(-1);
                            break;
                        }
                    }
                }
            }

            if (pedalPort.IsOpen) pedalPort.Close();
            return null;
        }

        private bool ToBool(string str)
        {
            switch (str)
            {
                case "0": return false;
                case "1": return true;
            }

            return false;
        }

        private async void checkBox1_CheckedChanged(object sender, EventArgs e) { if (pedalCheck.Checked) await Task.Run(PedalListen); }

        private void Sustain_Key_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pedalPort.IsOpen) pedalPort.Close();
        }
    }
}