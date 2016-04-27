namespace PagoElectronico.ABM_Cuenta
{
    partial class Alta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_nroDeSuscripciones = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_cuenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_tipoMoneda = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_tipoCuenta = new System.Windows.Forms.ComboBox();
            this.comboBox_pais = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_nroDoc = new System.Windows.Forms.TextBox();
            this.button_buscar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.errorProvider_nroCuenta = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_cliente1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_tipoDoc = new System.Windows.Forms.TextBox();
            this.errorProvider_sus = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_cliente2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_nroCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_cliente1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_sus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_cliente2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_nroDeSuscripciones);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_cuenta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_tipoMoneda);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBox_tipoCuenta);
            this.groupBox1.Controls.Add(this.comboBox_pais);
            this.groupBox1.Location = new System.Drawing.Point(15, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 235);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cuenta";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 18);
            this.label7.TabIndex = 56;
            this.label7.Text = "Suscripciones:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_nroDeSuscripciones
            // 
            this.textBox_nroDeSuscripciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nroDeSuscripciones.Location = new System.Drawing.Point(149, 107);
            this.textBox_nroDeSuscripciones.Name = "textBox_nroDeSuscripciones";
            this.textBox_nroDeSuscripciones.Size = new System.Drawing.Size(165, 24);
            this.textBox_nroDeSuscripciones.TabIndex = 55;
            this.textBox_nroDeSuscripciones.TextChanged += new System.EventHandler(this.textBox_nroDeSuscripciones_TextChanged);
            this.textBox_nroDeSuscripciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_nroDeSuscripciones_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 18);
            this.label4.TabIndex = 54;
            this.label4.Text = "Numero de Cuenta:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_cuenta
            // 
            this.textBox_cuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_cuenta.Location = new System.Drawing.Point(149, 19);
            this.textBox_cuenta.Name = "textBox_cuenta";
            this.textBox_cuenta.Size = new System.Drawing.Size(165, 24);
            this.textBox_cuenta.TabIndex = 53;
            this.textBox_cuenta.TextChanged += new System.EventHandler(this.textBox_cuenta_TextChanged);
            this.textBox_cuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_cuenta_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 18);
            this.label3.TabIndex = 52;
            this.label3.Text = "Moneda:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_tipoMoneda
            // 
            this.comboBox_tipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tipoMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_tipoMoneda.FormattingEnabled = true;
            this.comboBox_tipoMoneda.Location = new System.Drawing.Point(149, 193);
            this.comboBox_tipoMoneda.Name = "comboBox_tipoMoneda";
            this.comboBox_tipoMoneda.Size = new System.Drawing.Size(165, 26);
            this.comboBox_tipoMoneda.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 18);
            this.label2.TabIndex = 50;
            this.label2.Text = "Tipo de Cuenta:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 18);
            this.label6.TabIndex = 47;
            this.label6.Text = "Pais:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_tipoCuenta
            // 
            this.comboBox_tipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tipoCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_tipoCuenta.FormattingEnabled = true;
            this.comboBox_tipoCuenta.Location = new System.Drawing.Point(149, 62);
            this.comboBox_tipoCuenta.Name = "comboBox_tipoCuenta";
            this.comboBox_tipoCuenta.Size = new System.Drawing.Size(165, 26);
            this.comboBox_tipoCuenta.TabIndex = 49;
            // 
            // comboBox_pais
            // 
            this.comboBox_pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_pais.FormattingEnabled = true;
            this.comboBox_pais.Location = new System.Drawing.Point(149, 151);
            this.comboBox_pais.Name = "comboBox_pais";
            this.comboBox_pais.Size = new System.Drawing.Size(165, 26);
            this.comboBox_pais.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 18);
            this.label1.TabIndex = 56;
            this.label1.Text = "Numero de Doc:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_nroDoc
            // 
            this.textBox_nroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nroDoc.Location = new System.Drawing.Point(152, 19);
            this.textBox_nroDoc.Name = "textBox_nroDoc";
            this.textBox_nroDoc.ReadOnly = true;
            this.textBox_nroDoc.Size = new System.Drawing.Size(165, 24);
            this.textBox_nroDoc.TabIndex = 0;
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(283, 123);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 23);
            this.button_buscar.TabIndex = 0;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(285, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // errorProvider_nroCuenta
            // 
            this.errorProvider_nroCuenta.ContainerControl = this;
            // 
            // errorProvider_cliente1
            // 
            this.errorProvider_cliente1.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_tipoDoc);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox_nroDoc);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 105);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cliente";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 18);
            this.label5.TabIndex = 60;
            this.label5.Text = "Tipo de Doc:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_tipoDoc
            // 
            this.textBox_tipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_tipoDoc.Location = new System.Drawing.Point(152, 59);
            this.textBox_tipoDoc.Name = "textBox_tipoDoc";
            this.textBox_tipoDoc.ReadOnly = true;
            this.textBox_tipoDoc.Size = new System.Drawing.Size(165, 24);
            this.textBox_tipoDoc.TabIndex = 57;
            // 
            // errorProvider_sus
            // 
            this.errorProvider_sus.ContainerControl = this;
            // 
            // errorProvider_cliente2
            // 
            this.errorProvider_cliente2.ContainerControl = this;
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 422);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_buscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Alta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Cuenta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_nroCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_cliente1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_sus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_cliente2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_tipoMoneda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_tipoCuenta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_pais;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_cuenta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider_nroCuenta;
        private System.Windows.Forms.ErrorProvider errorProvider_cliente1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nroDoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_tipoDoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_nroDeSuscripciones;
        private System.Windows.Forms.ErrorProvider errorProvider_sus;
        private System.Windows.Forms.ErrorProvider errorProvider_cliente2;
    }
}