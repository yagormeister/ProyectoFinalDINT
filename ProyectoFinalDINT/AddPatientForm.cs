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
        public AddPatientForm()
        {
            // Establece el estilo de borde del formulario para evitar el redimensionamiento
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Deshabilita el botón de maximizar
            this.MaximizeBox = false;
            InitializeComponent();
        }

        public AddPatientForm(int pacienteId)  // Llama al constructor predeterminado
        {
            InitializeComponent();
            if (pacienteId > 0)
            {
                // Si es una edición, realiza las acciones de edición
                // Cambia el texto del botón Guardar a "Editar"
                btAdd.Text = "Editar";
                lbAddPatient.Text = "Edtiar paciente";
                // Autocompleta los datos del paciente en los controles correspondientes
                CargarDatosPaciente(pacienteId);
            }
            else
            {
                // Si es un nuevo paciente, deja el botón Guardar como "Guardar"
                btAdd.Text = "Guardar";
            }
        }




        private void btAdd_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            db.Connect();
            String nombre = tbName.Text;
            String apellidos= tbSurname.Text;
            String dNI = tbDNI.Text;
            if (dNI == null||dNI=="")
            {
                MessageBox.Show("El DNI no puede estar vacio!");
            }
            else
            {
                DateTime fechaNacimiento = dateDOB.Value;
                String comentarios = tbComments.Text;
                PatientsForm patientsForm = new PatientsForm();
                db.CrearPaciente(nombre, apellidos, dNI, fechaNacimiento, 0, null, null, comentarios);
                db.Disconnect();
                this.Close();
            }


                
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
                lbPatientId.Text = fila.Field<int>("paciente_id").ToString();
                tbName.Text = fila.Field<string>("nombre");
                tbSurname.Text = fila.Field<string>("apellidos");
                tbDNI.Text = fila.Field<string>("dni");

                // Suponiendo que tienes un control para el número de paciente, lo configurarías aquí
                // tbPatientNumber.Text = ...

                dateDOB.Value = fila.Field<DateTime>("fecha_nacimiento");
                tbComments.Text = fila.Field<string>("comentario");
            }
            db.Disconnect();
        }

    }
}
