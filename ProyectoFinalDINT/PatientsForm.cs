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
    /// Formulario para visualizar y gestionar la lista de pacientes.
    /// </summary>
    public partial class PatientsForm : Form
    {

        /// <summary>
        /// Instancia del gestor de la base de datos para realizar operaciones de datos.
        /// </summary>
        DatabaseManager db = new DatabaseManager();
        public PatientsForm()
        {
            // Establece el estilo de borde del formulario para evitar el redimensionamiento
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Deshabilita el botón de maximizar
            this.MaximizeBox = false;
            InitializeComponent();
            filtroPacientesControl1.FilterChanged += FiltroPacientesControl_FilterChanged;

            // Agregar las columnas "Editar" y "Eliminar" al DataGridView
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "Editar";
            editButtonColumn.Text = "Editar";
            editButtonColumn.UseColumnTextForButtonValue = true;
            dgvPatientTable.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Eliminar";
            deleteButtonColumn.Text = "Eliminar";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dgvPatientTable.Columns.Add(deleteButtonColumn);
        }

        private void dgvPatientTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Verificar si la columna "Editar" fue clickeada
                if (e.ColumnIndex == dgvPatientTable.Columns.Count - 2)
                {
                    // Código para editar el paciente
                    int pacienteId = Convert.ToInt32(dgvPatientTable.Rows[e.RowIndex].Cells["paciente_id"].Value);
                    AddPatientForm editForm = new AddPatientForm(pacienteId);
                    editForm.ShowDialog();
                    actualizarTabla();
                }
                // Verificar si la columna "Eliminar" fue clickeada
                else if (e.ColumnIndex == dgvPatientTable.Columns.Count - 1)
                {
                    // Código para eliminar el paciente
                    if (MessageBox.Show("¿Estás seguro de que quieres eliminar este paciente?", "Eliminar Paciente", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int pacienteId = Convert.ToInt32(dgvPatientTable.Rows[e.RowIndex].Cells["paciente_id"].Value);
                        db.Connect();
                        db.EliminarPaciente(pacienteId);
                        db.Disconnect();
                        actualizarTabla();
                    }
                }
            }
        }


        private void FiltroPacientesControl_FilterChanged(object sender, EventArgs e)
{
    DataTable dt;
            // Dentro de FiltroPacientesControl_FilterChanged en PatientsForm.cs

            if (filtroPacientesControl1.SinConsultaChecked)
            {
                // Filtrar pacientes sin sesiones
                dt = db.FiltrarPacientesSinSesiones();
            }
            else if (filtroPacientesControl1.ConsultaMananaChecked)
            {
                // Filtrar pacientes con sesión mañana
                dt = db.FiltrarPacientesConSesionManana();
            }
            else if (filtroPacientesControl1.ConsultaProximaSemanaChecked)
            {
                // Filtrar pacientes con sesión en los próximos 7 días
                dt = db.FiltrarPacientesConSesionProximaSemana();
            }
            else
            {
                dt = db.LeerPacientes(); // Carga todos los pacientes si ningún filtro está activo
            }
            dgvPatientTable.DataSource = dt; // Actualiza el DataGridView con el resultado filtrado

        }




        public void actualizarTabla()
        {
            try
            {
                db.Connect();
                DataTable dt = db.LeerPacientes();

                // Limpiar columnas existentes
                dgvPatientTable.Columns.Clear();

                // Agregar columnas existentes
                dgvPatientTable.DataSource = dt;

                // Columna para Editar
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                editButtonColumn.HeaderText = "Editar";
                editButtonColumn.Text = "Editar";
                editButtonColumn.UseColumnTextForButtonValue = true;
                dgvPatientTable.Columns.Add(editButtonColumn);

                // Columna para Eliminar
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.HeaderText = "Eliminar";
                deleteButtonColumn.Text = "Eliminar";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                dgvPatientTable.Columns.Add(deleteButtonColumn);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
            }
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

        private void dgvPatientTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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


        private void PatientsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatientTable.SelectedRows.Count > 0 && MessageBox.Show("¿Estás seguro de que quieres eliminar este paciente?", "Eliminar Paciente", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int pacienteId = Convert.ToInt32(dgvPatientTable.SelectedRows[0].Cells["paciente_id"].Value);
                db.Connect();
                db.EliminarPaciente(pacienteId);
                db.Disconnect();
                actualizarTabla();
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatientTable.SelectedRows.Count > 0)
            {
                int pacienteId = Convert.ToInt32(dgvPatientTable.SelectedRows[0].Cells["paciente_id"].Value);
                AddPatientForm editForm = new AddPatientForm(pacienteId); // Asume que AddPatientForm puede tomar un pacienteId para editar
                editForm.ShowDialog();
                actualizarTabla();
            }
        }
    }
}
