namespace ProyectoFinalDINT
{
    partial class PatientsForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvPatientTable = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.filtroPacientesControl1 = new ProyectoFinalDINT.FiltroPacientesControl();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientTable)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 52);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 24);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(211, 24);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // dgvPatientTable
            // 
            this.dgvPatientTable.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.dgvPatientTable.AllowUserToAddRows = false;
            this.dgvPatientTable.AllowUserToDeleteRows = false;
            this.dgvPatientTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPatientTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatientTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvPatientTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(247)))), ((int)(((byte)(166)))));
            this.dgvPatientTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPatientTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvPatientTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatientTable.Location = new System.Drawing.Point(-16, 98);
            this.dgvPatientTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPatientTable.Name = "dgvPatientTable";
            this.dgvPatientTable.ReadOnly = true;
            this.dgvPatientTable.RowHeadersWidth = 51;
            this.dgvPatientTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatientTable.Size = new System.Drawing.Size(1338, 345);
            this.dgvPatientTable.TabIndex = 2;
            this.dgvPatientTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatientTable_CellClick);
            this.dgvPatientTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatientTable_CellContentClick);
            this.dgvPatientTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatientTable_CellDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1252, 399);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Añadir Paciente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1252, 460);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // filtroPacientesControl1
            // 
            this.filtroPacientesControl1.Location = new System.Drawing.Point(16, 60);
            this.filtroPacientesControl1.Margin = new System.Windows.Forms.Padding(5);
            this.filtroPacientesControl1.Name = "filtroPacientesControl1";
            this.filtroPacientesControl1.Size = new System.Drawing.Size(1023, 30);
            this.filtroPacientesControl1.TabIndex = 9;
            // 
            // PatientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1397, 554);
            this.Controls.Add(this.filtroPacientesControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPatientTable);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PatientsForm";
            this.Text = "Pacientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PatientsForm_FormClosing);
            this.Load += new System.EventHandler(this.PatientsForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.DataGridView dgvPatientTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private FiltroPacientesControl filtroPacientesControl1;
    }
}