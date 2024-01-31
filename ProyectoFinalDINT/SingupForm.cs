using MySql.Data.MySqlClient;
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
    public partial class SingupForm : Form
    {
        public SingupForm()
        {
            InitializeComponent();
        }

        private void SingupForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!this.tbNewUserPassword.Equals(this.tbNewUserRepeated))
            {
                this.lbNewUserErrorPass.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager("localhost","dint","root","");
            db.Connect();
            String user = tbNewUserName.Text;
            String pass = tbNewUserPassword.Text;
            String repeatedPass = tbNewUserRepeated.Text;

            // Comprobar si los campos están vacíos
            if (String.IsNullOrWhiteSpace(user) || String.IsNullOrWhiteSpace(pass))
            {
                // Mostrar error: los campos no deben estar vacíos
                return;
            }

            // Comprobar si las contraseñas coinciden
            if (pass != repeatedPass)
            {
                this.lbNewUserErrorPass.Visible = true;
                return; // No continuar si las contraseñas no coinciden
            }
            else
            {
                this.lbNewUserErrorPass.Visible = false;
                String query = "INSERT INTO UsuariosPrograma (username, password) VALUES (@user, @pass)";
                db.CrearUsuario(user, pass);
                db.Disconnect();
                this.DialogResult = DialogResult.OK;

            }

            // Prevenir la inyección SQL utilizando parámetros
            
        }

    }
}
