﻿using System;
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
            string fechaNacimientoStr = fechaNacimiento.ToString("yyyy-MM-dd");
            String comentarios = tbComments.Text;
            PatientsForm patientsForm = new PatientsForm();

            if (conversionExitosa)
            {
                db.CrearPaciente(nombre, apellidos, dNI, fechaNacimientoStr, comentarios);
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
    }
}
