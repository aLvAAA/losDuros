namespace PagoElectronico.ABM_Cliente
{
    partial class frmTarjeta
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
            this.tcTarjeta = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAsociarTarjeta = new System.Windows.Forms.Button();
            this.txtSeguridad_a = new System.Windows.Forms.TextBox();
            this.dtpVenc_a = new System.Windows.Forms.DateTimePicker();
            this.dtpEmisor_a = new System.Windows.Forms.DateTimePicker();
            this.cmbEmisor = new System.Windows.Forms.ComboBox();
            this.txtNroTar_a = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.rbSeguridad = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbVencimiento = new System.Windows.Forms.RadioButton();
            this.dtpNewDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.btnEditarTarjeta = new System.Windows.Forms.Button();
            this.cmbTarjeta_Edit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.btnDesasociarTarjeta = new System.Windows.Forms.Button();
            this.cmbTarjeta_Baja = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPass_Baja = new System.Windows.Forms.TextBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.lblFechaSistema = new System.Windows.Forms.Label();
            this.tcTarjeta.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcTarjeta
            // 
            this.tcTarjeta.Controls.Add(this.tabPage1);
            this.tcTarjeta.Controls.Add(this.tabPage2);
            this.tcTarjeta.Controls.Add(this.tabPage3);
            this.tcTarjeta.ItemSize = new System.Drawing.Size(58, 30);
            this.tcTarjeta.Location = new System.Drawing.Point(12, 12);
            this.tcTarjeta.Name = "tcTarjeta";
            this.tcTarjeta.SelectedIndex = 0;
            this.tcTarjeta.Size = new System.Drawing.Size(460, 379);
            this.tcTarjeta.TabIndex = 0;
            this.tcTarjeta.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcTarjeta_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Controls.Add(this.btnLimpiar);
            this.tabPage1.Controls.Add(this.btnAsociarTarjeta);
            this.tabPage1.Controls.Add(this.txtSeguridad_a);
            this.tabPage1.Controls.Add(this.dtpVenc_a);
            this.tabPage1.Controls.Add(this.dtpEmisor_a);
            this.tabPage1.Controls.Add(this.cmbEmisor);
            this.tabPage1.Controls.Add(this.txtNroTar_a);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(452, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ASOCIAR";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(325, 264);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(86, 40);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAsociarTarjeta
            // 
            this.btnAsociarTarjeta.Location = new System.Drawing.Point(153, 264);
            this.btnAsociarTarjeta.Name = "btnAsociarTarjeta";
            this.btnAsociarTarjeta.Size = new System.Drawing.Size(101, 40);
            this.btnAsociarTarjeta.TabIndex = 2;
            this.btnAsociarTarjeta.Text = "ASOCIAR";
            this.btnAsociarTarjeta.UseVisualStyleBackColor = true;
            this.btnAsociarTarjeta.Click += new System.EventHandler(this.btnAsociarTarjeta_Click);
            // 
            // txtSeguridad_a
            // 
            this.txtSeguridad_a.Location = new System.Drawing.Point(124, 186);
            this.txtSeguridad_a.Name = "txtSeguridad_a";
            this.txtSeguridad_a.Size = new System.Drawing.Size(76, 20);
            this.txtSeguridad_a.TabIndex = 9;
            this.txtSeguridad_a.UseSystemPasswordChar = true;
            this.txtSeguridad_a.TextChanged += new System.EventHandler(this.txtSeguridad_a_TextChanged);
            this.txtSeguridad_a.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeguridad_a_KeyPress);
            // 
            // dtpVenc_a
            // 
            this.dtpVenc_a.Location = new System.Drawing.Point(118, 140);
            this.dtpVenc_a.Name = "dtpVenc_a";
            this.dtpVenc_a.Size = new System.Drawing.Size(200, 20);
            this.dtpVenc_a.TabIndex = 8;
            // 
            // dtpEmisor_a
            // 
            this.dtpEmisor_a.Location = new System.Drawing.Point(118, 104);
            this.dtpEmisor_a.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dtpEmisor_a.Name = "dtpEmisor_a";
            this.dtpEmisor_a.Size = new System.Drawing.Size(200, 20);
            this.dtpEmisor_a.TabIndex = 7;
            // 
            // cmbEmisor
            // 
            this.cmbEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmisor.FormattingEnabled = true;
            this.cmbEmisor.Items.AddRange(new object[] {
            "American Express",
            "Master Card",
            "Visa"});
            this.cmbEmisor.Location = new System.Drawing.Point(124, 56);
            this.cmbEmisor.Name = "cmbEmisor";
            this.cmbEmisor.Size = new System.Drawing.Size(130, 21);
            this.cmbEmisor.TabIndex = 6;
            // 
            // txtNroTar_a
            // 
            this.txtNroTar_a.Location = new System.Drawing.Point(124, 26);
            this.txtNroTar_a.Name = "txtNroTar_a";
            this.txtNroTar_a.Size = new System.Drawing.Size(158, 20);
            this.txtNroTar_a.TabIndex = 1;
            this.txtNroTar_a.TextChanged += new System.EventHandler(this.txtNroTar_a_TextChanged);
            this.txtNroTar_a.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroTar_a_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Codigo de seguridad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha Vencimiento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Emision";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Emisor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.lblEstado);
            this.tabPage2.Controls.Add(this.lblNewDate);
            this.tabPage2.Controls.Add(this.btnEditarTarjeta);
            this.tabPage2.Controls.Add(this.cmbTarjeta_Edit);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(452, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MODIFICAR";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.rbSeguridad);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtPass);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtNewPass);
            this.panel2.Location = new System.Drawing.Point(15, 209);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 126);
            this.panel2.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(161, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 26);
            this.label16.TabIndex = 17;
            this.label16.Text = "3 digitos \r\ncada campo";
            // 
            // rbSeguridad
            // 
            this.rbSeguridad.AutoSize = true;
            this.rbSeguridad.Location = new System.Drawing.Point(12, 40);
            this.rbSeguridad.Name = "rbSeguridad";
            this.rbSeguridad.Size = new System.Drawing.Size(158, 17);
            this.rbSeguridad.TabIndex = 15;
            this.rbSeguridad.TabStop = true;
            this.rbSeguridad.Text = "Actualizar Codigo Seguridad";
            this.rbSeguridad.UseVisualStyleBackColor = true;
            this.rbSeguridad.Click += new System.EventHandler(this.rbSeguridad_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Actual Codigo";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(197, 26);
            this.label13.TabIndex = 14;
            this.label13.Text = "Si crees que alguien escucho o sabe tu \r\ncodigo de seguridad, actualizalo ahora:";
            // 
            // txtPass
            // 
            this.txtPass.Enabled = false;
            this.txtPass.Location = new System.Drawing.Point(92, 61);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(63, 20);
            this.txtPass.TabIndex = 5;
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Nuevo Codigo";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Enabled = false;
            this.txtNewPass.Location = new System.Drawing.Point(92, 86);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(63, 20);
            this.txtNewPass.TabIndex = 7;
            this.txtNewPass.UseSystemPasswordChar = true;
            this.txtNewPass.TextChanged += new System.EventHandler(this.txtNewPass_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbVencimiento);
            this.panel1.Controls.Add(this.dtpNewDate);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(15, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 66);
            this.panel1.TabIndex = 15;
            // 
            // rbVencimiento
            // 
            this.rbVencimiento.AutoSize = true;
            this.rbVencimiento.Checked = true;
            this.rbVencimiento.Location = new System.Drawing.Point(12, 40);
            this.rbVencimiento.Name = "rbVencimiento";
            this.rbVencimiento.Size = new System.Drawing.Size(132, 17);
            this.rbVencimiento.TabIndex = 14;
            this.rbVencimiento.TabStop = true;
            this.rbVencimiento.Text = "Actualizar Vencimiento";
            this.rbVencimiento.UseVisualStyleBackColor = true;
            this.rbVencimiento.Click += new System.EventHandler(this.rbVencimiento_Click);
            // 
            // dtpNewDate
            // 
            this.dtpNewDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNewDate.Location = new System.Drawing.Point(186, 40);
            this.dtpNewDate.Name = "dtpNewDate";
            this.dtpNewDate.Size = new System.Drawing.Size(99, 20);
            this.dtpNewDate.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(312, 26);
            this.label12.TabIndex = 13;
            this.label12.Text = "En caso que quieras extender la fecha de vencimiento o renovar\r\n tu vencimiento p" +
                "ara pasar a estado activo, esta es la opcion:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(281, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Estado Tarjeta";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(294, 86);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(69, 20);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "_Estado";
            // 
            // lblNewDate
            // 
            this.lblNewDate.AutoSize = true;
            this.lblNewDate.Location = new System.Drawing.Point(12, 86);
            this.lblNewDate.Name = "lblNewDate";
            this.lblNewDate.Size = new System.Drawing.Size(151, 13);
            this.lblNewDate.TabIndex = 9;
            this.lblNewDate.Text = "_Fecha Actual de vencimiento";
            // 
            // btnEditarTarjeta
            // 
            this.btnEditarTarjeta.Location = new System.Drawing.Point(298, 250);
            this.btnEditarTarjeta.Name = "btnEditarTarjeta";
            this.btnEditarTarjeta.Size = new System.Drawing.Size(101, 59);
            this.btnEditarTarjeta.TabIndex = 2;
            this.btnEditarTarjeta.Text = "Confirmar Modificación";
            this.btnEditarTarjeta.UseVisualStyleBackColor = true;
            this.btnEditarTarjeta.Click += new System.EventHandler(this.btnEditarTarjeta_Click);
            // 
            // cmbTarjeta_Edit
            // 
            this.cmbTarjeta_Edit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarjeta_Edit.FormattingEnabled = true;
            this.cmbTarjeta_Edit.Location = new System.Drawing.Point(94, 22);
            this.cmbTarjeta_Edit.Name = "cmbTarjeta_Edit";
            this.cmbTarjeta_Edit.Size = new System.Drawing.Size(332, 21);
            this.cmbTarjeta_Edit.TabIndex = 3;
            this.cmbTarjeta_Edit.SelectedIndexChanged += new System.EventHandler(this.cmbTarjeta_Edit_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Fecha Vencimiento Actual";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tarjeta";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.btnDesasociarTarjeta);
            this.tabPage3.Controls.Add(this.cmbTarjeta_Baja);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.txtPass_Baja);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(452, 341);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DESASOCIAR";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(31, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(260, 26);
            this.label15.TabIndex = 4;
            this.label15.Text = "Para deshabilitar la tarjeta, tendras que confirmar con \r\nel codigo de seguridad " +
                "de la tarjeta misma";
            // 
            // btnDesasociarTarjeta
            // 
            this.btnDesasociarTarjeta.Location = new System.Drawing.Point(190, 231);
            this.btnDesasociarTarjeta.Name = "btnDesasociarTarjeta";
            this.btnDesasociarTarjeta.Size = new System.Drawing.Size(101, 40);
            this.btnDesasociarTarjeta.TabIndex = 2;
            this.btnDesasociarTarjeta.Text = "DESASOCIAR";
            this.btnDesasociarTarjeta.UseVisualStyleBackColor = true;
            this.btnDesasociarTarjeta.Click += new System.EventHandler(this.btnDesasociarTarjeta_Click);
            // 
            // cmbTarjeta_Baja
            // 
            this.cmbTarjeta_Baja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarjeta_Baja.FormattingEnabled = true;
            this.cmbTarjeta_Baja.Location = new System.Drawing.Point(94, 100);
            this.cmbTarjeta_Baja.Name = "cmbTarjeta_Baja";
            this.cmbTarjeta_Baja.Size = new System.Drawing.Size(335, 21);
            this.cmbTarjeta_Baja.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(124, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Codigo de Seguridad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Tarjeta";
            // 
            // txtPass_Baja
            // 
            this.txtPass_Baja.Location = new System.Drawing.Point(245, 175);
            this.txtPass_Baja.Name = "txtPass_Baja";
            this.txtPass_Baja.Size = new System.Drawing.Size(101, 20);
            this.txtPass_Baja.TabIndex = 0;
            this.txtPass_Baja.UseSystemPasswordChar = true;
            this.txtPass_Baja.TextChanged += new System.EventHandler(this.txtPass_Baja_TextChanged);
            this.txtPass_Baja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_Baja_KeyPress);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(161, 406);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(119, 44);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Volver Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // lblFechaSistema
            // 
            this.lblFechaSistema.AutoSize = true;
            this.lblFechaSistema.Location = new System.Drawing.Point(13, 422);
            this.lblFechaSistema.Name = "lblFechaSistema";
            this.lblFechaSistema.Size = new System.Drawing.Size(80, 13);
            this.lblFechaSistema.TabIndex = 2;
            this.lblFechaSistema.Text = "_FechaSistema";
            // 
            // frmTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.lblFechaSistema);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.tcTarjeta);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjeta";
            this.Load += new System.EventHandler(this.frmTarjeta_Load);
            this.tcTarjeta.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcTarjeta;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnAsociarTarjeta;
        private System.Windows.Forms.TextBox txtSeguridad_a;
        private System.Windows.Forms.DateTimePicker dtpVenc_a;
        private System.Windows.Forms.DateTimePicker dtpEmisor_a;
        private System.Windows.Forms.ComboBox cmbEmisor;
        private System.Windows.Forms.TextBox txtNroTar_a;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditarTarjeta;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.DateTimePicker dtpNewDate;
        private System.Windows.Forms.ComboBox cmbTarjeta_Edit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDesasociarTarjeta;
        private System.Windows.Forms.ComboBox cmbTarjeta_Baja;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPass_Baja;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFechaSistema;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton rbVencimiento;
        private System.Windows.Forms.RadioButton rbSeguridad;
        private System.Windows.Forms.Label label16;
    }
}