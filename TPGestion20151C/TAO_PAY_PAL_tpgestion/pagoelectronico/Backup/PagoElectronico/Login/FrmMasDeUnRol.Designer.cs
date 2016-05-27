namespace PagoElectronico.Login
{
    partial class frmMasDeUnRol
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
            this.cb_RolesDeUsuario = new System.Windows.Forms.ComboBox();
            this.lb_Rol = new System.Windows.Forms.Label();
            this.btn_Seleccionar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_RolesDeUsuario
            // 
            this.cb_RolesDeUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_RolesDeUsuario.FormattingEnabled = true;
            this.cb_RolesDeUsuario.Location = new System.Drawing.Point(81, 50);
            this.cb_RolesDeUsuario.Name = "cb_RolesDeUsuario";
            this.cb_RolesDeUsuario.Size = new System.Drawing.Size(121, 21);
            this.cb_RolesDeUsuario.TabIndex = 0;
            // 
            // lb_Rol
            // 
            this.lb_Rol.AutoSize = true;
            this.lb_Rol.Location = new System.Drawing.Point(49, 53);
            this.lb_Rol.Name = "lb_Rol";
            this.lb_Rol.Size = new System.Drawing.Size(26, 13);
            this.lb_Rol.TabIndex = 1;
            this.lb_Rol.Text = "Rol:";
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.Location = new System.Drawing.Point(208, 48);
            this.btn_Seleccionar.Name = "btn_Seleccionar";
            this.btn_Seleccionar.Size = new System.Drawing.Size(75, 23);
            this.btn_Seleccionar.TabIndex = 2;
            this.btn_Seleccionar.Text = "Seleccionar";
            this.btn_Seleccionar.UseVisualStyleBackColor = true;
            this.btn_Seleccionar.Click += new System.EventHandler(this.btn_Seleccionar_Click);
            // 
            // frmMasDeUnRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 130);
            this.Controls.Add(this.btn_Seleccionar);
            this.Controls.Add(this.lb_Rol);
            this.Controls.Add(this.cb_RolesDeUsuario);
            this.Name = "frmMasDeUnRol";
            this.Text = "Elija el Rol con el cual quiere ingresar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_RolesDeUsuario;
        private System.Windows.Forms.Label lb_Rol;
        private System.Windows.Forms.Button btn_Seleccionar;
    }
}