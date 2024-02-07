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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        

        private void label1_Click(object sender, EventArgs e)
        {
            SingupForm singupForm = new SingupForm();
            singupForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            db.Connect();
            String usuarioLeido = db.SeleccionarPrimerResultado(db.LeerUsuario(tbName.Text));
            String passLeida = db.SeleccionarPrimerResultado(db.LeerPasswordDeUsuario(tbPassword.Text));
            String usuarioIntroducido = tbName.Text;
            String passwordIntroducida = tbPassword.Text;
            if (!String.IsNullOrWhiteSpace(usuarioLeido))
            {
                if (usuarioIntroducido.Equals(usuarioLeido) && passwordIntroducida.Equals(passLeida))
                {
                    PatientsForm pat = new PatientsForm();
                    this.Hide();
                    pat.ShowDialog();


                }
            }
            else
            {
                MessageBox.Show("EL usuario no existe!");
                MessageBox.Show("Si eres Miguél, y estás aporreando el teclado, ya vale");

            }
            db.Disconnect();


            
        }
    }
}
