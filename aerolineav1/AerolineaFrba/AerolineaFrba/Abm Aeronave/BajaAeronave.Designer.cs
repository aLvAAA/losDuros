namespace AerolineaFrba.Abm_Aeronave
{
    partial class BajaAeronaveTipo
    {
        /// <summary>
        /// Required designer variable.
        /// 
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
            this.cancelar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.radioDefinitiva = new System.Windows.Forms.RadioButton();
            this.radioServicio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(12, 99);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(93, 39);
            this.cancelar.TabIndex = 1;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(163, 99);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(96, 39);
            this.aceptar.TabIndex = 2;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // radioDefinitiva
            // 
            this.radioDefinitiva.AutoSize = true;
            this.radioDefinitiva.Location = new System.Drawing.Point(17, 19);
            this.radioDefinitiva.Name = "radioDefinitiva";
            this.radioDefinitiva.Size = new System.Drawing.Size(91, 17);
            this.radioDefinitiva.TabIndex = 3;
            this.radioDefinitiva.TabStop = true;
            this.radioDefinitiva.Text = "Baja definitiva";
            this.radioDefinitiva.UseVisualStyleBackColor = true;
            // 
            // radioServicio
            // 
            this.radioServicio.AutoSize = true;
            this.radioServicio.Location = new System.Drawing.Point(17, 39);
            this.radioServicio.Name = "radioServicio";
            this.radioServicio.Size = new System.Drawing.Size(145, 17);
            this.radioServicio.TabIndex = 4;
            this.radioServicio.TabStop = true;
            this.radioServicio.Text = "Baja por fuera de servicio";
            this.radioServicio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioDefinitiva);
            this.groupBox1.Controls.Add(this.radioServicio);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 70);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de baja";
            // 
            // BajaAeronaveTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 150);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.cancelar);
            this.Name = "BajaAeronaveTipo";
            this.Text = "Baja Aeronave";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.RadioButton radioDefinitiva;
        private System.Windows.Forms.RadioButton radioServicio;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}