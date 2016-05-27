namespace PagoElectronico.Login
{
    partial class frmLogin
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
            this.btn_acceder = new System.Windows.Forms.Button();
            this.btn_registrarme = new System.Windows.Forms.Button();
            this.l_usuario = new System.Windows.Forms.Label();
            this.l_contraseña = new System.Windows.Forms.Label();
            this.tb_usuario = new System.Windows.Forms.TextBox();
            this.tb_contraseña = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_acceder
            // 
            this.btn_acceder.Location = new System.Drawing.Point(105, 162);
            this.btn_acceder.Name = "btn_acceder";
            this.btn_acceder.Size = new System.Drawing.Size(75, 23);
            this.btn_acceder.TabIndex = 0;
            this.btn_acceder.Text = "Acceder";
            this.btn_acceder.UseVisualStyleBackColor = true;
            this.btn_acceder.Click += new System.EventHandler(this.btn_acceder_Click);
            // 
            // btn_registrarme
            // 
            this.btn_registrarme.Location = new System.Drawing.Point(105, 209);
            this.btn_registrarme.Name = "btn_registrarme";
            this.btn_registrarme.Size = new System.Drawing.Size(75, 23);
            this.btn_registrarme.TabIndex = 1;
            this.btn_registrarme.Text = "Registrarme";
            this.btn_registrarme.UseVisualStyleBackColor = true;
            this.btn_registrarme.Click += new System.EventHandler(this.btn_registrarme_Click);
            // 
            // l_usuario
            // 
            this.l_usuario.AutoSize = true;
            this.l_usuario.Location = new System.Drawing.Point(59, 64);
            this.l_usuario.Name = "l_usuario";
            this.l_usuario.Size = new System.Drawing.Size(43, 13);
            this.l_usuario.TabIndex = 2;
            this.l_usuario.Text = "Usuario";
            // 
            // l_contraseña
            // 
            this.l_contraseña.AutoSize = true;
            this.l_contraseña.Location = new System.Drawing.Point(41, 103);
            this.l_contraseña.Name = "l_contraseña";
            this.l_contraseña.Size = new System.Drawing.Size(61, 13);
            this.l_contraseña.TabIndex = 3;
            this.l_contraseña.Text = "Contraseña";
            // 
            // tb_usuario
            // 
            this.tb_usuario.Location = new System.Drawing.Point(146, 64);
            this.tb_usuario.Name = "tb_usuario";
            this.tb_usuario.Size = new System.Drawing.Size(100, 20);
            this.tb_usuario.TabIndex = 4;
            // 
            // tb_contraseña
            // 
            this.tb_contraseña.Location = new System.Drawing.Point(146, 100);
            this.tb_contraseña.Name = "tb_contraseña";
            this.tb_contraseña.PasswordChar = '*';
            this.tb_contraseña.Size = new System.Drawing.Size(100, 20);
            this.tb_contraseña.TabIndex = 5;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 253);
            this.Controls.Add(this.tb_contraseña);
            this.Controls.Add(this.tb_usuario);
            this.Controls.Add(this.l_contraseña);
            this.Controls.Add(this.l_usuario);
            this.Controls.Add(this.btn_registrarme);
            this.Controls.Add(this.btn_acceder);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_acceder;
        private System.Windows.Forms.Button btn_registrarme;
        private System.Windows.Forms.Label l_usuario;
        private System.Windows.Forms.Label l_contraseña;
        private System.Windows.Forms.TextBox tb_usuario;
        private System.Windows.Forms.TextBox tb_contraseña;
    }
}