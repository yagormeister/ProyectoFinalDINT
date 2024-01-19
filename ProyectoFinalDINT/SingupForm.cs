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
            Boolean correctPass=false;
           
                if (this.tbNewUserPassword.Text != this.tbNewUserRepeated.Text)
                {
                    this.lbNewUserErrorPass.Visible = true;
            }
            else
            {
                this.lbNewUserErrorPass.Visible = false;
            }
                    
        }
    }
}
