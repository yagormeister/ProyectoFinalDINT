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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            ToolTip toolTip1 = new ToolTip();

            // Configura el tiempo de duración de los ToolTips y el tiempo de espera antes de que se muestren
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            // Permite que el ToolTip aparezca aunque el formulario esté inactivo
            toolTip1.ShowAlways = true;

            // Establece los ToolTips para varios controles
            toolTip1.SetToolTip(this.tbName, "Introduce tu nombre de usuario.");
            toolTip1.SetToolTip(this.tbPassword, "Introduce tu contraseña.");
            toolTip1.SetToolTip(this.btnLogin, "Haz clic para iniciar sesión.");

        }
        private void Login_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Configuraciones del ToolTip
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            // Establece los ToolTips
            toolTip1.SetToolTip(this.tbName, "Introduce tu nombre de usuario.");
            toolTip1.SetToolTip(this.tbPassword, "Introduce tu contraseña.");
            toolTip1.SetToolTip(this.btnLogin, "Haz clic para iniciar sesión.");
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

            }
            db.Disconnect();


            
        }


    }
}
