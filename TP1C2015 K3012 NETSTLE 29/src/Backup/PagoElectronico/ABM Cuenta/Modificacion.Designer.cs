namespace PagoElectronico.ABM_Cuenta
{
    partial class Modificacion
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
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_nroDeSuscripciones = new System.Windows.Forms.TextBox();
            this.comboBox_tipoCuenta = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_cuenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_buscar = new System.Windows.Forms.Button();
            this.button_guardar = new System.Windows.Forms.Button();
            this.errorProvider_nroCuenta = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_sus = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_nroCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_sus)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 18);
            this.label7.TabIndex = 56;
            this.label7.Text = "Suscripciones:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_nroDeSuscripciones
            // 
            this.textBox_nroDeSuscripciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nroDeSuscripciones.Location = new System.Drawing.Point(124, 107);
            this.textBox_nroDeSuscripciones.Name = "textBox_nroDeSuscripciones";
            this.textBox_nroDeSuscripciones.Size = new System.Drawing.Size(165, 24);
            this.textBox_nroDeSuscripciones.TabIndex = 55;
            this.textBox_nroDeSuscripciones.TextChanged += new System.EventHandler(this.textBox_nroDeSuscripciones_TextChanged);
            this.textBox_nroDeSuscripciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_nroDeSuscripciones_KeyPress);
            // 
            // comboBox_tipoCuenta
            // 
            this.comboBox_tipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tipoCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_tipoCuenta.FormattingEnabled = true;
            this.comboBox_tipoCuenta.Location = new System.Drawing.Point(124, 62);
            this.comboBox_tipoCuenta.Name = "comboBox_tipoCuenta";
            this.comboBox_tipoCuenta.Size = new System.Drawing.Size(165, 26);
            this.comboBox_tipoCuenta.TabIndex = 49;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_nroDeSuscripciones);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_cuenta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_tipoCuenta);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 150);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cuenta";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 18);
            this.label4.TabIndex = 54;
            this.label4.Text = "Cuenta:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_cuenta
            // 
            this.textBox_cuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_cuenta.Location = new System.Drawing.Point(124, 19);
            this.textBox_cuenta.Name = "textBox_cuenta";
            this.textBox_cuenta.ReadOnly = true;
            this.textBox_cuenta.Size = new System.Drawing.Size(165, 24);
            this.textBox_cuenta.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 50;
            this.label2.Text = "Tipo de Cuenta:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(12, 168);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 23);
            this.button_buscar.TabIndex = 3;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(253, 168);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 0;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // errorProvider_nroCuenta
            // 
            this.errorProvider_nroCuenta.ContainerControl = this;
            // 
            // errorProvider_sus
            // 
            this.errorProvider_sus.ContainerControl = this;
            // 
            // Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 201);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.button_buscar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Modificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificacion de Cuenta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_nroCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_sus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_nroDeSuscripciones;
        private System.Windows.Forms.ComboBox comboBox_tipoCuenta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_cuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.ErrorProvider errorProvider_nroCuenta;
        private System.Windows.Forms.ErrorProvider errorProvider_sus;
    }
}