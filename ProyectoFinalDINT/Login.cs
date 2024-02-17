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
    /// Formulario de inicio de sesión para la aplicación.
    /// </summary>
    public partial class Login : Form
    {
        /// <summary>
        /// Inicializa una nueva instancia del formulario Login.
        /// </summary>
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Evita el redimensionamiento del formulario.
            this.MaximizeBox = false; // Deshabilita el botón de maximizar.

            // Configura los tooltips para los controles de usuario y contraseña, y el botón de inicio de sesión.
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true; // Muestra los tooltips siempre, sin importar el estado del formulario.

            toolTip1.SetToolTip(this.tbName, "Introduce tu nombre de usuario.");
            toolTip1.SetToolTip(this.tbPassword, "Introduce tu contraseña.");
            toolTip1.SetToolTip(this.btnLogin, "Haz clic para iniciar sesión.");
        }

        /// <summary>
        /// Configura los tooltips cuando el formulario se carga.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void Login_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.tbName, "Introduce tu nombre de usuario.");
            toolTip1.SetToolTip(this.tbPassword, "Introduce tu contraseña.");
            toolTip1.SetToolTip(this.btnLogin, "Haz clic para iniciar sesión.");
        }

        /// <summary>
        /// Abre el formulario de registro al hacer clic en el label de registro.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void label1_Click(object sender, EventArgs e)
        {
            SingupForm singupForm = new SingupForm();
            singupForm.ShowDialog(); // Muestra el formulario de registro como un diálogo modal.
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de inicio de sesión.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            db.Connect(); // Establece conexión con la base de datos.
            String usuarioLeido = db.SeleccionarPrimerResultado(db.LeerUsuario(tbName.Text)); // Lee el nombre de usuario de la base de datos.
            String passLeida = db.SeleccionarPrimerResultado(db.LeerPasswordDeUsuario(tbName.Text)); // Lee la contraseña del usuario de la base de datos.

            String usuarioIntroducido = tbName.Text; // Nombre de usuario introducido en el formulario.
            String passwordIntroducida = tbPassword.Text; // Contraseña introducida en el formulario.

            // Verifica si el usuario y la contraseña introducidos coinciden con los almacenados en la base de datos.
            if (!String.IsNullOrWhiteSpace(usuarioLeido) && usuarioIntroducido.Equals(usuarioLeido) && passwordIntroducida.Equals(passLeida))
            {
                PatientsForm pat = new PatientsForm(); // Crea una nueva instancia del formulario de pacientes.
                this.Hide(); // Oculta el formulario de inicio de sesión.
                pat.ShowDialog(); // Muestra el formulario de pacientes como un diálogo modal.
            }
            else
            {
                MessageBox.Show("EL usuario no existe!"); // Muestra un mensaje de error si el usuario no existe o la contraseña es incorrecta.
            }
            db.Disconnect(); // Cierra la conexión con la base de datos.
        }
    }
}
