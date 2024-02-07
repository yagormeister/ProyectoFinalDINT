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
            this.tbComment.Size = new System.Drawing.Size(776, 355);
            this.tbComment.TabIndex = 1;
            this.tbComment.Text = "";
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(552, 41);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 2;
            this.btBack.Text = "Atras";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(661, 40);
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
            // PatientProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}