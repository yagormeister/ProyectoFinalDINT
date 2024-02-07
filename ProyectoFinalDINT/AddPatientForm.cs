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
                db.CrearPaciente(nombre, apellidos,dNI,fechaNacimiento,0, null, null, null);
                db.Disconnect();
                this.Close();
                
            }
            else
                MessageBox.Show("El numero de paciente tiene que ser un numero!");
                MessageBox.Show("Si eres Miguel y estas intentando romperme el programa, ya te vale");
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
