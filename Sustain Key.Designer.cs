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
            serialPortsDrop = new ComboBox();
            refreshBtn = new Button();
            SuspendLayout();
            // 
            // stateOfSus
            // 
            stateOfSus.Location = new Point(2, 116);
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
            keyBinded.Location = new Point(2, 81);
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
            midiOutComboBox.DropDownClosed += DropDownClosed;
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
            pedalCheck.Location = new Point(90, 182);
            pedalCheck.Name = "pedalCheck";
            pedalCheck.Size = new Size(55, 19);
            pedalCheck.TabIndex = 6;
            pedalCheck.Text = "Pedal";
            pedalCheck.TextAlign = ContentAlignment.MiddleCenter;
            pedalCheck.UseVisualStyleBackColor = true;
            pedalCheck.Click += pedalCheck_Click;
            // 
            // serialPortsDrop
            // 
            serialPortsDrop.FormattingEnabled = true;
            serialPortsDrop.Location = new Point(54, 154);
            serialPortsDrop.Margin = new Padding(3, 2, 3, 2);
            serialPortsDrop.Name = "serialPortsDrop";
            serialPortsDrop.Size = new Size(133, 23);
            serialPortsDrop.TabIndex = 4;
            serialPortsDrop.Text = "No Output Device Selected";
            serialPortsDrop.SelectedIndexChanged += serialPortsDrop_SelectedIndexChanged;
            serialPortsDrop.DropDownClosed += DropDownClosed;
            // 
            // refreshBtn
            // 
            refreshBtn.FlatAppearance.BorderSize = 0;
            refreshBtn.FlatStyle = FlatStyle.Flat;
            refreshBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            refreshBtn.Location = new Point(191, 154);
            refreshBtn.Margin = new Padding(3, 2, 3, 2);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(25, 25);
            refreshBtn.TabIndex = 2;
            refreshBtn.Text = "🔄️";
            refreshBtn.TextAlign = ContentAlignment.TopCenter;
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // Sustain_Key
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(242, 208);
            Controls.Add(pedalCheck);
            Controls.Add(label1);
            Controls.Add(serialPortsDrop);
            Controls.Add(midiOutComboBox);
            Controls.Add(keyBinded);
            Controls.Add(refreshBtn);
            Controls.Add(button1);
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
        private ComboBox serialPortsDrop;
        private Button refreshBtn;
    }
}