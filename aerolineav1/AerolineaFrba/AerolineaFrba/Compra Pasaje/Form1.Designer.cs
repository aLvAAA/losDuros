namespace AerolineaFrba.Compra_Pasaje
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.salidaPicker = new System.Windows.Forms.DateTimePicker();
            this.origenDrop = new System.Windows.Forms.ComboBox();
            this.destinoDrop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Salida";
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(245, 179);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 4;
            this.guardar.Text = "Siguiente";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ciudad Origen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ciudad Destino";
            // 
            // salidaPicker
            // 
            this.salidaPicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.salidaPicker.Location = new System.Drawing.Point(170, 28);
            this.salidaPicker.Name = "salidaPicker";
            this.salidaPicker.Size = new System.Drawing.Size(150, 20);
            this.salidaPicker.TabIndex = 16;
            // 
            // origenDrop
            // 
            this.origenDrop.FormattingEnabled = true;
            this.origenDrop.Location = new System.Drawing.Point(170, 74);
            this.origenDrop.Name = "origenDrop";
            this.origenDrop.Size = new System.Drawing.Size(150, 21);
            this.origenDrop.TabIndex = 17;
            // 
            // destinoDrop
            // 
            this.destinoDrop.FormattingEnabled = true;
            this.destinoDrop.Location = new System.Drawing.Point(170, 120);
            this.destinoDrop.Name = "destinoDrop";
            this.destinoDrop.Size = new System.Drawing.Size(150, 21);
            this.destinoDrop.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 224);
            this.Controls.Add(this.destinoDrop);
            this.Controls.Add(this.origenDrop);
            this.Controls.Add(this.salidaPicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Fecha y ciudades";
            this.Load += new System.EventHandler(this.AltaRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker salidaPicker;
        private System.Windows.Forms.ComboBox origenDrop;
        private System.Windows.Forms.ComboBox destinoDrop;
    }
}