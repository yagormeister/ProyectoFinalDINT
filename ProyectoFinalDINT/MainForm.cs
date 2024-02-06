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
    public partial class MainForm : Form
    {
        DatabaseManager db = new DatabaseManager();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            db.Connect();
            DataTable paciente = db.LeerPacientePorId(int.Parse(lbPatientNumberRecovered.Text));
            db.Disconnect();
            if (paciente.Rows.Count > 0)
            {
                DataRow row = paciente.Rows[0]; // Obtener la primera fila

                // Poblar los Labels
                lbNameRecovered.Text = row["nombre"].ToString();
                lbSurnameRecovered.Text = row["apellidos"].ToString();
                lbDNIRecovered.Text = row["dni"].ToString();
                lbDNIRecovered.Text = Convert.ToDateTime(row["fecha_nacimiento"]).ToString("dd/MM/yyyy"); // Formatear la fecha según sea necesario
                                                                                                 // Continúa para los demás Labels que necesites poblar
            }
            else
            {
                MessageBox.Show("Error al leer el paciente!");
            }


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
