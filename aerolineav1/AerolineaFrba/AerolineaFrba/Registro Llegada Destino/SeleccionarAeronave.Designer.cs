namespace AerolineaFrba.Registro_destino
{
    partial class SeleccionarAeronave
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
            this.matriculaBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guardar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.origenDrop = new System.Windows.Forms.ComboBox();
            this.destinoDrop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // matriculaBox
            // 
            this.matriculaBox.Location = new System.Drawing.Point(122, 28);
            this.matriculaBox.Name = "matriculaBox";
            this.matriculaBox.Size = new System.Drawing.Size(150, 20);
            this.matriculaBox.TabIndex = 0;
            this.matriculaBox.TextChanged += new System.EventHandler(this.matriculaBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matrícula";
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(197, 183);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 4;
            this.guardar.Text = "Siguiente";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(12, 183);
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
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ciudad Origen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ciudad Destino";
            // 
            // origenDrop
            // 
            this.origenDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.origenDrop.FormattingEnabled = true;
            this.origenDrop.Location = new System.Drawing.Point(122, 74);
            this.origenDrop.Name = "origenDrop";
            this.origenDrop.Size = new System.Drawing.Size(150, 21);
            this.origenDrop.TabIndex = 8;
            // 
            // destinoDrop
            // 
            this.destinoDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinoDrop.FormattingEnabled = true;
            this.destinoDrop.Location = new System.Drawing.Point(122, 129);
            this.destinoDrop.Name = "destinoDrop";
            this.destinoDrop.Size = new System.Drawing.Size(150, 21);
            this.destinoDrop.TabIndex = 9;
            // 
            // SeleccionarAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 221);
            this.Controls.Add(this.destinoDrop);
            this.Controls.Add(this.origenDrop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.matriculaBox);
            this.Name = "SeleccionarAeronave";
            this.Text = "Seleccionar Aeronave";
            this.Load += new System.EventHandler(this.SeleccionarAeronave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox matriculaBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox origenDrop;
        private System.Windows.Forms.ComboBox destinoDrop;
    }
}