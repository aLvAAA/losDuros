namespace AerolineaFrba.Abm_Viaje
{
    partial class AltaViaje
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
            this.label1 = new System.Windows.Forms.Label();
            this.guardar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.salidaPicker = new System.Windows.Forms.DateTimePicker();
            this.llegadaPicker = new System.Windows.Forms.DateTimePicker();
            this.ruta = new System.Windows.Forms.TextBox();
            this.seleccionarRuta = new System.Windows.Forms.Button();
            this.seleccionarAeronave = new System.Windows.Forms.Button();
            this.aeronave = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Salida";
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(245, 247);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 4;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(12, 247);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 5;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha Llegada Estimada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ruta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Aeronave";
            // 
            // salidaPicker
            // 
            this.salidaPicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.salidaPicker.Location = new System.Drawing.Point(170, 28);
            this.salidaPicker.Name = "salidaPicker";
            this.salidaPicker.Size = new System.Drawing.Size(150, 20);
            this.salidaPicker.TabIndex = 16;
            // 
            // llegadaPicker
            // 
            this.llegadaPicker.Location = new System.Drawing.Point(170, 74);
            this.llegadaPicker.Name = "llegadaPicker";
            this.llegadaPicker.Size = new System.Drawing.Size(150, 20);
            this.llegadaPicker.TabIndex = 17;
            // 
            // ruta
            // 
            this.ruta.Location = new System.Drawing.Point(170, 127);
            this.ruta.Name = "ruta";
            this.ruta.ReadOnly = true;
            this.ruta.Size = new System.Drawing.Size(58, 20);
            this.ruta.TabIndex = 18;
            // 
            // seleccionarRuta
            // 
            this.seleccionarRuta.Location = new System.Drawing.Point(244, 125);
            this.seleccionarRuta.Name = "seleccionarRuta";
            this.seleccionarRuta.Size = new System.Drawing.Size(75, 23);
            this.seleccionarRuta.TabIndex = 19;
            this.seleccionarRuta.Text = "Seleccionar";
            this.seleccionarRuta.UseVisualStyleBackColor = true;
            this.seleccionarRuta.Click += new System.EventHandler(this.seleccionarRuta_Click);
            // 
            // seleccionarAeronave
            // 
            this.seleccionarAeronave.Location = new System.Drawing.Point(245, 174);
            this.seleccionarAeronave.Name = "seleccionarAeronave";
            this.seleccionarAeronave.Size = new System.Drawing.Size(75, 23);
            this.seleccionarAeronave.TabIndex = 21;
            this.seleccionarAeronave.Text = "Seleccionar";
            this.seleccionarAeronave.UseVisualStyleBackColor = true;
            this.seleccionarAeronave.Click += new System.EventHandler(this.seleccionarAeronave_Click);
            // 
            // aeronave
            // 
            this.aeronave.Location = new System.Drawing.Point(171, 176);
            this.aeronave.Name = "aeronave";
            this.aeronave.ReadOnly = true;
            this.aeronave.Size = new System.Drawing.Size(58, 20);
            this.aeronave.TabIndex = 20;
            // 
            // AltaViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 286);
            this.Controls.Add(this.seleccionarAeronave);
            this.Controls.Add(this.aeronave);
            this.Controls.Add(this.seleccionarRuta);
            this.Controls.Add(this.ruta);
            this.Controls.Add(this.llegadaPicker);
            this.Controls.Add(this.salidaPicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label1);
            this.Name = "AltaViaje";
            this.Text = "Alta Viaje";
            this.Load += new System.EventHandler(this.AltaViaje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker salidaPicker;
        private System.Windows.Forms.DateTimePicker llegadaPicker;
        private System.Windows.Forms.TextBox ruta;
        private System.Windows.Forms.Button seleccionarRuta;
        private System.Windows.Forms.Button seleccionarAeronave;
        private System.Windows.Forms.TextBox aeronave;
    }
}