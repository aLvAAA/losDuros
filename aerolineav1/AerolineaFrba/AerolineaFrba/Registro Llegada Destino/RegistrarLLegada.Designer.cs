namespace AerolineaFrba.Registro_destino
{
    partial class RegistrarLlegada
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
            this.previo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.datosAeronave = new System.Windows.Forms.DataGridView();
            this.llegadaPicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.datosAeronave)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aeronave";
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(728, 227);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 4;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // previo
            // 
            this.previo.Location = new System.Drawing.Point(11, 227);
            this.previo.Name = "previo";
            this.previo.Size = new System.Drawing.Size(75, 23);
            this.previo.TabIndex = 5;
            this.previo.Text = "Previo";
            this.previo.UseVisualStyleBackColor = true;
            this.previo.Click += new System.EventHandler(this.previo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Llegada";
            // 
            // datosAeronave
            // 
            this.datosAeronave.AllowUserToAddRows = false;
            this.datosAeronave.AllowUserToDeleteRows = false;
            this.datosAeronave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datosAeronave.Location = new System.Drawing.Point(16, 55);
            this.datosAeronave.Name = "datosAeronave";
            this.datosAeronave.ReadOnly = true;
            this.datosAeronave.Size = new System.Drawing.Size(787, 68);
            this.datosAeronave.TabIndex = 9;
            // 
            // llegadaPicker
            // 
            this.llegadaPicker.Location = new System.Drawing.Point(112, 163);
            this.llegadaPicker.Name = "llegadaPicker";
            this.llegadaPicker.Size = new System.Drawing.Size(200, 20);
            this.llegadaPicker.TabIndex = 10;
            // 
            // RegistrarLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 262);
            this.Controls.Add(this.llegadaPicker);
            this.Controls.Add(this.datosAeronave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.previo);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label1);
            this.Name = "RegistrarLlegada";
            this.Text = "Registrar llegada";
            this.Load += new System.EventHandler(this.RegistrarLlegada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datosAeronave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Button previo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView datosAeronave;
        private System.Windows.Forms.DateTimePicker llegadaPicker;
    }
}