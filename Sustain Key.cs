using System.Diagnostics;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Core;

namespace vamo_a_intentar_mandar_midi_a_traves_de_una_tecla_asheiii
{
    public partial class Sustain_Key : Form
    {
        OutputDevice lmao;
        NotifyIcon n = new NotifyIcon();
        int sus = -1;
        bool binding = false;
        string key;

        public Sustain_Key()
        {
            InitializeComponent();
            try
            {
                if (Settings.Default.OutputDevice != "" && OutputDevice.GetByName(Settings.Default.OutputDevice) != null) lmao = OutputDevice.GetByName(Settings.Default.OutputDevice);
            }
            catch (ArgumentException) {}
            int w = Screen.PrimaryScreen.WorkingArea.Width, h = Screen.PrimaryScreen.WorkingArea.Size.Height;
            Location = new Point(w - w / 6, h / 25);
            key = Settings.Default.Key;
            RefreshKeyLabel();
            RefreshDevices();
            try
            {
                if (Settings.Default.OutputDevice != "" && OutputDevice.GetByName(Settings.Default.OutputDevice) != null) midiOutComboBox.SelectedItem = Settings.Default.OutputDevice;
            }
            catch (ArgumentException){}
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
            if (a == 1) stateOfSus.Text = "Estado: Activado";
            else if (a == -1) stateOfSus.Text = "Estado: Desactivado";
            NoteOnEvent ojo = new NoteOnEvent((Melanchall.DryWetMidi.Common.SevenBitNumber)1, (Melanchall.DryWetMidi.Common.SevenBitNumber)1);
            lmao.SendEvent(ojo);
            sus *= -1;
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
                else if (e.KeyCode.ToString() == key)
                {
                    ToggleSus(sus * -1);
                }
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

        private void Sustain_Key_MouseDown(object sender, MouseEventArgs e)
        {
            button1.Focus();
        }

        private void midiOutComboBox_DropDownClosed(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void midiOutComboBox_DropDown(object sender, EventArgs e)
        {
            RefreshDevices();
        }
    }
}