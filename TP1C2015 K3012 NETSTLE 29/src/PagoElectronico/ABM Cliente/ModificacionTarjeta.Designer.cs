namespace PagoElectronico.ABM_Cliente
{
    partial class ModificacionTarjeta
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_tarjeta = new System.Windows.Forms.TextBox();
            this.button_buscar = new System.Windows.Forms.Button();
            this.button_guardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_fech_ven = new System.Windows.Forms.TextBox();
            this.button_fecha = new System.Windows.Forms.Button();
            this.comboBox_emisores = new System.Windows.Forms.ComboBox();
            this.errorProvider_tarjeta = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_fecha = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_habilitada = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_tarjeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_fecha)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarjeta de crédito:";
            // 
            // textBox_tarjeta
            // 
            this.textBox_tarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_tarjeta.Location = new System.Drawing.Point(212, 35);
            this.textBox_tarjeta.Name = "textBox_tarjeta";
            this.textBox_tarjeta.ReadOnly = true;
            this.textBox_tarjeta.Size = new System.Drawing.Size(136, 24);
            this.textBox_tarjeta.TabIndex = 1;
            // 
            // button_buscar
            // 
            this.button_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_buscar.Location = new System.Drawing.Point(383, 28);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 31);
            this.button_buscar.TabIndex = 2;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // button_guardar
            // 
            this.button_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_guardar.Location = new System.Drawing.Point(383, 204);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 31);
            this.button_guardar.TabIndex = 3;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Emisor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha de vencimiento:";
            // 
            // textBox_fech_ven
            // 
            this.textBox_fech_ven.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_fech_ven.Location = new System.Drawing.Point(212, 118);
            this.textBox_fech_ven.Name = "textBox_fech_ven";
            this.textBox_fech_ven.ReadOnly = true;
            this.textBox_fech_ven.Size = new System.Drawing.Size(136, 24);
            this.textBox_fech_ven.TabIndex = 7;
            // 
            // button_fecha
            // 
            this.button_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_fecha.Location = new System.Drawing.Point(368, 111);
            this.button_fecha.Name = "button_fecha";
            this.button_fecha.Size = new System.Drawing.Size(108, 31);
            this.button_fecha.TabIndex = 8;
            this.button_fecha.Text = "Seleccionar";
            this.button_fecha.UseVisualStyleBackColor = true;
            this.button_fecha.Click += new System.EventHandler(this.button_fecha_Click_1);
            // 
            // comboBox_emisores
            // 
            this.comboBox_emisores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_emisores.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_emisores.FormattingEnabled = true;
            this.comboBox_emisores.Location = new System.Drawing.Point(212, 74);
            this.comboBox_emisores.Name = "comboBox_emisores";
            this.comboBox_emisores.Size = new System.Drawing.Size(136, 26);
            this.comboBox_emisores.TabIndex = 9;
            // 
            // errorProvider_tarjeta
            // 
            this.errorProvider_tarjeta.ContainerControl = this;
            // 
            // errorProvider_fecha
            // 
            this.errorProvider_fecha.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Habilitada:";
            // 
            // comboBox_habilitada
            // 
            this.comboBox_habilitada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_habilitada.Enabled = false;
            this.comboBox_habilitada.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_habilitada.FormattingEnabled = true;
            this.comboBox_habilitada.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.comboBox_habilitada.Location = new System.Drawing.Point(212, 167);
            this.comboBox_habilitada.Name = "comboBox_habilitada";
            this.comboBox_habilitada.Size = new System.Drawing.Size(136, 26);
            this.comboBox_habilitada.TabIndex = 12;
            // 
            // ModificacionTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 255);
            this.Controls.Add(this.comboBox_habilitada);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_emisores);
            this.Controls.Add(this.button_fecha);
            this.Controls.Add(this.textBox_fech_ven);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.button_buscar);
            this.Controls.Add(this.textBox_tarjeta);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModificacionTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificación de tarjeta";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_tarjeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_fecha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_tarjeta;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_fech_ven;
        private System.Windows.Forms.Button button_fecha;
        private System.Windows.Forms.ComboBox comboBox_emisores;
        private System.Windows.Forms.ErrorProvider errorProvider_tarjeta;
        private System.Windows.Forms.ErrorProvider errorProvider_fecha;
        private System.Windows.Forms.ComboBox comboBox_habilitada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}