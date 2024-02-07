namespace ProyectoFinalDINT
{
    partial class SingupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbNewUser = new System.Windows.Forms.Label();
            this.lbNewUserName = new System.Windows.Forms.Label();
            this.lbNewUserPass = new System.Windows.Forms.Label();
            this.lbNewUserRepeatP = new System.Windows.Forms.Label();
            this.tbNewUserName = new System.Windows.Forms.TextBox();
            this.tbNewUserPassword = new System.Windows.Forms.TextBox();
            this.tbNewUserRepeated = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lbNewUserErrorPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbNewUser
            // 
            this.lbNewUser.AutoSize = true;
            this.lbNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewUser.Location = new System.Drawing.Point(12, 9);
            this.lbNewUser.Name = "lbNewUser";
            this.lbNewUser.Size = new System.Drawing.Size(634, 76);
            this.lbNewUser.TabIndex = 0;
            this.lbNewUser.Text = "Crear nuevo usuario";
            // 
            // lbNewUserName
            // 
            this.lbNewUserName.AutoSize = true;
            this.lbNewUserName.Location = new System.Drawing.Point(69, 152);
            this.lbNewUserName.Name = "lbNewUserName";
            this.lbNewUserName.Size = new System.Drawing.Size(44, 13);
            this.lbNewUserName.TabIndex = 1;
            this.lbNewUserName.Text = "Nombre";
            // 
            // lbNewUserPass
            // 
            this.lbNewUserPass.AutoSize = true;
            this.lbNewUserPass.Location = new System.Drawing.Point(72, 205);
            this.lbNewUserPass.Name = "lbNewUserPass";
            this.lbNewUserPass.Size = new System.Drawing.Size(61, 13);
            this.lbNewUserPass.TabIndex = 2;
            this.lbNewUserPass.Text = "Contraseña";
            // 
            // lbNewUserRepeatP
            // 
            this.lbNewUserRepeatP.AutoSize = true;
            this.lbNewUserRepeatP.Location = new System.Drawing.Point(72, 264);
            this.lbNewUserRepeatP.Name = "lbNewUserRepeatP";
            this.lbNewUserRepeatP.Size = new System.Drawing.Size(97, 13);
            this.lbNewUserRepeatP.TabIndex = 3;
            this.lbNewUserRepeatP.Text = "Repetir contraseña";
            // 
            // tbNewUserName
            // 
            this.tbNewUserName.Location = new System.Drawing.Point(184, 145);
            this.tbNewUserName.Name = "tbNewUserName";
            this.tbNewUserName.Size = new System.Drawing.Size(100, 20);
            this.tbNewUserName.TabIndex = 4;
            // 
            // tbNewUserPassword
            // 
            this.tbNewUserPassword.Location = new System.Drawing.Point(184, 198);
            this.tbNewUserPassword.Name = "tbNewUserPassword";
            this.tbNewUserPassword.Size = new System.Drawing.Size(100, 20);
            this.tbNewUserPassword.TabIndex = 5;
            this.tbNewUserPassword.UseSystemPasswordChar = true;
            // 
            // tbNewUserRepeated
            // 
            this.tbNewUserRepeated.Location = new System.Drawing.Point(184, 257);
            this.tbNewUserRepeated.Name = "tbNewUserRepeated";
            this.tbNewUserRepeated.Size = new System.Drawing.Size(100, 20);
            this.tbNewUserRepeated.TabIndex = 6;
            this.tbNewUserRepeated.UseSystemPasswordChar = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(276, 334);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(433, 333);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Crear";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lbNewUserErrorPass
            // 
            this.lbNewUserErrorPass.AutoSize = true;
            this.lbNewUserErrorPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewUserErrorPass.ForeColor = System.Drawing.Color.Red;
            this.lbNewUserErrorPass.Location = new System.Drawing.Point(323, 255);
            this.lbNewUserErrorPass.Name = "lbNewUserErrorPass";
            this.lbNewUserErrorPass.Size = new System.Drawing.Size(271, 25);
            this.lbNewUserErrorPass.TabIndex = 9;
            this.lbNewUserErrorPass.Text = "Las contraseñas no coindicen";
            this.lbNewUserErrorPass.Visible = false;
            // 
            // SingupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbNewUserErrorPass);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbNewUserRepeated);
            this.Controls.Add(this.tbNewUserPassword);
            this.Controls.Add(this.tbNewUserName);
            this.Controls.Add(this.lbNewUserRepeatP);
            this.Controls.Add(this.lbNewUserPass);
            this.Controls.Add(this.lbNewUserName);
            this.Controls.Add(this.lbNewUser);
            this.Name = "SingupForm";
            this.Text = "SingupForm";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SingupForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNewUser;
        private System.Windows.Forms.Label lbNewUserName;
        private System.Windows.Forms.Label lbNewUserPass;
        private System.Windows.Forms.Label lbNewUserRepeatP;
        private System.Windows.Forms.TextBox tbNewUserName;
        private System.Windows.Forms.TextBox tbNewUserPassword;
        private System.Windows.Forms.TextBox tbNewUserRepeated;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lbNewUserErrorPass;
    }
}