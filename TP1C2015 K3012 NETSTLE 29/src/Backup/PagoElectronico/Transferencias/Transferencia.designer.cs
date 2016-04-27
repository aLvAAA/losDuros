namespace PagoElectronico.Transferencias
{
    partial class Transferencia
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_SelDestino = new System.Windows.Forms.Button();
            this.textBox_cuentaDestino = new System.Windows.Forms.TextBox();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.comboBox_moneda = new System.Windows.Forms.ComboBox();
            this.textBox_cuentaOrigen = new System.Windows.Forms.TextBox();
            this.button_SelOrigen = new System.Windows.Forms.Button();
            this.errorProvider_origen = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_dest = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_importe = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_origen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_dest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_importe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuenta origen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cuenta destino:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Importe:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Moneda:";
            // 
            // button_aceptar
            // 
            this.button_aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.Location = new System.Drawing.Point(343, 204);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(75, 28);
            this.button_aceptar.TabIndex = 4;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_SelDestino
            // 
            this.button_SelDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SelDestino.Location = new System.Drawing.Point(329, 66);
            this.button_SelDestino.Name = "button_SelDestino";
            this.button_SelDestino.Size = new System.Drawing.Size(99, 28);
            this.button_SelDestino.TabIndex = 5;
            this.button_SelDestino.Text = "Seleccionar";
            this.button_SelDestino.UseVisualStyleBackColor = true;
            this.button_SelDestino.Click += new System.EventHandler(this.button_SelDestino_Click);
            // 
            // textBox_cuentaDestino
            // 
            this.textBox_cuentaDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_cuentaDestino.Location = new System.Drawing.Point(166, 68);
            this.textBox_cuentaDestino.Name = "textBox_cuentaDestino";
            this.textBox_cuentaDestino.ReadOnly = true;
            this.textBox_cuentaDestino.Size = new System.Drawing.Size(145, 24);
            this.textBox_cuentaDestino.TabIndex = 7;
            // 
            // textBox_importe
            // 
            this.textBox_importe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_importe.Location = new System.Drawing.Point(166, 110);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(145, 24);
            this.textBox_importe.TabIndex = 10;
            this.textBox_importe.TextChanged += new System.EventHandler(this.textBox_importe_TextChanged);
            this.textBox_importe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_importe_KeyPress);
            // 
            // comboBox_moneda
            // 
            this.comboBox_moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_moneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_moneda.FormattingEnabled = true;
            this.comboBox_moneda.Location = new System.Drawing.Point(166, 155);
            this.comboBox_moneda.Name = "comboBox_moneda";
            this.comboBox_moneda.Size = new System.Drawing.Size(145, 26);
            this.comboBox_moneda.TabIndex = 9;
            // 
            // textBox_cuentaOrigen
            // 
            this.textBox_cuentaOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_cuentaOrigen.Location = new System.Drawing.Point(166, 28);
            this.textBox_cuentaOrigen.Name = "textBox_cuentaOrigen";
            this.textBox_cuentaOrigen.ReadOnly = true;
            this.textBox_cuentaOrigen.Size = new System.Drawing.Size(145, 24);
            this.textBox_cuentaOrigen.TabIndex = 11;
            // 
            // button_SelOrigen
            // 
            this.button_SelOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SelOrigen.Location = new System.Drawing.Point(329, 26);
            this.button_SelOrigen.Name = "button_SelOrigen";
            this.button_SelOrigen.Size = new System.Drawing.Size(99, 28);
            this.button_SelOrigen.TabIndex = 12;
            this.button_SelOrigen.Text = "Seleccionar";
            this.button_SelOrigen.UseVisualStyleBackColor = true;
            this.button_SelOrigen.Click += new System.EventHandler(this.button_SelOrigen_Click);
            // 
            // errorProvider_origen
            // 
            this.errorProvider_origen.ContainerControl = this;
            // 
            // errorProvider_dest
            // 
            this.errorProvider_dest.ContainerControl = this;
            // 
            // errorProvider_importe
            // 
            this.errorProvider_importe.ContainerControl = this;
            // 
            // Transferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 249);
            this.Controls.Add(this.button_SelOrigen);
            this.Controls.Add(this.textBox_cuentaOrigen);
            this.Controls.Add(this.comboBox_moneda);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.textBox_cuentaDestino);
            this.Controls.Add(this.button_SelDestino);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Transferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar transferencia";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_origen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_dest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_importe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_SelDestino;
        private System.Windows.Forms.TextBox textBox_cuentaDestino;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.ComboBox comboBox_moneda;
        private System.Windows.Forms.TextBox textBox_cuentaOrigen;
        private System.Windows.Forms.Button button_SelOrigen;
        private System.Windows.Forms.ErrorProvider errorProvider_origen;
        private System.Windows.Forms.ErrorProvider errorProvider_dest;
        private System.Windows.Forms.ErrorProvider errorProvider_importe;
    }
}