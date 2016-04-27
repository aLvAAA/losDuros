namespace AerolineaFrba.Abm_Ruta
{
    partial class ModificacionRuta
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
            this.codigoBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guardar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.origenDrop = new System.Windows.Forms.ComboBox();
            this.destinoDrop = new System.Windows.Forms.ComboBox();
            this.servicioDrop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.basePasaje = new System.Windows.Forms.TextBox();
            this.baseKG = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.habilitadoCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // codigoBox
            // 
            this.codigoBox.Location = new System.Drawing.Point(122, 28);
            this.codigoBox.Name = "codigoBox";
            this.codigoBox.ReadOnly = true;
            this.codigoBox.Size = new System.Drawing.Size(150, 20);
            this.codigoBox.TabIndex = 0;
            this.codigoBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código";
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(197, 353);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 4;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(11, 353);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 5;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ciudad Origen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ciudad Destino";
            // 
            // origenDrop
            // 
            this.origenDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.origenDrop.FormattingEnabled = true;
            this.origenDrop.Location = new System.Drawing.Point(122, 74);
            this.origenDrop.Name = "origenDrop";
            this.origenDrop.Size = new System.Drawing.Size(150, 21);
            this.origenDrop.TabIndex = 8;
            // 
            // destinoDrop
            // 
            this.destinoDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinoDrop.FormattingEnabled = true;
            this.destinoDrop.Location = new System.Drawing.Point(122, 130);
            this.destinoDrop.Name = "destinoDrop";
            this.destinoDrop.Size = new System.Drawing.Size(150, 21);
            this.destinoDrop.TabIndex = 9;
            // 
            // servicioDrop
            // 
            this.servicioDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.servicioDrop.FormattingEnabled = true;
            this.servicioDrop.Location = new System.Drawing.Point(122, 185);
            this.servicioDrop.Name = "servicioDrop";
            this.servicioDrop.Size = new System.Drawing.Size(150, 21);
            this.servicioDrop.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tipo de Servicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Precio base (pasaje)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Precio base (KG)";
            // 
            // basePasaje
            // 
            this.basePasaje.Location = new System.Drawing.Point(122, 232);
            this.basePasaje.Name = "basePasaje";
            this.basePasaje.Size = new System.Drawing.Size(150, 20);
            this.basePasaje.TabIndex = 14;
            this.basePasaje.TextChanged += new System.EventHandler(this.basePasaje_TextChanged);
            // 
            // baseKG
            // 
            this.baseKG.Location = new System.Drawing.Point(122, 275);
            this.baseKG.Name = "baseKG";
            this.baseKG.Size = new System.Drawing.Size(150, 20);
            this.baseKG.TabIndex = 15;
            this.baseKG.TextChanged += new System.EventHandler(this.baseKG_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Habilitado";
            // 
            // habilitadoCheck
            // 
            this.habilitadoCheck.AutoSize = true;
            this.habilitadoCheck.Location = new System.Drawing.Point(124, 315);
            this.habilitadoCheck.Name = "habilitadoCheck";
            this.habilitadoCheck.Size = new System.Drawing.Size(15, 14);
            this.habilitadoCheck.TabIndex = 17;
            this.habilitadoCheck.UseVisualStyleBackColor = true;
            // 
            // ModificacionRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 388);
            this.Controls.Add(this.habilitadoCheck);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.baseKG);
            this.Controls.Add(this.basePasaje);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.servicioDrop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.destinoDrop);
            this.Controls.Add(this.origenDrop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codigoBox);
            this.Name = "ModificacionRuta";
            this.Text = "Modificacion Ruta";
            this.Load += new System.EventHandler(this.ModificacionRuta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codigoBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox origenDrop;
        private System.Windows.Forms.ComboBox destinoDrop;
        private System.Windows.Forms.ComboBox servicioDrop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox basePasaje;
        private System.Windows.Forms.TextBox baseKG;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox habilitadoCheck;
    }
}