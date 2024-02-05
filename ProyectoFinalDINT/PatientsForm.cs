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
    }
}
