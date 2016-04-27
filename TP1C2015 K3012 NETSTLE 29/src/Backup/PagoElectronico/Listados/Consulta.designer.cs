namespace PagoElectronico.Listados
{
    partial class Consulta
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
            this.button_aceptar = new System.Windows.Forms.Button();
            this.comboBox_anios = new System.Windows.Forms.ComboBox();
            this.comboBox_trimestres = new System.Windows.Forms.ComboBox();
            this.comboBox_listados = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_aceptar
            // 
            this.button_aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.Location = new System.Drawing.Point(462, 159);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(75, 27);
            this.button_aceptar.TabIndex = 13;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // comboBox_anios
            // 
            this.comboBox_anios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_anios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_anios.FormattingEnabled = true;
            this.comboBox_anios.Items.AddRange(new object[] {
            "2017",
            "2016",
            "2015",
            "2014",
            "2013",
            "2012",
            "2011",
            "2010"});
            this.comboBox_anios.Location = new System.Drawing.Point(166, 23);
            this.comboBox_anios.Name = "comboBox_anios";
            this.comboBox_anios.Size = new System.Drawing.Size(90, 26);
            this.comboBox_anios.TabIndex = 12;
            // 
            // comboBox_trimestres
            // 
            this.comboBox_trimestres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_trimestres.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_trimestres.FormattingEnabled = true;
            this.comboBox_trimestres.Items.AddRange(new object[] {
            "De Enero a Marzo",
            "De Abril a Junio",
            "De Julio a Septiembre",
            "De Octubre a Diciembre"});
            this.comboBox_trimestres.Location = new System.Drawing.Point(166, 64);
            this.comboBox_trimestres.Name = "comboBox_trimestres";
            this.comboBox_trimestres.Size = new System.Drawing.Size(184, 26);
            this.comboBox_trimestres.TabIndex = 11;
            // 
            // comboBox_listados
            // 
            this.comboBox_listados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_listados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_listados.FormattingEnabled = true;
            this.comboBox_listados.Items.AddRange(new object[] {
            "Clientes con más cuentas inhabilitadas",
            "Clientes con más comisiones facturadas",
            "Clientes con más transacciones entre cuentas propias",
            "Países con más movimientos",
            "Total facturado por tipo de cuenta"});
            this.comboBox_listados.Location = new System.Drawing.Point(166, 112);
            this.comboBox_listados.Name = "comboBox_listados";
            this.comboBox_listados.Size = new System.Drawing.Size(371, 26);
            this.comboBox_listados.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Listado estadístico:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Trimestre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Año:";
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 202);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.comboBox_anios);
            this.Controls.Add(this.comboBox_trimestres);
            this.Controls.Add(this.comboBox_listados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de estadísticas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.ComboBox comboBox_anios;
        private System.Windows.Forms.ComboBox comboBox_trimestres;
        private System.Windows.Forms.ComboBox comboBox_listados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}