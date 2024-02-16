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
    public partial class AddPatientForm : Form
    {
        private int? pacienteId = null;  // Campo opcional para almacenar el ID del paciente

        public AddPatientForm(int pacienteId) : this()  // Llama al constructor predeterminado
        {
            InitializeComponent();
            this.pacienteId = pacienteId;
            CargarDatosPaciente(pacienteId);  // Carga los datos del paciente si se proporciona un ID
        }
        public AddPatientForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            db.Connect();
            String nombre = tbName.Text;
            String apellidos= tbSurname.Text;
            String dNI = tbDNI.Text;
            bool conversionExitosa = int.TryParse(tbPatientNumber.Text, out int numeroPaciente);  //comprobar si es int


            DateTime fechaNacimiento = dateDOB.Value;
            String comentarios = tbComments.Text;
            PatientsForm patientsForm = new PatientsForm();

            if (conversionExitosa)
            {
                db.CrearPaciente(nombre, apellidos,dNI,fechaNacimiento,0, null, null, comentarios);
                db.Disconnect();
                this.Close();
                
            }
            else
                MessageBox.Show("El numero de paciente tiene que ser un numero!");
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void CargarDatosPaciente(int pacienteId)
        {
            DatabaseManager db = new DatabaseManager();
            db.Connect();
            DataTable datosPaciente = db.LeerPacientePorId(pacienteId);

            if (datosPaciente.Rows.Count > 0)
            {
                DataRow fila = datosPaciente.Rows[0];
                tbName.Text = fila["nombre"].ToString();
                tbSurname.Text = fila["apellidos"].ToString();
                tbDNI.Text = fila["dni"].ToString();
                // Suponiendo que tienes un control para el número de paciente, lo configurarías aquí
                // tbPatientNumber.Text = ...
                dateDOB.Value = Convert.ToDateTime(fila["fecha_nacimiento"]);
                tbComments.Text = fila["comentario"].ToString();
                // Configura el campo del ID del paciente como solo lectura (si existe tal campo)
                tbPatientNumber.ReadOnly = true;
            }
            db.Disconnect();
        }
    }
}
