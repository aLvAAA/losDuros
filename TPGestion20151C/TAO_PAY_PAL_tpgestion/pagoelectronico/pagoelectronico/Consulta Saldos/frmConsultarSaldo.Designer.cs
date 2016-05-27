namespace PagoElectronico.Consulta_Saldos
{
    partial class frmConsultarSaldo
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
            this.tcSaldo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pSaldo = new System.Windows.Forms.Panel();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.gbMovimientos = new System.Windows.Forms.GroupBox();
            this.tcMovimientos = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvDepositos = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvRetiros = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvTransf = new System.Windows.Forms.DataGridView();
            this.gbCuentasCliente = new System.Windows.Forms.GroupBox();
            this.btnVerMov = new System.Windows.Forms.Button();
            this.dgvCuentasCliente = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvCuentasAdmin = new System.Windows.Forms.DataGridView();
            this.btnCuentasGlobales = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.cmbTipoMon = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tcSaldo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pSaldo.SuspendLayout();
            this.gbMovimientos.SuspendLayout();
            this.tcMovimientos.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetiros)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransf)).BeginInit();
            this.gbCuentasCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasCliente)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasAdmin)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcSaldo
            // 
            this.tcSaldo.Controls.Add(this.tabPage1);
            this.tcSaldo.Controls.Add(this.tabPage2);
            this.tcSaldo.ItemSize = new System.Drawing.Size(58, 30);
            this.tcSaldo.Location = new System.Drawing.Point(0, 0);
            this.tcSaldo.Name = "tcSaldo";
            this.tcSaldo.SelectedIndex = 0;
            this.tcSaldo.Size = new System.Drawing.Size(484, 519);
            this.tcSaldo.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pSaldo);
            this.tabPage1.Controls.Add(this.gbMovimientos);
            this.tabPage1.Controls.Add(this.gbCuentasCliente);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(476, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SALDO";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pSaldo
            // 
            this.pSaldo.Controls.Add(this.lblSaldo);
            this.pSaldo.Controls.Add(this.lblCuenta);
            this.pSaldo.Location = new System.Drawing.Point(6, 194);
            this.pSaldo.Name = "pSaldo";
            this.pSaldo.Size = new System.Drawing.Size(462, 54);
            this.pSaldo.TabIndex = 2;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(252, 19);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(56, 17);
            this.lblSaldo.TabIndex = 1;
            this.lblSaldo.Text = "Saldo : ";
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuenta.Location = new System.Drawing.Point(22, 18);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(61, 17);
            this.lblCuenta.TabIndex = 0;
            this.lblCuenta.Text = "Cuenta: ";
            // 
            // gbMovimientos
            // 
            this.gbMovimientos.Controls.Add(this.tcMovimientos);
            this.gbMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMovimientos.Location = new System.Drawing.Point(6, 263);
            this.gbMovimientos.Name = "gbMovimientos";
            this.gbMovimientos.Size = new System.Drawing.Size(462, 200);
            this.gbMovimientos.TabIndex = 1;
            this.gbMovimientos.TabStop = false;
            this.gbMovimientos.Text = "Movimientos";
            // 
            // tcMovimientos
            // 
            this.tcMovimientos.Controls.Add(this.tabPage3);
            this.tcMovimientos.Controls.Add(this.tabPage4);
            this.tcMovimientos.Controls.Add(this.tabPage5);
            this.tcMovimientos.ItemSize = new System.Drawing.Size(65, 25);
            this.tcMovimientos.Location = new System.Drawing.Point(6, 20);
            this.tcMovimientos.Name = "tcMovimientos";
            this.tcMovimientos.SelectedIndex = 0;
            this.tcMovimientos.Size = new System.Drawing.Size(443, 174);
            this.tcMovimientos.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvDepositos);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(435, 141);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Depositos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvDepositos
            // 
            this.dgvDepositos.AllowUserToAddRows = false;
            this.dgvDepositos.AllowUserToDeleteRows = false;
            this.dgvDepositos.AllowUserToResizeColumns = false;
            this.dgvDepositos.AllowUserToResizeRows = false;
            this.dgvDepositos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepositos.Location = new System.Drawing.Point(3, 3);
            this.dgvDepositos.MultiSelect = false;
            this.dgvDepositos.Name = "dgvDepositos";
            this.dgvDepositos.ReadOnly = true;
            this.dgvDepositos.RowHeadersVisible = false;
            this.dgvDepositos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepositos.Size = new System.Drawing.Size(425, 132);
            this.dgvDepositos.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvRetiros);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(435, 141);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Retiros";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvRetiros
            // 
            this.dgvRetiros.AllowUserToAddRows = false;
            this.dgvRetiros.AllowUserToDeleteRows = false;
            this.dgvRetiros.AllowUserToResizeColumns = false;
            this.dgvRetiros.AllowUserToResizeRows = false;
            this.dgvRetiros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRetiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRetiros.Location = new System.Drawing.Point(6, 6);
            this.dgvRetiros.MultiSelect = false;
            this.dgvRetiros.Name = "dgvRetiros";
            this.dgvRetiros.ReadOnly = true;
            this.dgvRetiros.RowHeadersVisible = false;
            this.dgvRetiros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRetiros.Size = new System.Drawing.Size(422, 129);
            this.dgvRetiros.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvTransf);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(435, 141);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Transferencias";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvTransf
            // 
            this.dgvTransf.AllowUserToAddRows = false;
            this.dgvTransf.AllowUserToDeleteRows = false;
            this.dgvTransf.AllowUserToResizeColumns = false;
            this.dgvTransf.AllowUserToResizeRows = false;
            this.dgvTransf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTransf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransf.Location = new System.Drawing.Point(6, 6);
            this.dgvTransf.MultiSelect = false;
            this.dgvTransf.Name = "dgvTransf";
            this.dgvTransf.ReadOnly = true;
            this.dgvTransf.RowHeadersVisible = false;
            this.dgvTransf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransf.Size = new System.Drawing.Size(422, 129);
            this.dgvTransf.TabIndex = 0;
            // 
            // gbCuentasCliente
            // 
            this.gbCuentasCliente.Controls.Add(this.btnVerMov);
            this.gbCuentasCliente.Controls.Add(this.dgvCuentasCliente);
            this.gbCuentasCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCuentasCliente.Location = new System.Drawing.Point(6, 9);
            this.gbCuentasCliente.Name = "gbCuentasCliente";
            this.gbCuentasCliente.Size = new System.Drawing.Size(449, 179);
            this.gbCuentasCliente.TabIndex = 0;
            this.gbCuentasCliente.TabStop = false;
            this.gbCuentasCliente.Text = "Elija una cuenta";
            // 
            // btnVerMov
            // 
            this.btnVerMov.Enabled = false;
            this.btnVerMov.Location = new System.Drawing.Point(128, 144);
            this.btnVerMov.Name = "btnVerMov";
            this.btnVerMov.Size = new System.Drawing.Size(185, 29);
            this.btnVerMov.TabIndex = 1;
            this.btnVerMov.Text = "Ver Movimientos y Saldo";
            this.btnVerMov.UseVisualStyleBackColor = true;
            this.btnVerMov.Click += new System.EventHandler(this.btnVerMov_Click);
            // 
            // dgvCuentasCliente
            // 
            this.dgvCuentasCliente.AllowUserToAddRows = false;
            this.dgvCuentasCliente.AllowUserToDeleteRows = false;
            this.dgvCuentasCliente.AllowUserToResizeColumns = false;
            this.dgvCuentasCliente.AllowUserToResizeRows = false;
            this.dgvCuentasCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCuentasCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentasCliente.Location = new System.Drawing.Point(6, 20);
            this.dgvCuentasCliente.MultiSelect = false;
            this.dgvCuentasCliente.Name = "dgvCuentasCliente";
            this.dgvCuentasCliente.ReadOnly = true;
            this.dgvCuentasCliente.RowHeadersVisible = false;
            this.dgvCuentasCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentasCliente.Size = new System.Drawing.Size(432, 118);
            this.dgvCuentasCliente.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnConsultar);
            this.tabPage2.Controls.Add(this.dgvCuentasAdmin);
            this.tabPage2.Controls.Add(this.btnCuentasGlobales);
            this.tabPage2.Controls.Add(this.btnFiltrar);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(476, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LISTADO";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(147, 445);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(179, 30);
            this.btnConsultar.TabIndex = 20;
            this.btnConsultar.Text = "Consultar Saldo y Movimientos";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dgvCuentasAdmin
            // 
            this.dgvCuentasAdmin.AllowUserToAddRows = false;
            this.dgvCuentasAdmin.AllowUserToDeleteRows = false;
            this.dgvCuentasAdmin.AllowUserToResizeColumns = false;
            this.dgvCuentasAdmin.AllowUserToResizeRows = false;
            this.dgvCuentasAdmin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCuentasAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentasAdmin.Location = new System.Drawing.Point(8, 202);
            this.dgvCuentasAdmin.MultiSelect = false;
            this.dgvCuentasAdmin.Name = "dgvCuentasAdmin";
            this.dgvCuentasAdmin.ReadOnly = true;
            this.dgvCuentasAdmin.RowHeadersVisible = false;
            this.dgvCuentasAdmin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentasAdmin.Size = new System.Drawing.Size(460, 237);
            this.dgvCuentasAdmin.TabIndex = 19;
            // 
            // btnCuentasGlobales
            // 
            this.btnCuentasGlobales.Location = new System.Drawing.Point(171, 166);
            this.btnCuentasGlobales.Name = "btnCuentasGlobales";
            this.btnCuentasGlobales.Size = new System.Drawing.Size(143, 30);
            this.btnCuentasGlobales.TabIndex = 18;
            this.btnCuentasGlobales.Text = "Buscar Cuentas Globales";
            this.btnCuentasGlobales.UseVisualStyleBackColor = true;
            this.btnCuentasGlobales.Click += new System.EventHandler(this.btnCuentasGlobales_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(41, 166);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(103, 30);
            this.btnFiltrar.TabIndex = 17;
            this.btnFiltrar.Text = "Buscar Por Filtros";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipoDoc);
            this.groupBox1.Controls.Add(this.cmbTipoMon);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCuenta);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDoc);
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(320, 19);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(108, 23);
            this.cmbTipoDoc.TabIndex = 15;
            // 
            // cmbTipoMon
            // 
            this.cmbTipoMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMon.FormattingEnabled = true;
            this.cmbTipoMon.Location = new System.Drawing.Point(320, 72);
            this.cmbTipoMon.Name = "cmbTipoMon";
            this.cmbTipoMon.Size = new System.Drawing.Size(108, 23);
            this.cmbTipoMon.TabIndex = 14;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(342, 103);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(86, 45);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar Campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(262, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Moneda";
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(79, 44);
            this.txtCuenta.MaxLength = 18;
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(108, 21);
            this.txtCuenta.TabIndex = 12;
            this.txtCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuenta_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Nro Cuenta";
            // 
            // txtDoc
            // 
            this.txtDoc.Location = new System.Drawing.Point(320, 45);
            this.txtDoc.MaxLength = 9;
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(108, 21);
            this.txtDoc.TabIndex = 10;
            this.txtDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoc_KeyPress);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(79, 120);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(187, 21);
            this.txtMail.TabIndex = 9;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(79, 95);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(135, 21);
            this.txtApellido.TabIndex = 8;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(79, 70);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(135, 21);
            this.txtNombre.TabIndex = 7;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(79, 19);
            this.txtID.MaxLength = 5;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(70, 21);
            this.txtID.TabIndex = 6;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nro Doc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo Doc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(175, 525);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(103, 30);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "Volver Menu";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmConsultarSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(484, 562);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tcSaldo);
            this.Name = "frmConsultarSaldo";
            this.Text = "Consultar Saldo";
            this.Load += new System.EventHandler(this.frmConsultarSaldo_Load);
            this.tcSaldo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pSaldo.ResumeLayout(false);
            this.pSaldo.PerformLayout();
            this.gbMovimientos.ResumeLayout(false);
            this.tcMovimientos.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetiros)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransf)).EndInit();
            this.gbCuentasCliente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasCliente)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasAdmin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCuentasCliente;
        private System.Windows.Forms.DataGridView dgvCuentasCliente;
        private System.Windows.Forms.Panel pSaldo;
        private System.Windows.Forms.GroupBox gbMovimientos;
        private System.Windows.Forms.TabControl tcMovimientos;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnVerMov;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.DataGridView dgvDepositos;
        private System.Windows.Forms.DataGridView dgvRetiros;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvTransf;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.ComboBox cmbTipoMon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvCuentasAdmin;
        private System.Windows.Forms.Button btnCuentasGlobales;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnSalir;
        public System.Windows.Forms.TabControl tcSaldo;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
    }
}