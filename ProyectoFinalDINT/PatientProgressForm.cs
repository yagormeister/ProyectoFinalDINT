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

    public partial class PatientProgressForm : Form
    {
        public string PatientID { set { lbPatient_id.Text = value; } }

        public PatientProgressForm()
        {
            InitializeComponent();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            int patientId = int.Parse(lbPatient_id.Text);
            DatabaseManager db = new DatabaseManager();
            db.Connect();
            db.CrearSesion(patientId, DateTime.Today, tbComment.Text,0);
        }
    }
}
