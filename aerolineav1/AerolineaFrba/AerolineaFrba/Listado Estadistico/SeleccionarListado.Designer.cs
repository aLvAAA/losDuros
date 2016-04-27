namespace AerolineaFrba.Listado_Estadistico
{
    partial class SeleccionarListado
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
            this.semestreCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.anio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listadoCombo = new System.Windows.Forms.ComboBox();
            this.siguiente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Semestre";
            // 
            // semestreCombo
            // 
            this.semestreCombo.FormattingEnabled = true;
            this.semestreCombo.Location = new System.Drawing.Point(111, 33);
            this.semestreCombo.Name = "semestreCombo";
            this.semestreCombo.Size = new System.Drawing.Size(48, 21);
            this.semestreCombo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Año";
            // 
            // anio
            // 
            this.anio.Location = new System.Drawing.Point(111, 82);
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(48, 20);
            this.anio.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Listado";
            // 
            // listadoCombo
            // 
            this.listadoCombo.FormattingEnabled = true;
            this.listadoCombo.Location = new System.Drawing.Point(109, 132);
            this.listadoCombo.Name = "listadoCombo";
            this.listadoCombo.Size = new System.Drawing.Size(283, 21);
            this.listadoCombo.TabIndex = 5;
            // 
            // siguiente
            // 
            this.siguiente.Location = new System.Drawing.Point(317, 181);
            this.siguiente.Name = "siguiente";
            this.siguiente.Size = new System.Drawing.Size(75, 23);
            this.siguiente.TabIndex = 6;
            this.siguiente.Text = "Siguiente";
            this.siguiente.UseVisualStyleBackColor = true;
            this.siguiente.Click += new System.EventHandler(this.siguiente_Click);
            // 
            // SeleccionarListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 216);
            this.Controls.Add(this.siguiente);
            this.Controls.Add(this.listadoCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.anio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.semestreCombo);
            this.Controls.Add(this.label1);
            this.Name = "SeleccionarListado";
            this.Text = "Configurar Listado";
            this.Load += new System.EventHandler(this.SeleccionarListado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox semestreCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox anio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox listadoCombo;
        private System.Windows.Forms.Button siguiente;
    }
}