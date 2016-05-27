namespace PagoElectronico.Depositos
{
    partial class frmComprobanteDepo
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
            this.btnVolverDepo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.lblDineroDepo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblDepoCod = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVolverDepo
            // 
            this.btnVolverDepo.Location = new System.Drawing.Point(126, 129);
            this.btnVolverDepo.Name = "btnVolverDepo";
            this.btnVolverDepo.Size = new System.Drawing.Size(130, 30);
            this.btnVolverDepo.TabIndex = 0;
            this.btnVolverDepo.Text = "Volver";
            this.btnVolverDepo.UseVisualStyleBackColor = true;
            this.btnVolverDepo.Click += new System.EventHandler(this.btnVolverDepo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.lblCuenta);
            this.panel1.Controls.Add(this.lblDineroDepo);
            this.panel1.Controls.Add(this.lblCliente);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.lblDepoCod);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 111);
            this.panel1.TabIndex = 1;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(22, 60);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(74, 13);
            this.lblCuenta.TabIndex = 4;
            this.lblCuenta.Text = "Cuenta N° .... ";
            // 
            // lblDineroDepo
            // 
            this.lblDineroDepo.AutoSize = true;
            this.lblDineroDepo.Location = new System.Drawing.Point(22, 87);
            this.lblDineroDepo.Name = "lblDineroDepo";
            this.lblDineroDepo.Size = new System.Drawing.Size(82, 13);
            this.lblDineroDepo.TabIndex = 3;
            this.lblDineroDepo.Text = "Deposito ......... ";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(236, 33);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(59, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente ID: ";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(22, 9);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(92, 13);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha Operacion ";
            // 
            // lblDepoCod
            // 
            this.lblDepoCod.AutoSize = true;
            this.lblDepoCod.Location = new System.Drawing.Point(22, 33);
            this.lblDepoCod.Name = "lblDepoCod";
            this.lblDepoCod.Size = new System.Drawing.Size(67, 13);
            this.lblDepoCod.TabIndex = 0;
            this.lblDepoCod.Text = "Deposito N° ";
            // 
            // frmComprobanteDepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 162);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnVolverDepo);
            this.Name = "frmComprobanteDepo";
            this.Text = "Comprobante Deposito";
            this.Load += new System.EventHandler(this.frmComprobanteDepo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVolverDepo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDineroDepo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblDepoCod;
        private System.Windows.Forms.Label lblCuenta;
    }
}