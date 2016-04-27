namespace AerolineaFrba.Abm_Ruta
{
    partial class listadoRuta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.baseKG = new System.Windows.Forms.TextBox();
            this.basePasaje = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.servicioDrop = new System.Windows.Forms.ComboBox();
            this.destinoDrop = new System.Windows.Forms.ComboBox();
            this.origenDrop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buscar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listado = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.baseKG);
            this.groupBox1.Controls.Add(this.basePasaje);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.servicioDrop);
            this.groupBox1.Controls.Add(this.destinoDrop);
            this.groupBox1.Controls.Add(this.origenDrop);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buscar);
            this.groupBox1.Controls.Add(this.limpiar);
            this.groupBox1.Controls.Add(this.nombreBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(859, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // baseKG
            // 
            this.baseKG.Location = new System.Drawing.Point(379, 94);
            this.baseKG.Name = "baseKG";
            this.baseKG.Size = new System.Drawing.Size(148, 20);
            this.baseKG.TabIndex = 25;
            // 
            // basePasaje
            // 
            this.basePasaje.Location = new System.Drawing.Point(379, 65);
            this.basePasaje.Name = "basePasaje";
            this.basePasaje.Size = new System.Drawing.Size(148, 20);
            this.basePasaje.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(258, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Precio base (KG)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(258, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Precio base (pasaje)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(258, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Tipo de Servicio";
            // 
            // servicioDrop
            // 
            this.servicioDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.servicioDrop.FormattingEnabled = true;
            this.servicioDrop.Location = new System.Drawing.Point(379, 30);
            this.servicioDrop.Name = "servicioDrop";
            this.servicioDrop.Size = new System.Drawing.Size(148, 21);
            this.servicioDrop.TabIndex = 21;
            // 
            // destinoDrop
            // 
            this.destinoDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinoDrop.FormattingEnabled = true;
            this.destinoDrop.Location = new System.Drawing.Point(91, 92);
            this.destinoDrop.Name = "destinoDrop";
            this.destinoDrop.Size = new System.Drawing.Size(101, 21);
            this.destinoDrop.TabIndex = 19;
            // 
            // origenDrop
            // 
            this.origenDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.origenDrop.FormattingEnabled = true;
            this.origenDrop.Location = new System.Drawing.Point(91, 62);
            this.origenDrop.Name = "origenDrop";
            this.origenDrop.Size = new System.Drawing.Size(101, 21);
            this.origenDrop.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ciudad Destino";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Ciudad Origen";
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(778, 136);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(75, 23);
            this.buscar.TabIndex = 3;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(9, 136);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 2;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // nombreBox
            // 
            this.nombreBox.Location = new System.Drawing.Point(91, 31);
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(101, 20);
            this.nombreBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // listado
            // 
            this.listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listado.Location = new System.Drawing.Point(12, 197);
            this.listado.Name = "listado";
            this.listado.ReadOnly = true;
            this.listado.Size = new System.Drawing.Size(859, 292);
            this.listado.TabIndex = 1;
            this.listado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listado_CellContentClick);
            // 
            // listadoRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 501);
            this.Controls.Add(this.listado);
            this.Controls.Add(this.groupBox1);
            this.Name = "listadoRuta";
            this.Text = "Listado Ruta";
            this.Load += new System.EventHandler(this.listadoRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView listado;
        private System.Windows.Forms.TextBox baseKG;
        private System.Windows.Forms.TextBox basePasaje;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox servicioDrop;
        private System.Windows.Forms.ComboBox destinoDrop;
        private System.Windows.Forms.ComboBox origenDrop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}