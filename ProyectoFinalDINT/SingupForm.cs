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
    }
}
