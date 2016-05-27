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
            this.formListadoCuentasOrigen = new System.Windows.Forms.DataGridView();
            this.numCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomApe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantTransacciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRealizarTransf = new System.Windows.Forms.Button();
            this.txtNumCuentaOrigen = new System.Windows.Forms.TextBox();
            this.txtNumCuentaDestino = new System.Windows.Forms.TextBox();
            this.btnBuscarCuenta = new System.Windows.Forms.Button();
            this.gridCuentaDestino = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.btVolverMenu = new System.Windows.Forms.Button();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.NumCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaisCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.formListadoCuentasOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCuentaDestino)).BeginInit();
            this.SuspendLayout();
            // 
            // formListadoCuentasOrigen
            // 
            this.formListadoCuentasOrigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.formListadoCuentasOrigen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numCuenta,
            this.nomApe,
            this.tipoCuenta,
            this.moneda,
            this.pais,
            this.estado,
            this.fecha,
            this.CantTransacciones,
            this.Saldo});
            this.formListadoCuentasOrigen.Location = new System.Drawing.Point(12, 64);
            this.formListadoCuentasOrigen.MultiSelect = false;
            this.formListadoCuentasOrigen.Name = "formListadoCuentasOrigen";
            this.formListadoCuentasOrigen.ReadOnly = true;
            this.formListadoCuentasOrigen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.formListadoCuentasOrigen.Size = new System.Drawing.Size(748, 155);
            this.formListadoCuentasOrigen.TabIndex = 0;
            this.formListadoCuentasOrigen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.formListadoCuentas_CellContentClick);
            // 
            // numCuenta
            // 
            this.numCuenta.HeaderText = "Numero de Cuenta";
            this.numCuenta.Name = "numCuenta";
            this.numCuenta.ReadOnly = true;
            this.numCuenta.Width = 110;
            // 
            // nomApe
            // 
            this.nomApe.HeaderText = "Nombre y Apellido";
            this.nomApe.Name = "nomApe";
            this.nomApe.ReadOnly = true;
            this.nomApe.Visible = false;
            // 
            // tipoCuenta
            // 
            this.tipoCuenta.HeaderText = "Categoria";
            this.tipoCuenta.Name = "tipoCuenta";
            this.tipoCuenta.ReadOnly = true;
            // 
            // moneda
            // 
            this.moneda.HeaderText = "Moneda";
            this.moneda.Name = "moneda";
            this.moneda.ReadOnly = true;
            // 
            // pais
            // 
            this.pais.HeaderText = "Pais";
            this.pais.Name = "pais";
            this.pais.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha de Caducacion";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // CantTransacciones
            // 
            this.CantTransacciones.HeaderText = "Cantidad de Transacciones";
            this.CantTransacciones.Name = "CantTransacciones";
            this.CantTransacciones.ReadOnly = true;
            // 
            // Saldo
            // 
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(156, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese Numero Cuenta Destino";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnRealizarTransf
            // 
            this.btnRealizarTransf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealizarTransf.Location = new System.Drawing.Point(343, 384);
            this.btnRealizarTransf.Name = "btnRealizarTransf";
            this.btnRealizarTransf.Size = new System.Drawing.Size(128, 50);
            this.btnRealizarTransf.TabIndex = 4;
            this.btnRealizarTransf.Text = "Realizar Transferencia";
            this.btnRealizarTransf.UseVisualStyleBackColor = true;
            this.btnRealizarTransf.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNumCuentaOrigen
            // 
            this.txtNumCuentaOrigen.Enabled = false;
            this.txtNumCuentaOrigen.Location = new System.Drawing.Point(509, 27);
            this.txtNumCuentaOrigen.Name = "txtNumCuentaOrigen";
            this.txtNumCuentaOrigen.Size = new System.Drawing.Size(157, 20);
            this.txtNumCuentaOrigen.TabIndex = 5;
            this.txtNumCuentaOrigen.TextChanged += new System.EventHandler(this.txtNumCuentaOrigen_TextChanged);
            this.txtNumCuentaOrigen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumCuentaOrigen_KeyPress);
            // 
            // txtNumCuentaDestino
            // 
            this.txtNumCuentaDestino.Location = new System.Drawing.Point(509, 233);
            this.txtNumCuentaDestino.Name = "txtNumCuentaDestino";
            this.txtNumCuentaDestino.Size = new System.Drawing.Size(157, 20);
            this.txtNumCuentaDestino.TabIndex = 6;
            this.txtNumCuentaDestino.TextChanged += new System.EventHandler(this.txtNumCuentaDestino_TextChanged);
            this.txtNumCuentaDestino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumCuentaDestino_KeyPress);
            // 
            // btnBuscarCuenta
            // 
            this.btnBuscarCuenta.Location = new System.Drawing.Point(529, 273);
            this.btnBuscarCuenta.Name = "btnBuscarCuenta";
            this.btnBuscarCuenta.Size = new System.Drawing.Size(118, 45);
            this.btnBuscarCuenta.TabIndex = 7;
            this.btnBuscarCuenta.Text = "Buscar";
            this.btnBuscarCuenta.UseVisualStyleBackColor = true;
            this.btnBuscarCuenta.Click += new System.EventHandler(this.btnBuscarCuenta_Click);
            // 
            // gridCuentaDestino
            // 
            this.gridCuentaDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCuentaDestino.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumCta,
            this.NomApellido,
            this.CatCta,
            this.PaisCta,
            this.EstCta,
            this.IdCliente});
            this.gridCuentaDestino.Location = new System.Drawing.Point(148, 273);
            this.gridCuentaDestino.MultiSelect = false;
            this.gridCuentaDestino.Name = "gridCuentaDestino";
            this.gridCuentaDestino.ReadOnly = true;
            this.gridCuentaDestino.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCuentaDestino.Size = new System.Drawing.Size(288, 85);
            this.gridCuentaDestino.TabIndex = 8;
            this.gridCuentaDestino.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCuentaDestino_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(160, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Seleccione una de sus Cuentas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 24);
            this.label4.TabIndex = 10;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ingrese Importe:";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(164, 400);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(154, 20);
            this.txtImporte.TabIndex = 12;
            this.txtImporte.TextChanged += new System.EventHandler(this.txtImporte_TextChanged);
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // btVolverMenu
            // 
            this.btVolverMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVolverMenu.Location = new System.Drawing.Point(492, 384);
            this.btVolverMenu.Name = "btVolverMenu";
            this.btVolverMenu.Size = new System.Drawing.Size(128, 50);
            this.btVolverMenu.TabIndex = 13;
            this.btVolverMenu.Text = "Volver \r\nMenu";
            this.btVolverMenu.UseVisualStyleBackColor = true;
            this.btVolverMenu.Click += new System.EventHandler(this.btVolverMenu_Click);
            // 
            // btLimpiar
            // 
            this.btLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpiar.Location = new System.Drawing.Point(632, 384);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(128, 50);
            this.btLimpiar.TabIndex = 14;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // NumCta
            // 
            this.NumCta.HeaderText = "Numero de Cuenta";
            this.NumCta.Name = "NumCta";
            this.NumCta.ReadOnly = true;
            this.NumCta.Width = 125;
            // 
            // NomApellido
            // 
            this.NomApellido.HeaderText = "Nombre y Apellido";
            this.NomApellido.Name = "NomApellido";
            this.NomApellido.ReadOnly = true;
            this.NomApellido.Width = 125;
            // 
            // CatCta
            // 
            this.CatCta.HeaderText = "Categoria";
            this.CatCta.Name = "CatCta";
            this.CatCta.ReadOnly = true;
            this.CatCta.Visible = false;
            // 
            // PaisCta
            // 
            this.PaisCta.HeaderText = "Pais";
            this.PaisCta.Name = "PaisCta";
            this.PaisCta.ReadOnly = true;
            this.PaisCta.Visible = false;
            this.PaisCta.Width = 125;
            // 
            // EstCta
            // 
            this.EstCta.HeaderText = "Estado";
            this.EstCta.Name = "EstCta";
            this.EstCta.ReadOnly = true;
            this.EstCta.Visible = false;
            // 
            // IdCliente
            // 
            this.IdCliente.HeaderText = "Numero de Cliente";
            this.IdCliente.Name = "IdCliente";
            this.IdCliente.ReadOnly = true;
            this.IdCliente.Visible = false;
            // 
            // Transferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 454);
            this.Controls.Add(this.btLimpiar);
            this.Controls.Add(this.btVolverMenu);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridCuentaDestino);
            this.Controls.Add(this.btnBuscarCuenta);
            this.Controls.Add(this.txtNumCuentaDestino);
            this.Controls.Add(this.txtNumCuentaOrigen);
            this.Controls.Add(this.btnRealizarTransf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.formListadoCuentasOrigen);
            this.Name = "Transferencia";
            this.Text = "Tranferencia";
            ((System.ComponentModel.ISupportInitialize)(this.formListadoCuentasOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCuentaDestino)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView formListadoCuentasOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRealizarTransf;
        private System.Windows.Forms.TextBox txtNumCuentaOrigen;
        private System.Windows.Forms.TextBox txtNumCuentaDestino;
        private System.Windows.Forms.Button btnBuscarCuenta;
        private System.Windows.Forms.DataGridView gridCuentaDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Button btVolverMenu;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn numCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomApe;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn pais;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantTransacciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaisCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;

    }
}