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
            this.stateOfSus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.keyBinded = new System.Windows.Forms.Label();
            this.midiOutComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stateOfSus
            // 
            this.stateOfSus.Location = new System.Drawing.Point(2, 185);
            this.stateOfSus.Name = "stateOfSus";
            this.stateOfSus.Size = new System.Drawing.Size(271, 20);
            this.stateOfSus.TabIndex = 0;
            this.stateOfSus.Text = "Estado: Desactivado";
            this.stateOfSus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(27, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Toca para configurar una tecla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // keyBinded
            // 
            this.keyBinded.Location = new System.Drawing.Point(2, 131);
            this.keyBinded.Name = "keyBinded";
            this.keyBinded.Size = new System.Drawing.Size(271, 25);
            this.keyBinded.TabIndex = 3;
            this.keyBinded.Text = "Tecla configurada: ";
            this.keyBinded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // midiOutComboBox
            // 
            this.midiOutComboBox.FormattingEnabled = true;
            this.midiOutComboBox.Location = new System.Drawing.Point(62, 42);
            this.midiOutComboBox.Name = "midiOutComboBox";
            this.midiOutComboBox.Size = new System.Drawing.Size(151, 28);
            this.midiOutComboBox.TabIndex = 4;
            this.midiOutComboBox.Text = "No Output Device Selected";
            this.midiOutComboBox.SelectedIndexChanged += new System.EventHandler(this.midiOutComboBox_SelectedIndexChanged);
            this.midiOutComboBox.DropDownClosed += new System.EventHandler(this.midiOutComboBox_DropDownClosed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Salida MIDI";
            // 
            // Sustain_Key
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 239);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.midiOutComboBox);
            this.Controls.Add(this.keyBinded);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stateOfSus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Sustain_Key";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sustain Key";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Sustain_Key_MouseDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label stateOfSus;
        private Button button1;
        private Label keyBinded;
        private ComboBox midiOutComboBox;
        private Label label1;
    }
}