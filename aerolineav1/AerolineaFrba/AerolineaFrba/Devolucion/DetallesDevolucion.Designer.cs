namespace AerolineaFrba.Devolucion
{
    partial class DetallesDevolucion
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
            this.motivoBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pasajesBox = new System.Windows.Forms.CheckedListBox();
            this.guardar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.encomiendaCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // motivoBox
            // 
            this.motivoBox.Location = new System.Drawing.Point(98, 194);
            this.motivoBox.Name = "motivoBox";
            this.motivoBox.Size = new System.Drawing.Size(150, 20);
            this.motivoBox.TabIndex = 0;
            this.motivoBox.TextChanged += new System.EventHandler(this.motivoBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Motivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pasajes";
            // 
            // pasajesBox
            // 
            this.pasajesBox.FormattingEnabled = true;
            this.pasajesBox.Location = new System.Drawing.Point(98, 18);
            this.pasajesBox.Name = "pasajesBox";
            this.pasajesBox.Size = new System.Drawing.Size(150, 109);
            this.pasajesBox.TabIndex = 3;
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(173, 242);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 4;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(12, 242);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 5;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Encomienda";
            // 
            // encomiendaCheck
            // 
            this.encomiendaCheck.AutoSize = true;
            this.encomiendaCheck.BackColor = System.Drawing.SystemColors.Control;
            this.encomiendaCheck.Location = new System.Drawing.Point(98, 150);
            this.encomiendaCheck.Name = "encomiendaCheck";
            this.encomiendaCheck.Size = new System.Drawing.Size(15, 14);
            this.encomiendaCheck.TabIndex = 8;
            this.encomiendaCheck.UseVisualStyleBackColor = false;
            // 
            // DetallesDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 277);
            this.Controls.Add(this.encomiendaCheck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.pasajesBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.motivoBox);
            this.Name = "DetallesDevolucion";
            this.Text = "Detalles Devolucion";
            this.Load += new System.EventHandler(this.DetallesDevolucion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox motivoBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox pasajesBox;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox encomiendaCheck;
    }
}