namespace vamo_a_intentar_mandar_midi_a_traves_de_una_tecla_asheiii
{
    partial class Sustain_Key
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            stateOfSus = new Label();
            button1 = new Button();
            keyBinded = new Label();
            midiOutComboBox = new ComboBox();
            label1 = new Label();
            pedalCheck = new CheckBox();
            debugLbl = new Label();
            SuspendLayout();
            // 
            // stateOfSus
            // 
            stateOfSus.Location = new Point(2, 139);
            stateOfSus.Name = "stateOfSus";
            stateOfSus.Size = new Size(237, 15);
            stateOfSus.TabIndex = 0;
            stateOfSus.Text = "Estado: Desactivado";
            stateOfSus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(24, 57);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(192, 22);
            button1.TabIndex = 2;
            button1.Text = "Toca para configurar una tecla";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            button1.KeyDown += button1_KeyDown;
            // 
            // keyBinded
            // 
            keyBinded.Location = new Point(2, 98);
            keyBinded.Name = "keyBinded";
            keyBinded.Size = new Size(237, 19);
            keyBinded.TabIndex = 3;
            keyBinded.Text = "Tecla configurada: ";
            keyBinded.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // midiOutComboBox
            // 
            midiOutComboBox.FormattingEnabled = true;
            midiOutComboBox.Location = new Point(54, 32);
            midiOutComboBox.Margin = new Padding(3, 2, 3, 2);
            midiOutComboBox.Name = "midiOutComboBox";
            midiOutComboBox.Size = new Size(133, 23);
            midiOutComboBox.TabIndex = 4;
            midiOutComboBox.Text = "No Output Device Selected";
            midiOutComboBox.DropDown += midiOutComboBox_DropDown;
            midiOutComboBox.SelectedIndexChanged += midiOutComboBox_SelectedIndexChanged;
            midiOutComboBox.DropDownClosed += midiOutComboBox_DropDownClosed;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 7);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 5;
            label1.Text = "Salida MIDI";
            // 
            // pedalCheck
            // 
            pedalCheck.AutoSize = true;
            pedalCheck.Location = new Point(90, 167);
            pedalCheck.Name = "pedalCheck";
            pedalCheck.Size = new Size(55, 19);
            pedalCheck.TabIndex = 6;
            pedalCheck.Text = "Pedal";
            pedalCheck.TextAlign = ContentAlignment.MiddleCenter;
            pedalCheck.UseVisualStyleBackColor = true;
            pedalCheck.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // debugLbl
            // 
            debugLbl.Location = new Point(2, 189);
            debugLbl.Name = "debugLbl";
            debugLbl.Size = new Size(237, 15);
            debugLbl.TabIndex = 0;
            debugLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Sustain_Key
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(242, 208);
            Controls.Add(pedalCheck);
            Controls.Add(label1);
            Controls.Add(midiOutComboBox);
            Controls.Add(keyBinded);
            Controls.Add(button1);
            Controls.Add(debugLbl);
            Controls.Add(stateOfSus);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Sustain_Key";
            StartPosition = FormStartPosition.Manual;
            Text = "Sustain Key";
            TopMost = true;
            FormClosing += Sustain_Key_FormClosing;
            MouseDown += Sustain_Key_MouseDown;
            Resize += Form1_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label stateOfSus;
        private Button button1;
        private Label keyBinded;
        private ComboBox midiOutComboBox;
        private Label label1;
        private CheckBox pedalCheck;
        private Label debugLbl;
    }
}