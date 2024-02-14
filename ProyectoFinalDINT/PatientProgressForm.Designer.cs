namespace ProyectoFinalDINT
{
    partial class PatientProgressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbPatientProgress = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.RichTextBox();
            this.btBack = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.lbPatient_id = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Sudoración = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbPatientProgress
            // 
            this.lbPatientProgress.AutoSize = true;
            this.lbPatientProgress.Location = new System.Drawing.Point(46, 41);
            this.lbPatientProgress.Name = "lbPatientProgress";
            this.lbPatientProgress.Size = new System.Drawing.Size(104, 13);
            this.lbPatientProgress.TabIndex = 0;
            this.lbPatientProgress.Text = "Progrso del paciente";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(12, 83);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(649, 279);
            this.tbComment.TabIndex = 1;
            this.tbComment.Text = "";
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(558, 407);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 2;
            this.btBack.Text = "Atras";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(667, 406);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Guardar";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lbPatient_id
            // 
            this.lbPatient_id.AutoSize = true;
            this.lbPatient_id.Location = new System.Drawing.Point(13, 13);
            this.lbPatient_id.Name = "lbPatient_id";
            this.lbPatient_id.Size = new System.Drawing.Size(35, 13);
            this.lbPatient_id.TabIndex = 4;
            this.lbPatient_id.Text = "label1";
            this.lbPatient_id.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(702, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Anxiety Score";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0 - Ninguna",
            "2 - Baja",
            "5 - Media",
            "10 - Alta"});
            this.comboBox1.Location = new System.Drawing.Point(668, 119);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(668, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ansiedad";
            // 
            // Sudoración
            // 
            this.Sudoración.AutoSize = true;
            this.Sudoración.Location = new System.Drawing.Point(667, 174);
            this.Sudoración.Name = "Sudoración";
            this.Sudoración.Size = new System.Drawing.Size(61, 13);
            this.Sudoración.TabIndex = 8;
            this.Sudoración.Text = "Sudoración";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "0 - Ninguna",
            "1 - Sudor en la frente",
            "3 - Sudor en las palmas de la mano",
            "4 - Sudorarcion significativa",
            "10 - Sudoración profusa"});
            this.comboBox2.Location = new System.Drawing.Point(668, 205);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "0 - 60-80 bmp",
            "3 - 81-90 bpm",
            "5 - 91 - 120 bpm",
            "10 - >121 bpm"});
            this.comboBox3.Location = new System.Drawing.Point(668, 288);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(668, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Frecuencia Cardiaca";
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Location = new System.Drawing.Point(671, 328);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(35, 13);
            this.lbScore.TabIndex = 12;
            this.lbScore.Text = "label3";
            // 
            // PatientProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.Sudoración);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPatient_id);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.lbPatientProgress);
            this.Name = "PatientProgressForm";
            this.Text = "PatientProgressForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPatientProgress;
        private System.Windows.Forms.RichTextBox tbComment;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label lbPatient_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Sudoración;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbScore;
    }
}