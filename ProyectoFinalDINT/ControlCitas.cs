using PracticaDINTproyecto.Clases;
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
    public partial class ControlCitas : UserControl
    {
        public int PacienteId { get; set; }


        public ControlCitas()
        {
            InitializeComponent();
            btAccept.Click += BtAccept_Click;
            btCancel.Click += BtCancel_Click;
        }
        private void BtAccept_Click(object sender, EventArgs e)
        {
            // Aquí implementas la lógica para actualizar la próxima cita del paciente en la base de datos
            DatabaseManager db = new DatabaseManager();
            db.Connect();
            // Asume que tienes un método en DatabaseManager para actualizar la próxima cita del paciente
            db.ActualizarProximaCita(PacienteId, dateTimePicker1.Value);
            db.Disconnect();
            MessageBox.Show("Cita actualizada con éxito.");
            this.Hide();
            // Aquí puedes cerrar el control o realizar otras acciones necesarias
        }
        private void BtCancel_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }
    }
}
