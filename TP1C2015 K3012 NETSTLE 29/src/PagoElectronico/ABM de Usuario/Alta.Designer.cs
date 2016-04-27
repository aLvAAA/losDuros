namespace PagoElectronico.ABM_de_Usuario
{
    partial class Alta
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
            this.components = new System.ComponentModel.Container();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_respuesta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_pregunta = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_psw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.button_guardar = new System.Windows.Forms.Button();
            this.errorProvider_usr = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_psw = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_pregunta = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_respuesta = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_usr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_psw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_pregunta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_respuesta)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(25, 143);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(152, 18);
            this.label15.TabIndex = 61;
            this.label15.Text = "Respuesta:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_respuesta
            // 
            this.textBox_respuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_respuesta.Location = new System.Drawing.Point(183, 140);
            this.textBox_respuesta.Name = "textBox_respuesta";
            this.textBox_respuesta.Size = new System.Drawing.Size(165, 24);
            this.textBox_respuesta.TabIndex = 60;
            this.textBox_respuesta.UseSystemPasswordChar = true;
            this.textBox_respuesta.TextChanged += new System.EventHandler(this.textBox_respuesta_TextChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(25, 101);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(152, 18);
            this.label14.TabIndex = 59;
            this.label14.Text = "Pregunta:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_pregunta
            // 
            this.textBox_pregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_pregunta.Location = new System.Drawing.Point(183, 98);
            this.textBox_pregunta.Name = "textBox_pregunta";
            this.textBox_pregunta.Size = new System.Drawing.Size(165, 24);
            this.textBox_pregunta.TabIndex = 58;
            this.textBox_pregunta.TextChanged += new System.EventHandler(this.textBox_pregunta_TextChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(25, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(152, 18);
            this.label13.TabIndex = 57;
            this.label13.Text = "Contraseña:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_psw
            // 
            this.textBox_psw.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_psw.Location = new System.Drawing.Point(183, 55);
            this.textBox_psw.Name = "textBox_psw";
            this.textBox_psw.Size = new System.Drawing.Size(165, 24);
            this.textBox_psw.TabIndex = 56;
            this.textBox_psw.UseSystemPasswordChar = true;
            this.textBox_psw.TextChanged += new System.EventHandler(this.textBox_psw_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 18);
            this.label2.TabIndex = 55;
            this.label2.Text = "Nombre de Usuario:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_usuario.Location = new System.Drawing.Point(183, 14);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(165, 24);
            this.textBox_usuario.TabIndex = 54;
            this.textBox_usuario.TextChanged += new System.EventHandler(this.textBox_usuario_TextChanged);
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(273, 180);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 62;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // errorProvider_usr
            // 
            this.errorProvider_usr.ContainerControl = this;
            // 
            // errorProvider_psw
            // 
            this.errorProvider_psw.ContainerControl = this;
            // 
            // errorProvider_pregunta
            // 
            this.errorProvider_pregunta.ContainerControl = this;
            // 
            // errorProvider_respuesta
            // 
            this.errorProvider_respuesta.ContainerControl = this;
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 216);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox_respuesta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox_pregunta);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox_psw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_usuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Alta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_usr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_psw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_pregunta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_respuesta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_respuesta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_pregunta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_psw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.ErrorProvider errorProvider_usr;
        private System.Windows.Forms.ErrorProvider errorProvider_psw;
        private System.Windows.Forms.ErrorProvider errorProvider_pregunta;
        private System.Windows.Forms.ErrorProvider errorProvider_respuesta;
    }
}