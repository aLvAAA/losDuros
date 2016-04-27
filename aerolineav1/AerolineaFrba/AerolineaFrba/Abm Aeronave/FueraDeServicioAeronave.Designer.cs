namespace AerolineaFrba.Abm_Aeronave
{
    partial class FueraDeServicioAeronave
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
            this.siguiente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inicioPicker = new System.Windows.Forms.DateTimePicker();
            this.finPicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(12, 107);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(93, 39);
            this.cancelar.TabIndex = 1;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // siguiente
            // 
            this.siguiente.Location = new System.Drawing.Point(242, 107);
            this.siguiente.Name = "siguiente";
            this.siguiente.Size = new System.Drawing.Size(96, 39);
            this.siguiente.TabIndex = 2;
            this.siguiente.Text = "Siguiente";
            this.siguiente.UseVisualStyleBackColor = true;
            this.siguiente.Click += new System.EventHandler(this.siguiente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inicio fuera de servicio :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fin fuera de servicio :";
            // 
            // inicioPicker
            // 
            this.inicioPicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.inicioPicker.Location = new System.Drawing.Point(170, 19);
            this.inicioPicker.Name = "inicioPicker";
            this.inicioPicker.Size = new System.Drawing.Size(150, 20);
            this.inicioPicker.TabIndex = 17;
            // 
            // finPicker
            // 
            this.finPicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.finPicker.Location = new System.Drawing.Point(170, 59);
            this.finPicker.Name = "finPicker";
            this.finPicker.Size = new System.Drawing.Size(150, 20);
            this.finPicker.TabIndex = 18;
            // 
            // FueraDeServicioAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 158);
            this.Controls.Add(this.finPicker);
            this.Controls.Add(this.inicioPicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.siguiente);
            this.Controls.Add(this.cancelar);
            this.Name = "FueraDeServicioAeronave";
            this.Text = "Fuera de servicio";
            this.Load += new System.EventHandler(this.FueraDeServicioForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button siguiente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker inicioPicker;
        private System.Windows.Forms.DateTimePicker finPicker;
    }
}