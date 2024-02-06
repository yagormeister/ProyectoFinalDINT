using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDINT
{
    public partial class PatientsForm : Form
    {
        DatabaseManager db = new DatabaseManager();
        public PatientsForm()
        {
            InitializeComponent();
        }

        public void actualizarTabla()
        {
            db.Connect();
            DataTable dt = db.LeerPacientes();
            dgvPatientTable.DataSource = dt;
            db.Disconnect();
        }

        private void PatientsForm_Load(object sender, EventArgs e)
        {
            actualizarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Hide();
            loginForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPatientForm addPatientForm = new AddPatientForm();
            addPatientForm.ShowDialog();
            actualizarTabla();
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            actualizarTabla();
        }

        private void dgvPatientTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que el doble clic sea en una fila válida
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPatientTable.Rows[e.RowIndex];

                // Crea una instancia de MainForm
                MainForm mainForm = new MainForm();

                /*// Establece las propiedades en MainForm con los datos del paciente seleccionado
                mainForm.PatientName = row.Cells["nombre"].Value.ToString();
                mainForm.PatientSurname = row.Cells["apellidos"].Value.ToString();
                mainForm.PatientDNI = row.Cells["dni"].Value.ToString();
                // Suponiendo que tienes un mecanismo para determinar el "PatientNumber"
                // mainForm.PatientNumber = ...;
                mainForm.PatientDOB = ((DateTime)row.Cells["fecha_nacimiento"].Value).ToString("dd/MM/yyyy");*/
                mainForm.PatientID = row.Cells["paciente_id"].Value.ToString();

                // Muestra MainForm
                this.Hide();
                mainForm.ShowDialog();
            }
        }

        private void dgvPatientTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
