namespace PagoElectronico.ABM_Cliente
{
    partial class AltaTarjeta
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
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_numero = new System.Windows.Forms.TextBox();
            this.comboBox_emisores = new System.Windows.Forms.ComboBox();
            this.textBox_fech_emi = new System.Windows.Forms.TextBox();
            this.textBox_fech_ven = new System.Windows.Forms.TextBox();
            this.textBox_codigo = new System.Windows.Forms.TextBox();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.errorProvider_numero = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_fecha = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_codigo = new System.Windows.Forms.ErrorProvider(this.components);
            this.button_sel_fecha = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_tipo_doc = new System.Windows.Forms.TextBox();
            this.textBox_nro_doc = new System.Windows.Forms.TextBox();
            this.button_buscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_numero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_fecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_codigo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Emisor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de emisión:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de vencimiento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Código de seguridad:";
            // 
            // textBox_numero
            // 
            this.textBox_numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_numero.Location = new System.Drawing.Point(242, 83);
            this.textBox_numero.Name = "textBox_numero";
            this.textBox_numero.Size = new System.Drawing.Size(137, 24);
            this.textBox_numero.TabIndex = 5;
            this.textBox_numero.TextChanged += new System.EventHandler(this.textBox_numero_TextChanged);
            this.textBox_numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_numero_KeyPress);
            // 
            // comboBox_emisores
            // 
            this.comboBox_emisores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_emisores.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_emisores.FormattingEnabled = true;
            this.comboBox_emisores.Location = new System.Drawing.Point(242, 118);
            this.comboBox_emisores.Name = "comboBox_emisores";
            this.comboBox_emisores.Size = new System.Drawing.Size(137, 26);
            this.comboBox_emisores.TabIndex = 6;
            // 
            // textBox_fech_emi
            // 
            this.textBox_fech_emi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_fech_emi.Location = new System.Drawing.Point(242, 155);
            this.textBox_fech_emi.Name = "textBox_fech_emi";
            this.textBox_fech_emi.ReadOnly = true;
            this.textBox_fech_emi.Size = new System.Drawing.Size(137, 24);
            this.textBox_fech_emi.TabIndex = 7;
            // 
            // textBox_fech_ven
            // 
            this.textBox_fech_ven.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_fech_ven.Location = new System.Drawing.Point(242, 197);
            this.textBox_fech_ven.Name = "textBox_fech_ven";
            this.textBox_fech_ven.ReadOnly = true;
            this.textBox_fech_ven.Size = new System.Drawing.Size(137, 24);
            this.textBox_fech_ven.TabIndex = 8;
            this.textBox_fech_ven.TextChanged += new System.EventHandler(this.textBox_fech_ven_TextChanged);
            // 
            // textBox_codigo
            // 
            this.textBox_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_codigo.Location = new System.Drawing.Point(242, 239);
            this.textBox_codigo.Name = "textBox_codigo";
            this.textBox_codigo.Size = new System.Drawing.Size(137, 24);
            this.textBox_codigo.TabIndex = 9;
            this.textBox_codigo.UseSystemPasswordChar = true;
            this.textBox_codigo.TextChanged += new System.EventHandler(this.textBox_codigo_TextChanged);
            this.textBox_codigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_codigo_KeyPress);
            // 
            // button_aceptar
            // 
            this.button_aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.Location = new System.Drawing.Point(380, 283);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(77, 28);
            this.button_aceptar.TabIndex = 11;
            this.button_aceptar.Text = "Guardar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_limpiar.Location = new System.Drawing.Point(56, 282);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(77, 29);
            this.button_limpiar.TabIndex = 12;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // errorProvider_numero
            // 
            this.errorProvider_numero.ContainerControl = this;
            // 
            // errorProvider_fecha
            // 
            this.errorProvider_fecha.ContainerControl = this;
            // 
            // errorProvider_codigo
            // 
            this.errorProvider_codigo.ContainerControl = this;
            // 
            // button_sel_fecha
            // 
            this.button_sel_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sel_fecha.Location = new System.Drawing.Point(406, 195);
            this.button_sel_fecha.Name = "button_sel_fecha";
            this.button_sel_fecha.Size = new System.Drawing.Size(102, 28);
            this.button_sel_fecha.TabIndex = 10;
            this.button_sel_fecha.Text = "Seleccionar";
            this.button_sel_fecha.UseVisualStyleBackColor = true;
            this.button_sel_fecha.Click += new System.EventHandler(this.button_sel_fecha_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tipo documento del cliente:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(214, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Numero documento del cliente:";
            // 
            // textBox_tipo_doc
            // 
            this.textBox_tipo_doc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_tipo_doc.Location = new System.Drawing.Point(236, 12);
            this.textBox_tipo_doc.Name = "textBox_tipo_doc";
            this.textBox_tipo_doc.ReadOnly = true;
            this.textBox_tipo_doc.Size = new System.Drawing.Size(143, 24);
            this.textBox_tipo_doc.TabIndex = 15;
            // 
            // textBox_nro_doc
            // 
            this.textBox_nro_doc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nro_doc.Location = new System.Drawing.Point(236, 43);
            this.textBox_nro_doc.Name = "textBox_nro_doc";
            this.textBox_nro_doc.ReadOnly = true;
            this.textBox_nro_doc.Size = new System.Drawing.Size(143, 24);
            this.textBox_nro_doc.TabIndex = 16;
            // 
            // button_buscar
            // 
            this.button_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_buscar.Location = new System.Drawing.Point(416, 18);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(77, 36);
            this.button_buscar.TabIndex = 17;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // AltaTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 331);
            this.Controls.Add(this.button_buscar);
            this.Controls.Add(this.textBox_nro_doc);
            this.Controls.Add(this.textBox_tipo_doc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.button_sel_fecha);
            this.Controls.Add(this.textBox_codigo);
            this.Controls.Add(this.textBox_fech_ven);
            this.Controls.Add(this.textBox_fech_emi);
            this.Controls.Add(this.comboBox_emisores);
            this.Controls.Add(this.textBox_numero);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AltaTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Tarjeta";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_numero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_fecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_codigo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_numero;
        private System.Windows.Forms.ComboBox comboBox_emisores;
        private System.Windows.Forms.TextBox textBox_fech_emi;
        private System.Windows.Forms.TextBox textBox_fech_ven;
        private System.Windows.Forms.TextBox textBox_codigo;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.ErrorProvider errorProvider_numero;
        private System.Windows.Forms.ErrorProvider errorProvider_fecha;
        private System.Windows.Forms.ErrorProvider errorProvider_codigo;
        private System.Windows.Forms.Button button_sel_fecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.TextBox textBox_nro_doc;
        private System.Windows.Forms.TextBox textBox_tipo_doc;

    }
}