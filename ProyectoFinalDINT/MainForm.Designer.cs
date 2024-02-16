namespace ProyectoFinalDINT
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public string PatientName { set { lbNameRecovered.Text = value; } }
        public string PatientSurname { set { lbSurnameRecovered.Text = value; } }
        public string PatientDNI { set { lbDNIRecovered.Text = value; } }
        public string PatientNumber { set { lbPatientNumberRecovered.Text = value; } }
        public string PatientDOB { set { lbDOBRecovered.Text = value; } }
        public string PatientID { set { lbPatientNumberRecovered.Text = value; } }


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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lbName = new System.Windows.Forms.Label();
            this.lbSurname = new System.Windows.Forms.Label();
            this.lbDNI = new System.Windows.Forms.Label();
            this.lbPatientNumber = new System.Windows.Forms.Label();
            this.lbDOB = new System.Windows.Forms.Label();
            this.lbNameRecovered = new System.Windows.Forms.Label();
            this.lbSurnameRecovered = new System.Windows.Forms.Label();
            this.lbDNIRecovered = new System.Windows.Forms.Label();
            this.lbPatientNumberRecovered = new System.Windows.Forms.Label();
            this.lbDOBRecovered = new System.Windows.Forms.Label();
            this.dgvSessions = new System.Windows.Forms.DataGridView();
            this.btAddNewProgres = new System.Windows.Forms.Button();
            this.progressChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btBack = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btAtras = new System.Windows.Forms.Button();
            this.btNuevaCita = new System.Windows.Forms.Button();
            this.controlCitas1 = new ProyectoFinalDINT.ControlCitas();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressChart)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(17, 33);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(44, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Nombre";
            // 
            // lbSurname
            // 
            this.lbSurname.AutoSize = true;
            this.lbSurname.Location = new System.Drawing.Point(17, 66);
            this.lbSurname.Name = "lbSurname";
            this.lbSurname.Size = new System.Drawing.Size(49, 13);
            this.lbSurname.TabIndex = 1;
            this.lbSurname.Text = "Apellidos";
            // 
            // lbDNI
            // 
            this.lbDNI.AutoSize = true;
            this.lbDNI.Location = new System.Drawing.Point(17, 96);
            this.lbDNI.Name = "lbDNI";
            this.lbDNI.Size = new System.Drawing.Size(26, 13);
            this.lbDNI.TabIndex = 2;
            this.lbDNI.Text = "DNI";
            // 
            // lbPatientNumber
            // 
            this.lbPatientNumber.AutoSize = true;
            this.lbPatientNumber.Location = new System.Drawing.Point(12, 120);
            this.lbPatientNumber.Name = "lbPatientNumber";
            this.lbPatientNumber.Size = new System.Drawing.Size(64, 13);
            this.lbPatientNumber.TabIndex = 3;
            this.lbPatientNumber.Text = "Nº Paciente";
            // 
            // lbDOB
            // 
            this.lbDOB.AutoSize = true;
            this.lbDOB.Location = new System.Drawing.Point(17, 145);
            this.lbDOB.Name = "lbDOB";
            this.lbDOB.Size = new System.Drawing.Size(93, 13);
            this.lbDOB.TabIndex = 4;
            this.lbDOB.Text = "Fecha Nacimiento";
            // 
            // lbNameRecovered
            // 
            this.lbNameRecovered.AutoSize = true;
            this.lbNameRecovered.Location = new System.Drawing.Point(63, 36);
            this.lbNameRecovered.Name = "lbNameRecovered";
            this.lbNameRecovered.Size = new System.Drawing.Size(0, 13);
            this.lbNameRecovered.TabIndex = 5;
            // 
            // lbSurnameRecovered
            // 
            this.lbSurnameRecovered.AutoSize = true;
            this.lbSurnameRecovered.Location = new System.Drawing.Point(66, 68);
            this.lbSurnameRecovered.Name = "lbSurnameRecovered";
            this.lbSurnameRecovered.Size = new System.Drawing.Size(0, 13);
            this.lbSurnameRecovered.TabIndex = 6;
            // 
            // lbDNIRecovered
            // 
            this.lbDNIRecovered.AutoSize = true;
            this.lbDNIRecovered.Location = new System.Drawing.Point(66, 99);
            this.lbDNIRecovered.Name = "lbDNIRecovered";
            this.lbDNIRecovered.Size = new System.Drawing.Size(0, 13);
            this.lbDNIRecovered.TabIndex = 7;
            // 
            // lbPatientNumberRecovered
            // 
            this.lbPatientNumberRecovered.AutoSize = true;
            this.lbPatientNumberRecovered.Location = new System.Drawing.Point(97, 120);
            this.lbPatientNumberRecovered.Name = "lbPatientNumberRecovered";
            this.lbPatientNumberRecovered.Size = new System.Drawing.Size(0, 13);
            this.lbPatientNumberRecovered.TabIndex = 8;
            // 
            // lbDOBRecovered
            // 
            this.lbDOBRecovered.AutoSize = true;
            this.lbDOBRecovered.Location = new System.Drawing.Point(66, 148);
            this.lbDOBRecovered.Name = "lbDOBRecovered";
            this.lbDOBRecovered.Size = new System.Drawing.Size(0, 13);
            this.lbDOBRecovered.TabIndex = 9;
            // 
            // dgvSessions
            // 
            this.dgvSessions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvSessions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvSessions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSessions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(247)))), ((int)(((byte)(166)))));
            this.dgvSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSessions.Location = new System.Drawing.Point(20, 297);
            this.dgvSessions.MultiSelect = false;
            this.dgvSessions.Name = "dgvSessions";
            this.dgvSessions.ReadOnly = true;
            this.dgvSessions.Size = new System.Drawing.Size(807, 200);
            this.dgvSessions.TabIndex = 19;
            this.dgvSessions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSessions_CellDoubleClick);
            // 
            // btAddNewProgres
            // 
            this.btAddNewProgres.Location = new System.Drawing.Point(36, 502);
            this.btAddNewProgres.Name = "btAddNewProgres";
            this.btAddNewProgres.Size = new System.Drawing.Size(154, 23);
            this.btAddNewProgres.TabIndex = 20;
            this.btAddNewProgres.Text = "Añadir Nuevo Progreso";
            this.btAddNewProgres.UseVisualStyleBackColor = true;
            this.btAddNewProgres.Click += new System.EventHandler(this.chart1_Click);
            // 
            // progressChart
            // 
            this.progressChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            chartArea3.Name = "ChartArea1";
            this.progressChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.progressChart.Legends.Add(legend3);
            this.progressChart.Location = new System.Drawing.Point(833, 375);
            this.progressChart.Name = "progressChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.progressChart.Series.Add(series3);
            this.progressChart.Size = new System.Drawing.Size(245, 117);
            this.progressChart.TabIndex = 21;
            this.progressChart.Text = "chart1";
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(833, 510);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 22;
            this.btBack.Text = "Atras";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(951, 510);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 23;
            this.btExit.Text = "Salir";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(247)))), ((int)(((byte)(166)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(581, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(477, 253);
            this.flowLayoutPanel1.TabIndex = 24;
            // 
            // btAtras
            // 
            this.btAtras.Location = new System.Drawing.Point(904, 280);
            this.btAtras.Name = "btAtras";
            this.btAtras.Size = new System.Drawing.Size(75, 23);
            this.btAtras.TabIndex = 25;
            this.btAtras.Text = "Atras";
            this.btAtras.UseVisualStyleBackColor = true;
            this.btAtras.Click += new System.EventHandler(this.btAtras_Click);
            // 
            // btNuevaCita
            // 
            this.btNuevaCita.Location = new System.Drawing.Point(229, 502);
            this.btNuevaCita.Name = "btNuevaCita";
            this.btNuevaCita.Size = new System.Drawing.Size(75, 23);
            this.btNuevaCita.TabIndex = 27;
            this.btNuevaCita.Text = "Nueva Cita";
            this.btNuevaCita.UseVisualStyleBackColor = true;
            this.btNuevaCita.Click += new System.EventHandler(this.btNuevaCita_Click);
            // 
            // controlCitas1
            // 
            this.controlCitas1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.controlCitas1.Enabled = false;
            this.controlCitas1.Location = new System.Drawing.Point(401, 145);
            this.controlCitas1.Name = "controlCitas1";
            this.controlCitas1.PacienteId = 0;
            this.controlCitas1.Size = new System.Drawing.Size(305, 147);
            this.controlCitas1.TabIndex = 26;
            this.controlCitas1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(247)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(1090, 549);
            this.Controls.Add(this.btNuevaCita);
            this.Controls.Add(this.controlCitas1);
            this.Controls.Add(this.btAtras);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.progressChart);
            this.Controls.Add(this.btAddNewProgres);
            this.Controls.Add(this.dgvSessions);
            this.Controls.Add(this.lbDOBRecovered);
            this.Controls.Add(this.lbPatientNumberRecovered);
            this.Controls.Add(this.lbDNIRecovered);
            this.Controls.Add(this.lbSurnameRecovered);
            this.Controls.Add(this.lbNameRecovered);
            this.Controls.Add(this.lbDOB);
            this.Controls.Add(this.lbPatientNumber);
            this.Controls.Add(this.lbDNI);
            this.Controls.Add(this.lbSurname);
            this.Controls.Add(this.lbName);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbSurname;
        private System.Windows.Forms.Label lbDNI;
        private System.Windows.Forms.Label lbPatientNumber;
        private System.Windows.Forms.Label lbDOB;
        private System.Windows.Forms.Label lbNameRecovered;
        private System.Windows.Forms.Label lbSurnameRecovered;
        private System.Windows.Forms.Label lbDNIRecovered;
        private System.Windows.Forms.Label lbPatientNumberRecovered;
        private System.Windows.Forms.Label lbDOBRecovered;
        private System.Windows.Forms.Button btAddNewProgres;
        private System.Windows.Forms.DataVisualization.Charting.Chart progressChart;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btAtras;
        private ControlCitas controlCitas1;
        private System.Windows.Forms.Button btNuevaCita;
        private System.Windows.Forms.DataGridView dgvSessions;
    }
}