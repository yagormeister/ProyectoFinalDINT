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
    /// <summary>
    /// Formulario para añadir o editar la información de un paciente.
    /// </summary>
    public partial class AddPatientForm : Form
    {
        private int pacienteId = 0; // Almacena el ID del paciente para ediciones.
        private Boolean edit = false; // Indica si el formulario se usa para editar.

        /// <summary>
        /// Inicializa una nueva instancia de AddPatientForm para añadir un nuevo paciente.
        /// </summary>
        public AddPatientForm()
        {
            // Configura el formulario para evitar redimensionamiento y deshabilita el botón de maximizar.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            InitializeComponent();
        }

        /// <summary>
        /// Inicializa una nueva instancia de AddPatientForm para editar un paciente existente.
        /// </summary>
        /// <param name="pacienteId">El ID del paciente a editar.</param>
        public AddPatientForm(int pacienteId)
        {
            edit = true;
            this.pacienteId = pacienteId;
            InitializeComponent();

            if (pacienteId > 0)
            {
                // Configura el formulario para la edición de un paciente existente.
                btAdd.Text = "Editar";
                lbAddPatient.Text = "Editar paciente";
                CargarDatosPaciente(pacienteId);
            }
            else
            {
                // Configura el formulario para añadir un nuevo paciente.
                btAdd.Text = "Guardar";
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Añadir/Editar.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btAdd_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            db.Connect();
            String nombre = tbName.Text;
            String apellidos = tbSurname.Text;
            String dNI = tbDNI.Text;

            if (string.IsNullOrEmpty(dNI))
            {
                MessageBox.Show("El DNI no puede estar vacío!");
            }
            else
            {
                DateTime fechaNacimiento = dateDOB.Value;
                String comentarios = tbComments.Text;

                if (edit)
                {
                    db.ActualizarPaciente(pacienteId, nombre, apellidos, dNI, fechaNacimiento, null, null, comentarios);
                    MessageBox.Show("Paciente editado con exito!");

                }
                else
                {
                    db.CrearPaciente(nombre, apellidos, dNI, fechaNacimiento, 0, null, null, comentarios);
                    MessageBox.Show("Paciente creado con exito!");
                }

                db.Disconnect();
                this.Close();
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Cancelar.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Carga y muestra los datos de un paciente en el formulario para su edición.
        /// </summary>
        /// <param name="pacienteId">El ID del paciente cuyos datos se van a cargar.</param>
        public void CargarDatosPaciente(int pacienteId)
        {
            DatabaseManager db = new DatabaseManager();
            db.Connect();
            DataTable datosPaciente = db.LeerPacientePorId(pacienteId);

            if (datosPaciente.Rows.Count > 0)
            {
                DataRow fila = datosPaciente.Rows[0];
                lbPatientId.Text = fila["paciente_id"].ToString();
                tbName.Text = fila["nombre"].ToString();
                tbSurname.Text = fila["apellidos"].ToString();
                tbDNI.Text = fila["dni"].ToString();
                dateDOB.Value = (DateTime)fila["fecha_nacimiento"];
                tbComments.Text = fila["comentario"].ToString();
            }
            db.Disconnect();
        }
    }
}
