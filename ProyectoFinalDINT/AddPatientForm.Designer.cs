namespace ProyectoFinalDINT
{
    partial class AddPatientForm
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
            this.lbAddPatient = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbSurname = new System.Windows.Forms.Label();
            this.lbDNI = new System.Windows.Forms.Label();
            this.lbDOB = new System.Windows.Forms.Label();
            this.lbComments = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.dateDOB = new System.Windows.Forms.DateTimePicker();
            this.tbComments = new System.Windows.Forms.TextBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPatientId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbAddPatient
            // 
            this.lbAddPatient.AutoSize = true;
            this.lbAddPatient.Location = new System.Drawing.Point(37, 37);
            this.lbAddPatient.Name = "lbAddPatient";
            this.lbAddPatient.Size = new System.Drawing.Size(82, 13);
            this.lbAddPatient.TabIndex = 0;
            this.lbAddPatient.Text = "Añadir Paciente";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(37, 123);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(44, 13);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Nombre";
            // 
            // lbSurname
            // 
            this.lbSurname.AutoSize = true;
            this.lbSurname.Location = new System.Drawing.Point(37, 173);
            this.lbSurname.Name = "lbSurname";
            this.lbSurname.Size = new System.Drawing.Size(49, 13);
            this.lbSurname.TabIndex = 2;
            this.lbSurname.Text = "Apellidos";
            // 
            // lbDNI
            // 
            this.lbDNI.AutoSize = true;
            this.lbDNI.Location = new System.Drawing.Point(37, 223);
            this.lbDNI.Name = "lbDNI";
            this.lbDNI.Size = new System.Drawing.Size(26, 13);
            this.lbDNI.TabIndex = 3;
            this.lbDNI.Text = "DNI";
            // 
            // lbDOB
            // 
            this.lbDOB.AutoSize = true;
            this.lbDOB.Location = new System.Drawing.Point(37, 260);
            this.lbDOB.Name = "lbDOB";
            this.lbDOB.Size = new System.Drawing.Size(91, 13);
            this.lbDOB.TabIndex = 5;
            this.lbDOB.Text = "Fecha nacimiento";
            // 
            // lbComments
            // 
            this.lbComments.AutoSize = true;
            this.lbComments.Location = new System.Drawing.Point(37, 308);
            this.lbComments.Name = "lbComments";
            this.lbComments.Size = new System.Drawing.Size(65, 13);
            this.lbComments.TabIndex = 6;
            this.lbComments.Text = "Comentarios";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(165, 110);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 7;
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(165, 160);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(100, 20);
            this.tbSurname.TabIndex = 8;
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(165, 210);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(100, 20);
            this.tbDNI.TabIndex = 9;
            // 
            // dateDOB
            // 
            this.dateDOB.Location = new System.Drawing.Point(165, 252);
            this.dateDOB.Name = "dateDOB";
            this.dateDOB.Size = new System.Drawing.Size(200, 20);
            this.dateDOB.TabIndex = 11;
            // 
            // tbComments
            // 
            this.tbComments.Location = new System.Drawing.Point(165, 300);
            this.tbComments.Multiline = true;
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(376, 127);
            this.tbComments.TabIndex = 12;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(599, 308);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 13;
            this.btAdd.Text = "Añadir Paciente";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(599, 376);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 14;
            this.btCancel.Text = "Cancelar";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Id Paciente";
            this.label1.Visible = false;
            // 
            // lbPatientId
            // 
            this.lbPatientId.AutoSize = true;
            this.lbPatientId.Location = new System.Drawing.Point(165, 71);
            this.lbPatientId.Name = "lbPatientId";
            this.lbPatientId.Size = new System.Drawing.Size(0, 13);
            this.lbPatientId.TabIndex = 16;
            this.lbPatientId.Visible = false;
            // 
            // AddPatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbPatientId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.tbComments);
            this.Controls.Add(this.dateDOB);
            this.Controls.Add(this.tbDNI);
            this.Controls.Add(this.tbSurname);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbComments);
            this.Controls.Add(this.lbDOB);
            this.Controls.Add(this.lbDNI);
            this.Controls.Add(this.lbSurname);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbAddPatient);
            this.Name = "AddPatientForm";
            this.Text = "AddPatientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAddPatient;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbSurname;
        private System.Windows.Forms.Label lbDNI;
        private System.Windows.Forms.Label lbDOB;
        private System.Windows.Forms.Label lbComments;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.DateTimePicker dateDOB;
        private System.Windows.Forms.TextBox tbComments;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPatientId;
    }
}